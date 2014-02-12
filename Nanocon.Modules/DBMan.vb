Imports System.Linq
Imports System.Data
Imports System.Collections.Generic
Imports System.Diagnostics

<Serializable()> _
Public Class DBMan
    Private ReadOnly _conn As String
    Private Const DefaultCommandTimeout As Integer = 60

    Public Sub New(ByVal connection As String)
        _conn = connection
    End Sub
    Public Structure SQLCommandItem
        Public Parameter As Data.SqlClient.SqlParameter
        Public Value As Object
    End Structure
#Region "Private"
    Private Sub AddParamesterstoCommand(ByRef cmd As SqlClient.SqlCommand, ByVal items As List(Of SQLCommandItem))

        For Each item As SQLCommandItem In items
            Select Case item.Parameter.Direction
                Case ParameterDirection.Input
                    cmd.Parameters.AddWithValue(item.Parameter.ParameterName, item.Value)
                Case ParameterDirection.Output, ParameterDirection.ReturnValue
                    cmd.Parameters.Add(item.Parameter)
            End Select
        Next
    End Sub
#End Region
    Public Function sqlSelect(ByVal sqlCommand As String, ByVal items As List(Of SQLCommandItem)) As DataView
        If items Is Nothing OrElse items.Count = 0 Then Return Nothing

        Dim conn As New SqlClient.SqlConnection(_conn)
        Dim cmd As New SqlClient.SqlCommand(sqlCommand, conn)
        Dim dataAdapter As New SqlClient.SqlDataAdapter
        Dim custDS As New DataSet

        AddParamesterstoCommand(cmd, items)

        dataAdapter.SelectCommand = cmd
        dataAdapter.Fill(custDS)

        If custDS.Tables.Count = 0 Then
            sqlSelect = Nothing
        Else
            sqlSelect = custDS.Tables(custDS.Tables.Count - 1).DefaultView
        End If

        conn.Close()

    End Function
    Public Function sqlInsert(ByVal tableName As String, ByVal items As List(Of SQLCommandItem)) As DataView
        If items Is Nothing Then Return Nothing
        Dim sql As String = <sql>INSERT INTO <%= tableName %> ( <%= String.Join(", ", items.Select(Function(i) i.Parameter.ParameterName.Substring(1, i.Parameter.ParameterName.Length - 1)).ToArray()) %>)
					VALUES (<%= String.Join(", ", items.Select(Function(i) i.Parameter.ParameterName).ToArray()) %>);
				</sql>.Value

        Return sqlSelect(sql, items)
    End Function
    Public Sub sqlUpdate(ByVal tableName As String, ByVal items As List(Of SQLCommandItem), ByVal conditions As List(Of SQLCommandItem))

        Using connection As New SqlClient.SqlConnection(_conn)
            Dim SQL As String = <sql>
				UPDATE <%= tableName %>
					SET <%= String.Join(", ", items.Select(Function(i) i.Parameter.ParameterName.Substring(1, i.Parameter.ParameterName.Length - 1) & " = " & i.Parameter.ParameterName).ToArray()) %>
                                </sql>.Value

            If conditions IsNot Nothing Then
                SQL &= " WHERE " & String.Join(" AND ", conditions.Select(Function(i) i.Parameter.ParameterName.Substring(1, i.Parameter.ParameterName.Length - 1) & " = " & i.Parameter.ParameterName).ToArray())
            End If

            Dim command As New SqlClient.SqlCommand(SQL, connection)
            If items IsNot Nothing Then Call AddParamesterstoCommand(command, items)
            If conditions IsNot Nothing Then Call AddParamesterstoCommand(command, conditions)

            connection.Open()
            command.ExecuteReader()
            connection.Close()
        End Using
    End Sub
    Public Sub sqlDelete(ByVal tableName As String, ByVal where As List(Of SQLCommandItem))
        sqlSelect(<sql>
				DELETE FROM <%= tableName %>
					WHERE <%= String.Join(" AND ", where.Select(Function(i) i.Parameter.ParameterName.Substring(1, i.Parameter.ParameterName.Length - 1) & "=" & i.Parameter.ParameterName).ToArray()) %>;
			</sql>.Value, where)
    End Sub
End Class
