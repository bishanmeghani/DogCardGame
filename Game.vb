Imports System.IO

Module Game

    Sub Menu()

        Console.WriteLine("Welcome to the Main Menu!")
        Console.WriteLine("Press P or p to Play Game")
        Console.WriteLine("Press Q or q to Quit Game" + vbCrLf)

    End Sub

    Sub Main()

        'Players cards

        Dim fileReader As StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\\Users\\enxbm\\Documents\\Visual Studio 2017\\Projects\\DogCardGame\\dogs.txt")
        Dim stringReader As String
        stringReader = fileReader.ReadLine()

        Dim cards(0 To 5)
        cards(0) = {"Annie the Afghan Hound", 4, 15, 6, 1}
        cards(1) = {"Bertie the Boxer", 5, 50, 9, 9}
        cards(2) = {"Betty the Borzoi", 3, 25, 6, 2}

        'Computers cards:
        cards(3) = {"Charlie the Chihuahua", 2, 30, 2, 2}
        cards(4) = {"Chaz the Cocker Spaniel", 2, 80, 9, 4}
        cards(5) = {"Donald the Dalmatian", 5, 65, 7, 3}

        Dim playerPile As New ArrayList
        Dim computerPile As New ArrayList

        For i = 0 To 2
            playerPile.Add(cards(i))
        Next

        For i = 3 To 5
            computerPile.Add(cards(i))
        Next

        Dim responseCategory As String
        Dim playerStat As Integer
        Dim computerStat As Integer

        Dim allowedResponseCategories As New ArrayList
        allowedResponseCategories.Add("E")
        allowedResponseCategories.Add("I")
        allowedResponseCategories.Add("F")
        allowedResponseCategories.Add("D")

        Console.WriteLine("Welcome to Celebrity Dogs" + vbCrLf)

        Dim firstCardOnPile As Integer
        firstCardOnPile = 0

        Dim currentPlayerCard
        Dim currentComputerCard

        Menu()
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
                        Menu()
                        menuOption = Console.ReadLine().ToUpper
                    End If

                End While

                While playerPile.Count <> 0 Or computerPile.Count <> 0

                    currentPlayerCard = cards(firstCardOnPile)
                    currentComputerCard = cards(firstCardOnPile + 3)

                    Console.WriteLine("Your current card: " + currentPlayerCard(0))
                    Console.WriteLine("Computer's current card: " + currentComputerCard(0))

                    Console.WriteLine("Please enter E (Exercise), I (Intelligence), F (Friendliness),  or D (Drool)")
                    responseCategory = Console.ReadLine().ToUpper

                    If allowedResponseCategories.Contains(responseCategory) = False Then
                        Console.WriteLine("Please enter either E, I, F, D")
                    Else

                        If responseCategory = "E" Then
                            playerStat = playerPile(firstCardOnPile)(1)
                            computerStat = computerPile(firstCardOnPile)(1)


                        ElseIf responseCategory = "I" Then
                            playerStat = playerPile(firstCardOnPile)(2)
                            computerStat = computerPile(firstCardOnPile)(2)


                        ElseIf responseCategory = "F" Then
                            playerStat = playerPile(firstCardOnPile)(3)
                            computerStat = computerPile(firstCardOnPile)(3)


                        ElseIf responseCategory = "D" Then
                            playerStat = playerPile(firstCardOnPile)(4)
                            computerStat = computerPile(firstCardOnPile)(4)
                        End If



                        If responseCategory = "D" Then
                            If playerStat <= computerStat Then
                                Console.WriteLine("You win")
                                playerPile.Remove(currentPlayerCard)
                                computerPile.Remove(currentComputerCard)
                                playerPile.Add(currentPlayerCard)
                                playerPile.Add(currentComputerCard)

                            Else
                                Console.WriteLine("Computer wins")
                                computerPile.Remove(currentComputerCard)
                                playerPile.Remove(currentPlayerCard)
                                computerPile.Add(currentComputerCard)
                                computerPile.Add(currentPlayerCard)
                            End If
                        Else
                            If playerStat >= computerStat Then
                                Console.WriteLine("You win")
                                playerPile.Remove(currentPlayerCard)
                                computerPile.Remove(currentComputerCard)
                                playerPile.Add(currentPlayerCard)
                                playerPile.Add(currentComputerCard)


                            Else
                                Console.WriteLine("Computer wins")
                                computerPile.Remove(currentComputerCard)
                                playerPile.Remove(currentPlayerCard)
                                computerPile.Add(currentComputerCard)
                                computerPile.Add(currentPlayerCard)
                            End If
                        End If

                        firstCardOnPile = firstCardOnPile + 1
                    End If

                    For Each card In playerPile
                        Console.WriteLine(card(0))
                    Next
                    Console.WriteLine("!")
                    For Each card In computerPile
                        Console.WriteLine(card(0))
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