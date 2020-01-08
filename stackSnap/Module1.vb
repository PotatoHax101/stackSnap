﻿Module Module1

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

        Console.ReadLine()

    End Sub

    Function deckCreate()

        Dim deck(52) As card

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

    Sub shuffle()



    End Sub


    Sub handOut()

        Dim playerDeck As Queue = New Queue()
        Dim computerDeck As Queue = New Queue()



    End Sub

    Sub placeCards()



    End Sub

    Function snap()



    End Function

End Module