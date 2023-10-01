Namespace Items.Berries

    <Item(2026, "Cornn")>
    Public Class CornnBerry

        Inherits Berry

        Public Overrides ReadOnly Property CanBeUsed As Boolean = False
        Public Overrides ReadOnly Property CanBeUsedInBattle As Boolean = False
        Public Sub New()
            MyBase.New(21600, "Pokéblock ingredient. Plant in loamy soil to grow Cornn.", "7.5cm", "Hard", 2, 4)

            Me.Spicy = 0
            Me.Dry = 20
            Me.Sweet = 10
            Me.Bitter = 0
            Me.Sour = 0

            Me.Type = Element.Types.Bug
            Me.Power = 90
            Me.JuiceColor = "purple"
            Me.JuiceGroup = 1
        End Sub

    End Class

End Namespace
