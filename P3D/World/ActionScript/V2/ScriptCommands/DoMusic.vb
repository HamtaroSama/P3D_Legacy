﻿Namespace ScriptVersion2

    Partial Class ScriptCommander

        ' --------------------------------------------------------------------------------------------------------------------------
        ' Contains the @music commands.
        ' --------------------------------------------------------------------------------------------------------------------------

        Private Shared Sub DoMusic(ByVal subClass As String)
            Dim command As String = ScriptComparer.GetSubClassArgumentPair(subClass).Command
            Dim argument As String = ScriptComparer.GetSubClassArgumentPair(subClass).Argument

            Select Case command.ToLower()
                Case "play"
                    Dim LoopSong As Boolean = True
                    Dim FadeIntoSong As Boolean = False

                    If argument.Split(",").Length > 1 Then
                        If argument.GetSplit(1, ",") <> "" Then
                            LoopSong = CBool(argument.GetSplit(1, ","))
                        End If
                    End If
                    If argument.Split(",").Length > 2 Then
                        FadeIntoSong = CBool(argument.GetSplit(2, ","))
                    End If

                    If FadeIntoSong = False Then
                        MusicManager.Play(argument.GetSplit(0, ","), True, LoopSong)
                    Else
                        MusicManager.Play(argument.GetSplit(0, ","), True, 0.01F, LoopSong)
                    End If

                    If LoopSong = True Then
                        If Core.CurrentScreen.Identification = Screen.Identifications.OverworldScreen Then
                            Screen.Level.MusicLoop = argument
                        End If
                    Else
                        If Core.CurrentScreen.Identification = Screen.Identifications.OverworldScreen Then
                            Screen.Level.MusicLoop = "silence"
                        End If
                    End If
                Case "forceplay"
                    Dim LoopSong As Boolean = True
                    Dim FadeIntoSong As Boolean = False
                    If argument.Split(",").Length > 1 Then
                        LoopSong = CBool(argument.GetSplit(1, ","))
                    End If
                    If argument.Split(",").Length > 2 Then
                        FadeIntoSong = CBool(argument.GetSplit(2, ","))
                    End If
                    MusicManager.ForceMusic = argument.GetSplit(0, ",")
                    If FadeIntoSong = False Then
                        MusicManager.Play(argument.GetSplit(0, ","), True, LoopSong)
                    Else
                        MusicManager.Play(argument.GetSplit(0, ","), True, 0.01F, LoopSong)
                    End If

                    If LoopSong = True Then
                        If Core.CurrentScreen.Identification = Screen.Identifications.OverworldScreen Then
                            Screen.Level.MusicLoop = argument
                        End If
                    Else
                        If Core.CurrentScreen.Identification = Screen.Identifications.OverworldScreen Then
                            Screen.Level.MusicLoop = "silence"
                        End If
                    End If
                Case "unforce"
                    MusicManager.ForceMusic = ""
                Case "setmusicloop"
                    If Core.CurrentScreen.Identification = Screen.Identifications.OverworldScreen Then
                        Screen.Level.MusicLoop = argument
                    End If
                Case "stop"
                    MusicManager.Stop()
                Case "mute"
                    MusicManager.Muted() = True
                Case "unmute"
                    MusicManager.Muted() = False
                Case "pause"
                    MusicManager.Paused() = True
                Case "resume"
                    MusicManager.Paused() = False
            End Select

            IsReady = True
        End Sub

    End Class

End Namespace