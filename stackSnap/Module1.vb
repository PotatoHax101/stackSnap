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

        For i = 1 To 4

            For v = 1 To 13

                deck((i * v) - 1) = New card
                deck((i * v) - 1).FaceUp = False
                deck((i * v) - 1).suit = i - 1
                deck((i * v) - 1).cardNum = v

                'Console.WriteLine(i & " x " & v & " = " & i * v)

                Console.WriteLine("Card " & deck((i * v) - 1).cardNum & " in suit " & deck((i * v) - 1).suit.ToString)

            Next

        Next

        Return deck

    End Function

    Function shuffle(ByVal deck() As card)

        Dim shuffledDeck() As card = deck

        Dim rand = New Random()

        Console.WriteLine("")

        For i = 0 To deck.Length - 1

            Dim n = rand.Next(i + 1)
            Console.WriteLine("n is: " & n)

            Dim temp = deck(i)
            Console.WriteLine("Temp is: " & temp.cardNum & " in suit " & temp.suit.ToString)
            deck(i) = shuffledDeck(n)
            Console.WriteLine("Deck(n) is: " & deck(n).cardNum & " in suit " & deck(n).suit.ToString)
            shuffledDeck(n) = temp

            Console.WriteLine("Card " & deck((i)).cardNum & " in suit " & deck((i)).suit.ToString)

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