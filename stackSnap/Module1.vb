Module Module1

    Enum suitType

        clubs
        diamonds
        hearts
        spades

    End Enum

    Structure card

        Dim FaceUp As Boolean
        Dim suit As suitType
        Dim cardNum As Integer

    End Structure

    Sub Main()

        Dim deck() As card = deckCreate()

        Dim placedStk As Stack = New Stack()

        shuffle(deck)

        Console.ReadLine()

    End Sub

    Function deckCreate()

        Dim deck(51) As card

        Dim clubs(13), diamonds(13), hearts(13), spades(13) As card

        For i = 1 To 4

            'Allocate()

        Next

        Return deck

    End Function

    Sub Allocate(ByRef array() As card, ByVal i As Integer)

        For q = 1 To 13

            array((q) - 1) = New card
            array((q) - 1).FaceUp = False
            array((q) - 1).suit = i - 1
            array((q) - 1).cardNum = q

        Next

    End Sub

    Function shuffle(ByVal deck() As card)

        Dim shuffledDeck() As card = deck

        Dim rand = New Random()

        Dim n As Integer
        Dim temp

        Console.WriteLine("")

        For i = 1 To 4

            For v = 1 To 13

                n = rand.Next((v * i) - 1)

                temp = shuffledDeck((i * v) - 1)
                shuffledDeck((i * v) - 1) = shuffledDeck(n)
                shuffledDeck(n) = temp

                Console.WriteLine("Card " & shuffledDeck((i * v) - 1).cardNum & " in suit " & shuffledDeck((i * v) - 1).suit.ToString)

            Next

        Next

        Return shuffledDeck

    End Function


    Sub handOut()

        Dim playerDeck As Queue = New Queue()
        Dim computerDeck As Queue = New Queue()



    End Sub

    Sub placeCards()



    End Sub

    Function snap()



    End Function

End Module