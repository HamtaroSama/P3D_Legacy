Namespace Items.Mail

    <Item(308, "Retro Mail")>
    Public Class RetroMail

        Inherits MailItem

        Public Overrides ReadOnly Property Description As String = "Mail featuring the drawings of three Pokémon."

        Public Sub New()
            _textureRectangle = New Rectangle(168, 456, 24, 24)
        End Sub

        Public Overrides Sub Use()
            Dim MailID As String
            If Me.IsGameModeItem = True Then
                MailID = Me.gmID
            Else
                MailID = Me.ID.ToString
            End If
            Core.SetScreen(New TransitionScreen(Core.CurrentScreen, New MailSystemScreen(Core.CurrentScreen, MailID), Color.Black, False))
        End Sub

    End Class

End Namespace
