// See https://aka.ms/new-console-template for more information

TicTacToe luffarschack = new TicTacToe();



public class TicTacToe
{
    public TicTacToe()
    {
        Console.WriteLine("Luffarschack - tre i rad vinner!\n");
        PrintBoard();
        Play();
    }

    private int counter = 0;
    private string[,] board = new string[5, 5]
    {
    {" * "," 1 "," 2 "," 3 "," * "},
    {" A ","   ","   ","   "," * "},
    {" B ","   ","   ","   "," * "},
    {" C ","   ","   ","   "," * "},
    {" * "," * "," * "," * "," * "}
    };

    private string playerOne = " X ";
    private string playerTwo = " O ";


    public string[,] Board
    { get => board;
        private set { }
    }

    
    private void Refresh()
    {
        for (int row = 1; row < 4; row++)
        {
            for (int col = 1; col < 4; col++)
            {
                
                Board.SetValue("   ", row, col);
            }
        }
    }

    private void PrintBoard()
    {
        Console.WriteLine();
        for (int i = 0; i < Board.GetLength(0); i++)
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                Console.Write(Board[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        
    }

    public void Play()
    {
        bool isDone = false;
        

        while (isDone == false)
        {
            if ((counter % 2) == 0)
            {
                isDone = MakeMoves(1, playerOne);
            }
            else
            {
                isDone = MakeMoves(2, playerTwo);
            }
        }

        if (isDone)
        {
            bool fail = true;
            while (fail)
            {
                string input;
                Console.WriteLine("1 - Spela igen\n2 - Avsluta\n");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        fail = false;
                        Refresh();
                        PrintBoard();
                        Play();
                        break;
                    case "2":
                        fail = false;
                        break;
                    default:
                        fail = true;
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }

        }
    }

    public bool MakeMoves(int playerNo, string marker)
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
        Console.Write($"Spelare {playerNo}, ange var du vill placera ditt {marker} (t.ex. A2): ");
        string input = Console.ReadLine();
        char tmp = char.ToUpper(input[0]);
        string tmp2 = Convert.ToString(input[1]);
        int[] move = new int[2];
        if ((coordinates.TryGetValue(tmp, out move[0])) && (int.TryParse(tmp2, out move[1])))
        {
                if (Board[move[0], move[1]].Equals("   "))
                {
                    Board[move[0], move[1]] = marker;
                    //ritar ut markören på spelplanen
                    counter += 1;
                    PrintBoard();
                    hasWon = HasWon(marker, move);
                    fail = false;
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
            Console.WriteLine($"Grattis spelare {playerNo}! Du vann!");
            return true;
        }
        else if (counter == 9)
        {
            Console.WriteLine("Oavgjort!");
            return true;
        }
        return false;

    }

    private bool HasWon(string marker, int[] c)
    {
        string topLeft = Board[1, 1];
        string top = Board[1, 2];
        string topRight = Board[1, 3];
        string middleLeft = Board[2, 1];
        string middle = Board[2, 2];
        string middleRight = Board[2, 3];
        string bottomLeft = Board[3, 1];
        string bottom = Board[3, 2];
        string bottomRight = Board[3, 3];


        switch (c[0])
        {
            case 1:
                switch (c[1])
                {
                    case 1:
                        return ((marker.Equals(top) && top.Equals(topRight)) || (marker.Equals(middle) && middle.Equals(bottomRight)) || (marker.Equals(middleLeft) && middleLeft.Equals(bottomLeft)));
                    case 2:
                        return ((marker.Equals(topLeft) && topLeft.Equals(topRight)) || (marker.Equals(middle) && middle.Equals(bottom)));
                    case 3:
                        return ((marker.Equals(topLeft) && topLeft.Equals(top)) || (marker.Equals(middle) && middle.Equals(bottomLeft)) || (marker.Equals(middleRight) && middleRight.Equals(bottomRight)));
                    default:
                        return false;
                }
                break;
            case 2:
                switch (c[1])
                {
                    case 1:
                        return ((marker.Equals(middle) && middle.Equals(middleRight)) || (marker.Equals(topLeft) && topLeft.Equals(bottomLeft)));
                    case 2:
                        return ((marker.Equals(middleLeft) && middleLeft.Equals(middleRight)) || (marker.Equals(topLeft) && topLeft.Equals(bottomRight)) || (marker.Equals(topRight) && topRight.Equals(bottomLeft)) || (marker.Equals(top) && top.Equals(bottom)));
                    case 3:
                        return ((marker.Equals(middle) && middle.Equals(middleLeft)) || (marker.Equals(topRight) && topRight.Equals(bottomRight)));
                    default:
                        return false;
                }
            case 3:
                switch (c[1])
                {
                    case 1:
                        return ((marker.Equals(bottom) && bottom.Equals(bottomRight)) || (marker.Equals(middle) && middle.Equals(topRight)) || (marker.Equals(middleLeft) && middleLeft.Equals(topLeft)));
                    case 2:
                        return ((marker.Equals(bottomLeft) && bottomLeft.Equals(bottomRight)) || (marker.Equals(middle) && middle.Equals(top)));
                    case 3:
                        return ((marker.Equals(bottom) && bottom.Equals(bottomLeft)) || (marker.Equals(middle) && middle.Equals(topLeft)) || (marker.Equals(middleRight) && middleRight.Equals(topRight)));
                    default:
                        return false;
                }
            default:
                return false;
                break;
        }

    }

}

