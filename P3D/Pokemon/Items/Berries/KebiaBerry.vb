Namespace Items.Berries

    <Item(2041, "Kebia")>
    Public Class KebiaBerry

        Inherits Berry
        Public Overrides ReadOnly Property CanBeUsed As Boolean = False
        Public Overrides ReadOnly Property CanBeUsedInBattle As Boolean = False
        Public Sub New()
            MyBase.New(64800, "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Poison-type attack.", "8.9cm", "Hard", 1, 5)

            Me.Spicy = 0
            Me.Dry = 15
            Me.Sweet = 0
            Me.Bitter = 0
            Me.Sour = 10

            Me.Type = Element.Types.Poison
            Me.Power = 80
            Me.JuiceColor = "green"
            Me.JuiceGroup = 2
        End Sub

    End Class

End Namespace
