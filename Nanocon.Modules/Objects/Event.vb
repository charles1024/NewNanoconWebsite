Imports Nanocon.Modules
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Nanocon.Modules.Constants
Imports Nanocon.Modules.Structures
Public Class [Event]
    Inherits MagicItem(Of Structures.Event)
#Region "Constructor"
    Public Sub New(ByVal struct As Structures.Event)
        _Data = struct
    End Sub
#End Region
#Region "Properties"
    Public Property Name As String
        Get
            Return _Data.Name
        End Get
        Set(value As String)
            If _Data.Name = value Then Exit Property
            Update("Events", "Name", SqlDbType.VarChar, value)
            _Data.Name = value
        End Set
    End Property
    Public Property Type As Integer
        Get
            Return _Data.Type
        End Get
        Set(value As Integer)
            If _Data.Type = value Then Exit Property
            Update("Events", "Type", value, SqlDbType.Int)
            _Data.Type = value
        End Set
    End Property
    Public Property GameSystem As String
        Get
            Return _Data.GameSystem
        End Get
        Set(value As String)
            If _Data.GameSystem = value Then Exit Property
            Update("Events", "GameSystem", value, SqlDbType.VarChar)
            _Data.GameSystem = value
        End Set
    End Property
    Public Property Publisher As String
        Get
            Return _Data.Publisher
        End Get
        Set(value As String)
            If _Data.Publisher = value Then Exit Property
            Update("Events", "Publisher", value, SqlDbType.VarChar)
            _Data.Publisher = value
        End Set
    End Property
    Public Property Cost As Double
        Get
            Return _Data.Cost
        End Get
        Set(value As Double)
            If _Data.Cost = value Then Exit Property
            Update("Events", "Cost", value, SqlDbType.Float)
            _Data.Cost = value
        End Set
    End Property
    Public Property Sponsor As String
        Get
            Return _Data.Sponsor
        End Get
        Set(value As String)
            If _Data.Sponsor = value Then Exit Property
            Update("Events", "Sponsor", value, SqlDbType.Float)
            _Data.Sponsor = value
        End Set
    End Property
    Public Property Time As DateTime
        Get
            Return _Data.Time
        End Get
        Set(value As DateTime)
            If _Data.Time = value Then Exit Property
            Update("Events", "Time", value, SqlDbType.DateTime)
            _Data.Time = value
        End Set
    End Property
    Public Property Slots As Integer
        Get
            Return _Data.Slots
        End Get
        Set(value As Integer)
            If _Data.Slots = value Then Exit Property
            Update("Events", "Slots", value, SqlDbType.Int)
            _Data.Slots = value
        End Set
    End Property
    Public Property Description As String
        Get
            Return _Data.Description
        End Get
        Set(value As String)
            If _Data.Description = value Then Exit Property
            Update("Events", "Description", value, SqlDbType.NVarChar)
            _Data.Description = value
        End Set
    End Property
    Public Property Approved As Boolean
        Get
            Return _Data.Approved
        End Get
        Set(value As Boolean)
            If _Data.Approved = value Then Exit Property
            Update("Events", "Approved", value, SqlDbType.Bit)
            _Data.Approved = value
        End Set
    End Property
#End Region
#Region "Shared Methods"
    Public Shared Function Create(ByVal eventStruct As Structures.Event)
        Dim sql As String = "Insert into Events (Name, Type, GameSystem, Publisher, Cost, Sponsor, Time, Slots, Description, Approved, UserId) "
        sql &= "Values (@Name, @Type, @GameSystem, @Publisher, @Cost, @Sponsor, @Time, @Slots, @Description, @Approved, @UserId) "
        sql &= "Select SCOPE_IDENTITY()"

        Using cn As New SqlConnection(conStr), _
            cmd As New SqlCommand(sql, cn)
            cn.Open()

            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = eventStruct.Name
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = eventStruct.Type
            cmd.Parameters.Add("@GameSystem", SqlDbType.VarChar, 100).Value = eventStruct.GameSystem
            cmd.Parameters.Add("@Publisher", SqlDbType.VarChar, 100).Value = eventStruct.Publisher
            cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = eventStruct.Cost
            cmd.Parameters.Add("@Sponsor", SqlDbType.VarChar, 100).Value = eventStruct.Sponsor
            cmd.Parameters.Add("@Time", SqlDbType.DateTime).Value = eventStruct.Time
            cmd.Parameters.Add("@Slots", SqlDbType.Int).Value = eventStruct.Slots
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = eventStruct.Description
            cmd.Parameters.Add("@Approved", SqlDbType.Bit).Value = eventStruct.Approved
            cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = eventStruct.UserId
            eventStruct.Id = CLng(cmd.ExecuteScalar())

            cn.Close()
            Return New [Event](eventStruct)

        End Using
    End Function
#End Region
End Class

