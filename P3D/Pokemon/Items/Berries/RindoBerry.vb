Namespace Items.Berries

    <Item(2038, "Rindo")>
    Public Class RindoBerry

        Inherits Berry
        Public Overrides ReadOnly Property CanBeUsed As Boolean = False
        Public Overrides ReadOnly Property CanBeUsedInBattle As Boolean = False
        Public Sub New()
            MyBase.New(64800, "If held by a Pokémon, this Berry will lessen the damage taken from one supereffective Grass-type attack.", "15.5cm", "Soft", 1, 5)

            Me.Spicy = 10
            Me.Dry = 0
            Me.Sweet = 0
            Me.Bitter = 15
            Me.Sour = 0

            Me.Type = Element.Types.Grass
            Me.Power = 80
            Me.JuiceColor = "green"
            Me.JuiceGroup = 2
        End Sub

    End Class

End Namespace
