// See https://aka.ms/new-console-template for more information

TicTacToe luffarschack = new TicTacToe();




public class TicTacToe
{
    public TicTacToe()
    {
        PrintBoard();
    }

    //private int counter = 0;
    private char[,] board = new char[5, 5]
    {
    {'*','1','2','3','*'},
    {'A','_','_','_','*'},
    {'B','_','_','_','*'},
    {'C','_','_','_','*'},
    {'*','*','*','*','*' }
    };

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

    public void play()
    {
        bool isDone = false;
        int counter = 0;
        var coordinates = new Dictionary<char, int>()
        {
            {'A', 1},
            {'B', 2},
            {'C', 3}
        };

        while (isDone == false)
        {
            if { (counter % 2) == 0}
            
            Console.Write("Ange var du vill placera ditt 'x' (t.ex. A2): ");
            string input = Console.ReadLine();
            char tmp = input[0].ToUpper;
            int result;
            if (coordinates.TryGetValue(tmp, out result))
            { //sätt in result i en char[] med 2 platser som sedan utgör kordinaterna.
                counter += 1;
            }
            else
                    //Felmedelande och continue för att göra om

            
        }
    }

}

