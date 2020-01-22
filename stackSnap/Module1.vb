Module Module1

    Sub Main()

        While True

            Console.WriteLine("Welcome to stackSnap!")
            Dim cards() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}

            Dim shuffleDeck(51) As Integer 'Creates deck in preperation for shuffling

            shuffleDeck = deckCreate(cards) 'Shuffling deck

            Console.WriteLine("We made it out alive!")

            handOut(shuffleDeck) 'Handing out cards

        End While

    End Sub

    Sub randomTest()

        Dim r As Random = New Random

        Dim rand

        Dim randTable(51) As Integer

        For i = 0 To 51

            rand = r.Next(i)

            If rand = randTable(i) Then

                rand = sortRandom(randTable(i), rand)

            End If


        Next

        Array.Sort(randTable)

        For i = 0 To 51

            If randTable(i) = randTable(i + 1) Then

                rand = sortRandom(randTable(i + 1), randTable(i))

            End If

            Console.WriteLine(randTable(i))

        Next

    End Sub

    Function sortRandom(ByVal arrayIndex As Integer, ByVal value As Integer)

        While value = arrayIndex

            value += 1

        End While

        Return value

    End Function

    Function deckCreate(ByVal cards() As Integer)

        Console.WriteLine("Creating deck")

        Dim shuffle(cards.Length - 1) As Integer
        Dim q As Random = New Random
        Dim r As Integer
        Dim count As Integer = 0

        While count < 52

            r = q.Next(0, 52) 'Generates a random number between 0 and 51

            If cards(r) <> 15 Then 'if the random index of the original deck is not set to 15

                shuffle(count) = cards(r) 'the count index of shuffle is assigned the integer of the random index
                cards(r) = 15
                count = count + 1

            End If

        End While

        Console.WriteLine("Deck successfully created and loaded")

        Return shuffle

    End Function


    Sub handOut(ByVal shuffleDeck() As Integer)

        Console.WriteLine("Handing out cards")

        'Creating new stack for both players

        Dim player1Deck As Stack(Of Integer) = New Stack(Of Integer)

        Dim player2Deck As Stack(Of Integer) = New Stack(Of Integer)

        For i = 0 To 50 Step 2 'Distributing cards equally between people

            player1Deck.Push(shuffleDeck(i)) 'player 1 pushed with i index in shuffleDeck
            Console.WriteLine(player1Deck.Peek)
            player2Deck.Push(shuffleDeck(i + 1)) 'player 2 gets the i + 1 index in shuffleDeck
            Console.WriteLine(player2Deck.Peek)

        Next

        Console.WriteLine("Cards handed out")

        placeCards(player1Deck, player2Deck) 'The main game

    End Sub

    Sub placeCards(ByRef player1Deck As Stack(Of Integer), ByRef player2Deck As Stack(Of Integer))

        Dim cardDeposit As Stack(Of Integer) = New Stack(Of Integer) 'Creating a card deposit where cards are placed

        Console.WriteLine("Going into the game")

        Console.WriteLine("Player 1 has placed a card") 'Starting with player 1 out of the while so there is a card to compare
        cardDeposit.Push(player1Deck.Pop)
        Dim previousPlacement As Integer = cardDeposit.Peek
        Console.WriteLine("The card is: " & previousPlacement)


        While (player1Deck.Count > 0) And (player2Deck.Count > 0)

            Console.WriteLine("Player 2 has placed a card!")
            previousPlacement = PlacementAction(player2Deck, player1Deck, previousPlacement, cardDeposit)

            Console.WriteLine("Player 1 has placed a card!")
            previousPlacement = PlacementAction(player1Deck, player2Deck, previousPlacement, cardDeposit)

        End While

    End Sub
    Function PlacementAction(ByRef firstDeck As Stack(Of Integer), ByRef secondDeck As Stack(Of Integer), ByRef previousPlacement As Integer, ByRef cardDeposit As Stack(Of Integer))

        Dim chosenCard As Integer = firstDeck.Peek 'Chosen card defined so it can be compared to the previous placement

        cardDeposit.Push(firstDeck.Pop) 'Placing card in deposit

        Console.WriteLine("The card being placed is " & chosenCard & ", the card previously placed was " & previousPlacement)

        Dim CardCheckBool As Boolean = CardCheck(chosenCard, previousPlacement) 'Checking if the chosen card is identical to the previous card

        If CardCheckBool = True Then

            snapState(True, firstDeck, secondDeck, cardDeposit)

        Else

            snapState(False, firstDeck, secondDeck, cardDeposit)

        End If

        Return chosenCard

    End Function

    Function CardCheck(ByVal chosenCard As Integer, ByVal previousCard As Integer)

        If chosenCard = previousCard Then

            Return True

        Else

            Return False

        End If

    End Function

    Sub snapState(ByVal bool As Boolean, ByRef player1Deck As Stack(Of Integer), ByRef player2Deck As Stack(Of Integer), ByRef PlacedDeck As Stack(Of Integer))

        Dim Deposit As Stack(Of Integer) = New Stack(Of Integer)

        Dim player1Snap As Integer = 83 'Ascii code of player 1 snap key (s)
        Dim player2Snap As Integer = 80 'Ascii code of player 2 snap key (p)
        Dim skipSnap As Integer = 13 'Ascii code of continue key (enter)

        Console.WriteLine("To snap, player 1 press 's', player 2 press 'p', or press enter to skip")

        Dim keyPress As Integer = Console.ReadKey().Key

        Console.WriteLine(keyPress)

        If keyPress = player1Snap Then

            If bool <> False Then

                Console.WriteLine("Player1 Wins the Snap!")

                JackPot(PlacedDeck, Deposit, player1Deck) 'Giving winner all cards from the deposit

            End If

        ElseIf keyPress = player2Snap Then

            If bool <> False Then

                Console.WriteLine("Player2 Wins the Snap!")

                JackPot(PlacedDeck, Deposit, player2Deck)

            End If

        Else

            Console.WriteLine("No snapping this round!")

        End If

    End Sub

    Sub JackPot(ByRef placedStack As Stack(Of Integer), ByRef Deposit As Stack(Of Integer), ByRef winnerPlayer As Stack(Of Integer))

        push(placedStack, Deposit) 'Getting pool of placed cards into the deposit for the winner player
        push(winnerPlayer, Deposit) 'Getting deck of player cards into the deposit for the winner player

        push(Deposit, winnerPlayer) 'Placing all cards from the deposit into the winner player's deck

    End Sub

    Sub push(ByRef stackPop As Stack(Of Integer), ByRef stackPush As Stack(Of Integer))

        For i = 1 To stackPop.Count

            stackPush.Push(stackPop.Pop)

        Next

    End Sub

End Module