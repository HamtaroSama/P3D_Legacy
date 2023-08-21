﻿Namespace BattleSystem.Moves.Bug

    Public Class UTurn

        Inherits Attack

        Public Sub New()
            '#Definitions
            Me.Type = New Element(Element.Types.Bug)
            Me.ID = 369
            Me.OriginalPP = 20
            Me.CurrentPP = 20
            Me.MaxPP = 20
            Me.Power = 70
            Me.Accuracy = 100
            Me.Category = Categories.Physical
            Me.ContestCategory = ContestCategories.Cute
            Me.Name = Localization.GetString("move_name_" & Me.ID, "U-turn")
            Me.Description = "After making its attack, the user rushes back to switch places with a party Pokémon in waiting."
            Me.CriticalChance = 1
            Me.IsHMMove = False
            Me.Target = Targets.OneAdjacentTarget
            Me.Priority = 0
            Me.TimesToAttack = 1
            '#End

            '#SpecialDefinitions
            Me.SwapsOutOwnPokemon = True
            Me.MakesContact = True
            Me.ProtectAffected = True
            Me.MagicCoatAffected = False
            Me.SnatchAffected = False
            Me.MirrorMoveAffected = True
            Me.KingsrockAffected = True
            Me.CounterAffected = True

            Me.DisabledWhileGravity = False
            Me.UseEffectiveness = True
            Me.ImmunityAffected = True
            Me.RemovesOwnFrozen = False
            Me.HasSecondaryEffect = False

            Me.IsHealingMove = False
            Me.IsRecoilMove = False

            Me.IsDamagingMove = True
            Me.IsProtectMove = False


            Me.IsAffectedBySubstitute = True
            Me.IsOneHitKOMove = False
            Me.IsWonderGuardAffected = True
            '#End
        End Sub

        Public Overrides Sub MoveSwitch(own As Boolean, BattleScreen As BattleScreen)
            If own = True Then
                If BattleScreen.OwnPokemon.Status <> Pokemon.StatusProblems.Fainted Then
                    If Core.Player.CountFightablePokemon > 1 AndAlso BattleScreen.FieldEffects.OwnSwapIndex <> BattleScreen.OwnPokemonIndex AndAlso BattleScreen.FieldEffects.OwnSwapIndex <> -1 Then
                        BattleScreen.Battle.SwitchOutOwn(BattleScreen, BattleScreen.FieldEffects.OwnSwapIndex, -1)
                        BattleScreen.FieldEffects.OwnSwapIndex = -1
                    Else
                        BattleScreen.BattleQuery.Add(New TextQueryObject(Me.Name & " failed!"))
                    End If
                Else
                    BattleScreen.FieldEffects.OwnSwapIndex = -1
                End If
            Else
                If BattleScreen.IsTrainerBattle = True Then
                    If BattleScreen.IsRemoteBattle = True Or BattleScreen.IsPVPBattle = True Then
                        If BattleScreen.OppPokemon.Status <> Pokemon.StatusProblems.Fainted Then
                            BattleScreen.FieldEffects.OppUsedBatonPass = True
                            If BattleScreen.Trainer.CountUseablePokemon > 1 AndAlso BattleScreen.FieldEffects.OppSwapIndex <> BattleScreen.OppPokemonIndex AndAlso BattleScreen.FieldEffects.OppSwapIndex <> -1 Then
                                BattleScreen.FieldEffects.OppUsedBatonPass = True

                                BattleScreen.Battle.SwitchOutOpp(BattleScreen, BattleScreen.FieldEffects.OppSwapIndex)
                                BattleScreen.FieldEffects.OppSwapIndex = -1
                            Else
                                BattleScreen.BattleQuery.Add(New TextQueryObject(Me.Name & " failed!"))
                            End If
                        Else
                            BattleScreen.FieldEffects.OppSwapIndex = -1
                        End If
                    Else
                        If BattleScreen.Trainer.CountUseablePokemon > 1 Then
                            BattleScreen.FieldEffects.OppUsedBatonPass = True

                            BattleScreen.Battle.SwitchOutOpp(BattleScreen, GetPokemonIndex(BattleScreen, own))
                        Else
                            BattleScreen.BattleQuery.Add(New TextQueryObject(Me.Name & " failed!"))
                        End If
                    End If
                Else
                    BattleScreen.BattleQuery.Add(New TextQueryObject(Me.Name & " failed!"))
                End If
            End If
        End Sub

        Private Function GetPokemonIndex(ByVal BattleScreen As BattleScreen, ByVal own As Boolean) As Integer
            If own = True Then
                Dim i As Integer = 0
                While Core.Player.Pokemons(i).HP <= 0 Or Core.Player.Pokemons(i).Status = Pokemon.StatusProblems.Fainted Or i = BattleScreen.OwnPokemonIndex Or Core.Player.Pokemons(i).IsEgg() = True
                    i += 1
                End While
                Return i
            Else
                Dim i As Integer = 0
                While BattleScreen.Trainer.Pokemons(i).HP <= 0 Or BattleScreen.Trainer.Pokemons(i).Status = Pokemon.StatusProblems.Fainted Or i = BattleScreen.OppPokemonIndex Or BattleScreen.Trainer.Pokemons(i).IsEgg() = True
                    i += 1
                End While
                Return i
            End If
            Return -1
        End Function

    End Class

End Namespace
