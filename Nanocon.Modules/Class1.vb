Imports Nanocon.Modules
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Nanocon.Modules.Constants

Public Class [Event]
    Inherits MagicItem(Of Structures.Event)
#Region "Constructor"
    Public Sub New(ByVal struct As Structures.Event)
        _id = struct.Id
        _name = struct.Name
        _type = struct.Type
        _gameSystem = struct.GameSystem
        _publisher = struct.Publisher
        _cost = struct.Cost
        _sponsor = struct.Sponsor
        _time = struct.Time
        _slots = struct.Slots
        _description = struct.Description
        _approved = struct.Approved
    End Sub
#End Region
#Region "Properties"
    Private _name As String
    Private _type As Integer
    Private _gameSystem As String
    Private _publisher As String
    Private _cost As Double
    Private _sponsor As String
    Private _time As DateTime
    Private _slots As Integer
    Private _description As String
    Private _approved As Boolean

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            If _name = value Then Exit Property
            Update("Event", "Name", sqldbtype.varchar, value)
            _name = value
        End Set
    End Property
    Public Property Type As Integer
        Get
            Return _type
        End Get
        Set(value As Integer)
            If _type = value Then Exit Property
            Update("Event", "Type", value, SqlDbType.Int)
            _type = value
        End Set
    End Property
    Public Property GameSystem As String
        Get
            Return _gameSystem
        End Get
        Set(value As String)
            If _gameSystem = value Then Exit Property
            Update("Event", "GameSystem", value, SqlDbType.VarChar)
            _gameSystem = value
        End Set
    End Property
    Public Property Publisher As String
        Get
            Return _publisher
        End Get
        Set(value As String)
            If _publisher = value Then Exit Property
            Update("Event", "Publisher", value, SqlDbType.VarChar)
            _publisher = value
        End Set
    End Property
    Public Property Cost As Double
        Get
            Return _cost
        End Get
        Set(value As Double)
            If _cost = value Then Exit Property
            Update("Event", "Cost", value, SqlDbType.Float)
            _cost = value
        End Set
    End Property
    Public Property Sponsor As String
        Get
            Return _cost
        End Get
        Set(value As String)
            If _cost = value Then Exit Property
            Update("Event", "Cost", value, SqlDbType.Float)
            _cost = value
        End Set
    End Property
    Public Property Time As DateTime
        Get
            Return _time
        End Get
        Set(value As DateTime)
            If _time = value Then Exit Property
            Update("Event", "Time", value, SqlDbType.DateTime)
            _time = value
        End Set
    End Property
    Public Property Slots As Integer
        Get
            Return _slots
        End Get
        Set(value As Integer)
            If _slots = value Then Exit Property
            Update("Event", "Slots", value, SqlDbType.Int)
            _slots = value
        End Set
    End Property
    Public Property Description As String
        Get
            Return _description
        End Get
        Set(value As String)
            If _description = value Then Exit Property
            Update("Event", "Description", value, SqlDbType.NVarChar)
            _description = value
        End Set
    End Property
    Public Property Approved As Boolean
        Get
            Return _approved
        End Get
        Set(value As Boolean)
            If _approved = value Then Exit Property
            Update("Event", "Approved", value, SqlDbType.Bit)
            _approved = value
        End Set
    End Property
#End Region
#Region "Shared Methods"
    Public Shared Function Create(ByVal eventStruct As Structures.Event)
        Dim sql As String = "Insert into Nano.Events (Name, Type, GameSystem, Publisher, Cost, Sponsor, Time, Slots, Description, Approved) "
        sql &= "Values (@Name, @Type, @GameSystem, @Publisher, @Cost, @Sponsor, @Time, @Slots, @Description, @Approved) "
        sql &= "Select SCOPE_IDENTITY()"


        Using cn As New SqlConnection(conStr), _
            cmd As New SqlCommand(sql, cn)

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

            eventStruct.Id = CLng(cmd.ExecuteScalar())

            Return New [Event](eventStruct)
            cn.Close()
        End Using
    End Function
#End Region
End Class

