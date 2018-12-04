﻿Imports System.IO
Imports System.Math

Module Game

    Public Class Card
        Public Name As String
        Public ExerciseScore As Integer
        Public IntelligenceScore As Integer
        Public FriendlinessScore As Integer
        Public DroolScore As Integer

        Public Sub New()

        End Sub

        Public Sub New(ByVal _name As String, ByVal _exerciseScore As Integer, ByVal _intelligenceScore As Integer, ByVal _friendlinessScore As Integer, ByVal _droolScore As Integer)
            Name = _name
            ExerciseScore = _exerciseScore
            IntelligenceScore = _intelligenceScore
            FriendlinessScore = _friendlinessScore
            DroolScore = _droolScore
        End Sub

    End Class

    Sub DisplayMenu()
        Console.WriteLine("Welcome to Celebrity Dogs" + vbCrLf)
        Console.WriteLine("Welcome to the Main Menu!")
        Console.WriteLine("Press P or p to Play Game")
        Console.WriteLine("Press Q or q to Quit Game" + vbCrLf)

    End Sub


    Sub YouWin(_playerPile As List(Of Card), _computerPile As List(Of Card), _currentPlayerCard As Card, _currentComputerCard As Card)
        Console.WriteLine("You win")
        _playerPile.Remove(_currentPlayerCard)
        _computerPile.Remove(_currentComputerCard)
        _playerPile.Add(_currentPlayerCard)
        _playerPile.Add(_currentComputerCard)
    End Sub

    Sub ComputerWins(_playerPile, _computerPile, _currentPlayerCard, _currentComputerCard)
        Console.WriteLine("Computer wins")
        _computerPile.Remove(_currentComputerCard)
        _playerPile.Remove(_currentPlayerCard)
        _computerPile.Add(_currentComputerCard)
        _computerPile.Add(_currentPlayerCard)
    End Sub

    Sub Main()

        'Players cards

        Dim fileReader As StreamReader = New StreamReader("C:\\Users\\enxbm\\Documents\\Visual Studio 2017\\Projects\\DogCardGame\\DogCardGame\\dogs.txt")
        Dim line As String
        Dim list As New List(Of String)

        line = fileReader.ReadLine()

        Do While (Not line Is Nothing)
            list.Add(line)
            line = fileReader.ReadLine
        Loop

        Dim cardDogName As New List(Of String)
        Dim cardDogExerciseScores As New List(Of Integer)
        Dim cardDogIntelligenceScores As New List(Of Integer)
        Dim cardDogFriendlinessScores As New List(Of Integer)
        Dim cardDogDroolScores As New List(Of Integer)

        For i = 0 To 149 Step 5
            cardDogName.Add(list(i))
        Next

        For i = 1 To 149 Step 5
            cardDogExerciseScores.Add(list(i))
        Next

        For i = 2 To 149 Step 5
            cardDogIntelligenceScores.Add(list(i))
        Next

        For i = 3 To 149 Step 5
            cardDogFriendlinessScores.Add(list(i))
        Next

        For i = 4 To 149 Step 5
            cardDogDroolScores.Add(list(i))
        Next


        Dim cards As New List(Of Card)

        For i = 0 To cardDogName.Count - 1
            cards.Add(New Card(cardDogName(i), cardDogExerciseScores(i), cardDogIntelligenceScores(i), cardDogFriendlinessScores(i), cardDogDroolScores(i)))
        Next

        Dim playerPile As New List(Of Card)
        Dim computerPile As New List(Of Card)

        Dim responseCategory As String
        Dim playerStat As Integer
        Dim computerStat As Integer

        Dim allowedResponseCategories As New ArrayList
        allowedResponseCategories.Add("E")
        allowedResponseCategories.Add("I")
        allowedResponseCategories.Add("F")
        allowedResponseCategories.Add("D")

        Dim firstCardOnPile As Integer
        firstCardOnPile = 0

        Dim currentPlayerCard As New Card
        Dim currentComputerCard As New Card

        DisplayMenu()
        Dim menuOption As Char

        menuOption = Console.ReadLine().ToUpper

        Dim totalNumberOfCards As Integer
        totalNumberOfCards = 0

        While True

            If menuOption = "P" Then

                While totalNumberOfCards < 4 Or totalNumberOfCards > 30 Or totalNumberOfCards Mod 2 = 1
                    Console.WriteLine("Please enter the total number of cards that you want to play with (it must be an even number between 4 and 30 (inclusive)).")
                    totalNumberOfCards = Console.ReadLine()
                    If totalNumberOfCards < 4 Or totalNumberOfCards > 30 Or totalNumberOfCards Mod 2 = 1 Then
                        Console.WriteLine("Please enter an even number between 4 and 30.")
                        DisplayMenu()
                        menuOption = Console.ReadLine().ToUpper
                    End If

                End While

                For i = 0 To Floor((totalNumberOfCards - 1) / 2)
                    playerPile.Add(cards(i))
                Next

                For i = Ceiling((totalNumberOfCards - 1) / 2) To totalNumberOfCards - 1
                    computerPile.Add(cards(i))
                Next

                Console.WriteLine("Your current card: " + currentPlayerCard.Name)
                Console.WriteLine("Computer's current card: " + currentComputerCard.Name)

                While playerPile.Count <> 0 Or computerPile.Count <> 0

                    currentPlayerCard = cards(firstCardOnPile)
                    currentComputerCard = cards(Ceiling((totalNumberOfCards - 1) / 2))


                    Console.WriteLine("Please enter E (Exercise), I (Intelligence), F (Friendliness),  or D (Drool)")
                    responseCategory = Console.ReadLine().ToUpper

                    If allowedResponseCategories.Contains(responseCategory) = False Then
                        Console.WriteLine("Please enter either E, I, F, D")
                    Else

                        If responseCategory = "E" Then
                            playerStat = playerPile(firstCardOnPile).ExerciseScore
                            computerStat = computerPile(firstCardOnPile).ExerciseScore


                        ElseIf responseCategory = "I" Then
                            playerStat = playerPile(firstCardOnPile).IntelligenceScore
                            computerStat = computerPile(firstCardOnPile).IntelligenceScore


                        ElseIf responseCategory = "F" Then
                            playerStat = playerPile(firstCardOnPile).FriendlinessScore
                            computerStat = computerPile(firstCardOnPile).FriendlinessScore


                        ElseIf responseCategory = "D" Then
                            playerStat = playerPile(firstCardOnPile).DroolScore
                            computerStat = computerPile(firstCardOnPile).DroolScore
                        End If



                        If responseCategory = "D" Then
                            If playerStat <= computerStat Then
                                YouWin(playerPile, computerPile, currentPlayerCard, currentComputerCard)
                            Else
                                ComputerWins(playerPile, computerPile, currentPlayerCard, currentComputerCard)
                            End If
                        Else
                            If playerStat >= computerStat Then
                                YouWin(playerPile, computerPile, currentPlayerCard, currentComputerCard)
                            Else
                                ComputerWins(playerPile, computerPile, currentPlayerCard, currentComputerCard)
                            End If
                        End If
                        firstCardOnPile = firstCardOnPile + 1
                    End If

                    For Each card In playerPile
                        Console.WriteLine(card.Name)
                    Next
                    Console.WriteLine("!")
                    For Each card In computerPile
                        Console.WriteLine(card.Name)
                    Next

                End While

            ElseIf menuOption = "Q" Then
                Console.WriteLine("You are about to quit the game, press any key")
                Console.Read()
                Exit Sub
            End If

            If menuOption <> "P" Or menuOption <> "Q" Then
                Console.WriteLine("Please enter either P or Q")
                menuOption = Console.ReadLine().ToUpper
            End If
        End While

        Console.Read()

    End Sub

End Module