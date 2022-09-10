// See https://aka.ms/new-console-template for more information

TicTacToe luffarschack = new TicTacToe();

luffarschack.Play();



public class TicTacToe
{
    public TicTacToe()
    {
        PrintBoard();
    }

    private int counter = 0;
    private char[,] board = new char[5, 5]
    {
    {'*','1','2','3','*'},
    {'A',' ',' ',' ','*'},
    {'B',' ',' ',' ','*'},
    {'C',' ',' ',' ','*'},
    {'*','*','*','*','*' }
    };
    private char playerOne = 'X';
    private char playerTwo = 'O';

    public char[,] Board
    { get => board;
        private set { }
    }
   

    public void PrintBoard()
    {
        for (int i = 0; i < Board.GetLength(0); i++)
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                Console.Write(Board[i, j]);
            }
            Console.WriteLine();
        }
    }

    public void Play()
    {
        bool isDone = false;
        

        while (isDone == false)
        {
            if ((counter % 2) == 0)
            {
                MakeMoves(playerOne);
            }
            else
            {
                MakeMoves(playerTwo);
            }
        }
    }

    public void MakeMoves(char marker)
    {
        bool fail = false;
        bool hasWon = false;

        var coordinates = new Dictionary<char, int>()
        {
            {'A', 1},
            {'B', 2},
            {'C', 3}
        };

        do
        {
        Console.Write($"Ange var du vill placera ditt {marker} (t.ex. A2): ");
        string input = Console.ReadLine();
        char tmp = char.ToUpper(input[0]);
        string tmp2 = Convert.ToString(input[1]);
        int[] result = new int[2];
        if ((coordinates.TryGetValue(tmp, out result[0])) && (int.TryParse(tmp2, out result[1])))
        {
                if (Board[result[0], result[1]].Equals(' '))
                {
                    Board[result[0], result[1]] = marker;
                    //ritar ut markören på spelplanen
                    counter += 1;
                    PrintBoard();
                    hasWon = HasWon(marker, result);
                }
                else
                {
                    Console.WriteLine("Välj en position som inte redan är tagen. Försök igen.");
                    fail = true;
                }
        }
        else
        {
            Console.WriteLine("Ange koordinater i rätt format. Försök igen.");
                fail = true;
        }
        } while (fail);
        if (hasWon)
        {
            Console.WriteLine("Grattis! Du vann!");
            Environment.Exit(0);
        }

    }

    private bool HasWon(char marker, int[] c)
    {
        char topLeft = Board[1, 1];
        char top = Board[1, 2];
        char topRight = Board[1, 3];
        char middleLeft = Board[2, 1];
        char middle = Board[2, 2];
        char middleRight = Board[2, 3];
        char bottomLeft = Board[3, 1];
        char bottom = Board[3, 2];
        char bottomRight = Board[3, 3];


        switch (c[0])
        {
            case 1:
                switch (c[1])
                {
                    case 1:
                        return ((marker.Equals(top) && top.Equals(topRight)) || (marker.Equals(middle) && middle.Equals(bottomRight)));
                    case 2:
                        return (marker.Equals(topLeft) && topLeft.Equals(topRight));
                    case 3:
                        return ((marker.Equals(topLeft) && topLeft.Equals(top)) || (marker.Equals(middle) && middle.Equals(bottomLeft)));
                    default:
                        return false;
                }
                break;
            case 2:
                switch (c[1])
                {
                    case 1:
                        return (marker.Equals(middle) && middle.Equals(middleRight));
                    case 2:
                        return ((marker.Equals(middleLeft) && middleLeft.Equals(middleRight)) || (marker.Equals(topLeft) && topLeft.Equals(bottomRight)) || (marker.Equals(topRight) && topRight.Equals(bottomLeft)));
                    case 3:
                        return (marker.Equals(middle) && middle.Equals(middleLeft));
                    default:
                        return false;
                }
            case 3:
                switch (c[1])
                {
                    case 1:
                        return ((marker.Equals(bottom) && bottom.Equals(bottomRight)) || (marker.Equals(middle) && middle.Equals(topRight)));
                    case 2:
                        return (marker.Equals(bottomLeft) && bottomLeft.Equals(bottomRight));
                    case 3:
                        return ((marker.Equals(bottom) && bottom.Equals(bottomLeft)) || (marker.Equals(middle) && middle.Equals(topLeft)));
                    default:
                        return false;
                }
            default:
                return false;
                break;
        }

    }

}

