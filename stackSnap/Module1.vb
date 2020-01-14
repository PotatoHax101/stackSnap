Module Module1

    Sub Main()

        ' randomTest()
        Dim cards() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}

        Dim shuffleDeck() As Integer = deckCreate(cards)

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



    End Sub

    Sub placeCards()

        Dim cardDeposit As Stack(Of Integer) = New Stack(Of Integer)

    End Sub

    Function snap()

        Dim Deposit As Stack(Of Integer) = New Stack(Of Integer)

    End Function

End Module