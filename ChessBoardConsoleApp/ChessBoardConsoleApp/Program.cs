using ChessBoardModel;
using System;
using System.Diagnostics.Contracts;
using System.Dynamic;

namespace ChessBoardConsoleApp
{
    class Program
    {
        static Board myBoard = new Board(8);
        static void Main(string[] args)
        {
            // show the empty chess board
            printGrid(myBoard);

            // get the location of the chess piece
            Cell myLocation = setCurrentCell();

            // calculate and mark the cells where legal moves are possible
            bool validPiece = false;
            while (!validPiece)
            {
                Console.Write("Which piece do you want to use?: ");
                string piece = Console.ReadLine();
                if (myBoard.validPieces.Contains(piece.ToLower()))
                {
                    myBoard.MarkNextLegalMoves(myLocation, piece.ToLower());
                    validPiece = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid chess piece");
                }
            }


            // show the chess board Use . for an empty square, X for the piece location and + for a possible legal move
            printGrid(myBoard);

            // wait for another return key to end the program
            Console.ReadLine();
        }

        static public void printGrid(Board myBoard)
        {
            // print the board on the console X: Location, +: legal move, .: for an empty square
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j =  0; j < myBoard.Size; j++)
                {
                    Console.Write("+---");

                    // Put finisher
                    if (j == myBoard.Size - 1)
                        Console.Write("+");
                }
                Console.WriteLine();
                for (int j = 0; j < myBoard.Size; j++)
                {

                    if (myBoard.theGrid[i, j].CurrentlyOccupied)
                    {
                        Console.Write("| X ");
                    }
                    else if (myBoard.theGrid[i, j].LegalNextMove)
                    {
                        Console.Write("| + ");
                    }
                    else
                    {
                        Console.Write("|   ");
                    }

                    // Put finisher
                    if (j == myBoard.Size-1)
                        Console.Write("|");
                }
                Console.WriteLine();
            }
            // Add bottom of board
            for (int j = 0; j < myBoard.Size; j++)
            {
                Console.Write("+---");

                // Put finisher
                if (j == myBoard.Size - 1)
                    Console.Write("+");
            }
            Console.WriteLine();
            Console.WriteLine("==========================================");
        }

        static public Cell setCurrentCell()
        {
            int currentRow = -1;
            int currentCol = -1;
            while (currentCol == -1 || currentRow == -1)
            {
                Console.Out.Write("Enter your current row number ");
                if (int.TryParse(Console.ReadLine(), out currentRow))
                {
                    if (currentRow < 0 || currentRow >= myBoard.Size)
                    {
                        Console.WriteLine("Please enter a number between 0 and " + (myBoard.Size - 1));
                        currentRow = -1;
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Error: please enter a number between 0 and " + (myBoard.Size - 1));
                    currentRow = -1;
                    continue;
                }

                Console.Out.Write("Enter your current column number ");
                if (int.TryParse(Console.ReadLine(), out currentCol))
                {
                    if (currentCol < 0 || currentCol >= myBoard.Size)
                    {
                        Console.WriteLine("Please enter a number between 0 and " + (myBoard.Size - 1));
                        currentCol = -1;
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Error: please enter a number between 0 and " + (myBoard.Size - 1));
                    currentCol = -1;
                    continue;
                }
            }

            myBoard.theGrid[currentRow, currentCol].CurrentlyOccupied = true;

            return myBoard.theGrid[currentRow, currentCol];
        }
    }
}
