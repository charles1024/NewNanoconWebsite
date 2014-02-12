Imports Nanocon.Modules
Public Class About
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim ev As [Event] = [Event].Create(New Structures.Event With {
                                .Name = "test",
                                .Approved = True,
                                .Cost = 0,
                                .Description = "test",
                                .GameSystem = "",
                                .Publisher = "butts",
                                .Slots = 5,
                                .Sponsor = "",
                                .Time = Today.Date,
                                .UserId = 5})
        ev.Description = "Test2"

    End Sub
End Class