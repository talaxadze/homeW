            //tic tac toe (იქსიკი და ნოლიკი) თამაში
            //1. შექმენით კონსოლური აპლიკაციის პროექტი
            //2. დააინიცირეთ სათამაშო მაგიდა. გამოიყენეთ ორ განზომილებიანი მასივი 3x3 ზე
            //3. შექმენით სათამაშოდ საჭირო ცვლადები, მაგ .:
            //char currentPlayer = 'X';
            //int row, col; // მოთამაშის არჩეული სვეტისა და სტრიქონის შესანახად
            //bool isGameOver = false; // თამაშის ციკლის საკონტროლებლად
            //int movesCount = 0; // სვლების ჯამის დასათვლელად

            //4.შექმენით თამაშის ციკლი
            //5. გაასუფთავეთ კონსოლი და დახატეთ სათამაშო მაგიდა
            //* Console.Clear() ასუფთავებს კონსოლს
            //* ციკლების დახმარებით შეგიძლიათ ლამაზად დახატოთ სათამაშო მაგიდა
            //6. შეაყვანინეთ მოთამაშეს მისი არჩეული სვლის სტრიქონი და სვეტი. მაგალითად
            //   0   1   2
            //  -----------
            //0 |   |   |   |
            //  -----------
            //1 |   |   |   |
            //  -----------
            //2 |   |   |   |
            //  -----------

            //ამ ბორდზე თუ პირველ უჯრაში ენდომება მოთამაშეს X ის ჩაწერა შეიყვანს 0 სვეტის მნიშვნელბისთვის და 0 სტრიქონისთვის
            //7. დაავალიდირეთ მომხმარებლის შემოტანილი მნიშვნელობები, თუ შეცდომით ჩაწერა რამე თავიდან შეაყვანინეთ
            //8. მომხმარებლის ინფუთს რომ მიიღებთ განაახლეთ სათამაშო მაგიდის (ორ განზომილებიანი მასივის) შესაბამისი მნიშვნელობები
            //9. ამის შემდეგ შეამოწმეთ ვინმემ ხომ არ მოიგო
            //* შეამოწმეთ სვეტებში თუა სამი ერთიდაიგივე მოთამაშის ჩანაწერი (მაგ X)
            //* შეამოწმეთ იგივე სტრიქონებზე
            //* შეამოწმეთ იგივე დიაგონალებზე

            //10. იმისდა მიხედვით ვინმემ მოიგო, თუ თამაშის სვლები ამოიწურა დაასრულეთ თამაში და დაბეჭდეთ შესაბამისი ინფორმაცია. თუ ჯერ არავის მოუგია ვაგრძელებთ.
            //11. თუ თამაში გრძელდება ესეიგი პირველმა მოთამაშემ დაასრულა სვლა და მეორეს ჯერია ანუ უნდა შევცვალოთ მოთამაშე
            //12. დავასრულოთ თამაში.


using System;

class Program
{
    static char[,] board = new char[3, 3];
    static char currentPlayer = 'X';
    static int movesCount = 0;
    static bool isGameOver = false;

    static void Main(string[] args)
    {
        InitializeBoard();

        while (!isGameOver)
        {
            Console.Clear();
            DrawBoard();
            PlayerMove();
            CheckForWinner();

            if (!isGameOver)
                SwitchPlayer();
        }

        Console.Clear();
        DrawBoard();
        Console.WriteLine("The game is over!");
        if (movesCount == 9)
            Console.WriteLine("It's a draw!");
    }


    static void InitializeBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = ' ';
            }
        }
    }


    static void DrawBoard()
    {
        Console.WriteLine("   0   1   2 ");
        Console.WriteLine("  -----------");
        for (int row = 0; row < 3; row++)
        {
            Console.Write(row + " | ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write(board[row, col]);
                if (col < 2)
                    Console.Write(" | ");
            }
            Console.WriteLine(" |");
            if (row < 2)
                Console.WriteLine("  -----------");
        }
    }

    static void PlayerMove()
    {
        int row, col;
        bool isValidMove = false;

        while (!isValidMove)
        {
            Console.WriteLine($"Player {currentPlayer}'s turn");
            Console.Write("Enter column (0-2): ");
            col = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter row (0-2): ");
            row = Convert.ToInt32(Console.ReadLine());

            if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                isValidMove = true;
                movesCount++;
            }
            else
            {
                Console.WriteLine("Invalid move! Try again.");
            }
        }
    }


    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    static void CheckForWinner()
    {

        if (CheckRows() || CheckColumns() || CheckDiagonals())
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine($"Player {currentPlayer} wins!");
            isGameOver = true;
        }
        else if (movesCount == 9)
        {
            isGameOver = true;
        }
    }

    static bool CheckRows()
    {
        for (int row = 0; row < 3; row++)
        {
            if (board[row, 0] == currentPlayer && board[row, 1] == currentPlayer && board[row, 2] == currentPlayer)
                return true;
        }
        return false;
    }

    static bool CheckColumns()
    {
        for (int col = 0; col < 3; col++)
        {
            if (board[0, col] == currentPlayer && board[1, col] == currentPlayer && board[2, col] == currentPlayer)
                return true;
        }
        return false;
    }

    static bool CheckDiagonals()
    {
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            return true;
        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            return true;

        return false;
    }
}
