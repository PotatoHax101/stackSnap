Module Module1

    Sub Main()

        ' randomTest()
        Dim cards() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}

        Dim key As Integer = Console.ReadKey().Key

        Console.WriteLine(key)

        Console.ReadLine()

        Dim shuffleDeck() As Integer = deckCreate(cards)

        handOut(shuffleDeck)

        Console.ReadLine()

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

    Function deckCreate(ByRef cards() As Integer)

        Dim shuffle(cards.Length) As Integer

        Dim count As Integer = 0
        Dim r As Integer

        Dim rand = New Random()

        Do

            r = rand.Next(51)

            While cards(r) <> -1

                shuffle(r) = cards(r)
                cards(r) = -1
                count += 1
                Console.WriteLine(shuffle(r))

            End While

        Loop While count < shuffle.Length

        Return shuffle

    End Function


    Sub handOut(ByVal shuffleDeck() As Integer)

        Dim player1Deck As Stack(Of Integer) = New Stack(Of Integer)
        Dim player2Deck As Stack(Of Integer) = New Stack(Of Integer)

        For i = 0 To 50 Step 2

            player1Deck.Push(shuffleDeck(i))
            player2Deck.Push(shuffleDeck(i + 1))

        Next

        placeCards(player1Deck, player2Deck)

    End Sub

    Sub placeCards(ByRef player1Deck As Stack(Of Integer), ByRef player2Deck As Stack(Of Integer))

        Dim cardDeposit As Stack(Of Integer) = New Stack(Of Integer)

        cardDeposit.Push(player1Deck.Pop)
        Dim previousPlacement As Integer = cardDeposit.Peek

        Do

            PlacementAction(player2Deck, player1Deck, previousPlacement, cardDeposit)
            PlacementAction(player1Deck, player2Deck, previousPlacement, cardDeposit)

        Loop While (player1Deck.Count > 0 And player2Deck.Count > 0) Or (player1Deck.Count > 0 And player2Deck.Count <= 0) Or (player1Deck.Count <= 0 And player2Deck.Count > 0)

    End Sub

    Function PlacementAction(ByRef firstDeck As Stack(Of Integer), ByRef secondDeck As Stack(Of Integer), ByRef previousPlacement As Integer, ByRef cardDeposit As Stack(Of Integer))

        Dim chosenCard As Integer = firstDeck.Peek
        cardDeposit.Push(firstDeck.Pop)

        Console.WriteLine("The card being placed is " & chosenCard & ", the card previously placed was " & previousPlacement)

        Dim CardCheckBool As Boolean = CardCheck(chosenCard, previousPlacement)

        previousPlacement = chosenCard

        If CardCheckBool = True Then

            snapState(True, firstDeck, secondDeck, cardDeposit)

        Else

            snapState(False, firstDeck, secondDeck, cardDeposit)

        End If

    End Function

    Function CardCheck(ByVal chosenCard As Integer, ByVal previousCard As Integer)

        If chosenCard = previousCard Then

            Return True

        Else

            Return False

        End If

    End Function

    Function snapState(ByVal bool As Boolean, ByRef player1Deck As Stack(Of Integer), ByRef player2Deck As Stack(Of Integer), ByRef PlacedDeck As Stack(Of Integer))

        Dim Deposit As Stack(Of Integer) = New Stack(Of Integer)

        Dim player1Snap As Integer = 80
        Dim player2Snap As Integer = 83
        Dim skipSnap As Integer = 13

        Dim keyPress As Integer = Console.ReadKey().Key

        If keyPress = player1Snap Then

            If bool <> False Then

                Console.WriteLine("Player1 Wins the Snap!")

                'JackPot(PlacedDeck, )

            End If

        ElseIf keyPress = player2Snap Then

            If bool <> False Then

                Console.WriteLine("Player2 Wins the Snap!")

            End If

        Else



        End If

    End Function

    Sub JackPot(ByRef placedStack As Stack(Of Integer), ByRef Deposit As Stack(Of Integer), ByRef winnerPlayer As Stack(Of Integer))

        push(placedStack, Deposit)
        push(winnerPlayer, Deposit)

        push(Deposit, winnerPlayer)

    End Sub

    Sub push(ByRef stackPop As Stack(Of Integer), ByRef stackPush As Stack(Of Integer))

        For i = 1 To stackPop.Count

            stackPush.Push(stackPop.Pop)

        Next

    End Sub

End Module