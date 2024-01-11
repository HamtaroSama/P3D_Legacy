Namespace Items.Berries

    <Item(2035, "Occa")>
    Public Class OccaBerry

        Inherits Berry
        Public Overrides ReadOnly Property CanBeUsed As Boolean = False
        Public Overrides ReadOnly Property CanBeUsedInBattle As Boolean = False
        Public Sub New()
            MyBase.New(64800, "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Fire-type attack.", "8.9cm", "Super Hard", 1, 5)

            Me.Spicy = 15
            Me.Dry = 0
            Me.Sweet = 10
            Me.Bitter = 0
            Me.Sour = 0

            Me.Type = Element.Types.Fire
            Me.Power = 80
            Me.JuiceColor = "red"
            Me.JuiceGroup = 2
        End Sub

    End Class

End Namespace
