Imports System.Data.SqlClient
Imports Nanocon.Modules.Constants

Public Class MagicItem(Of T)
    Public _Data As T

#Region "Constructors"
    Protected Sub New()
    End Sub
#End Region
#Region "Methods"
    Protected Sub SetupItem(ByVal data As T)
        _Data = data
    End Sub
#End Region
#Region "Properties"
    Protected _id As Long
    Public ReadOnly Property Id As Long
        Get
            Return _id
        End Get
    End Property
#End Region
#Region "Private Methods"
    Protected Sub Update(ByVal tableName As String, ByVal colName As String, ByVal val As Object, ByVal dbtype As SqlDbType)
        Dim sql As String = "UPDATE " & tableName
        sql &= " SET " & colName & " = @" & colName & vbNewLine
        sql &= "WHERE Id = @Id"

        Using cn As New SqlConnection(conStr), _
           cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = _id
            cmd.Parameters.Add("@" & colName, dbtype).Value = val

            cmd.ExecuteScalar()
            cn.Close()
        End Using
    End Sub
#End Region
#Region "Public Methods"
    Public Sub Delete(ByVal table As String, ByVal id As Long)
        Dim sql As String = "Delete from Nano." & table
        sql &= "Where Id = @Id"

        Using cn As New SqlConnection(Nanocon.Modules.Constants.conStr), _
           cmd As New SqlCommand(sql, cn)

            cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = _id

            cmd.ExecuteScalar()
            cn.Close()
        End Using
    End Sub
#End Region
End Class
