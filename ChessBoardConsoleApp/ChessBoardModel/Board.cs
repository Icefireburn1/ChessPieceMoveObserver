using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardModel
{
    public class Board
    {


        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }

        public List<string> validPieces;
        public Board(int s)
        {
            Size = s;

            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }

            validPieces = new List<string>();
            validPieces.Add("knight");
            validPieces.Add("king");
            validPieces.Add("rook");
            validPieces.Add("bishop");
            validPieces.Add("queen");
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            // Clear all legal moves from previous turn
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    theGrid[r, c].LegalNextMove = false;
                }
            }
            // Find all legal moves and mark square
            switch (chessPiece)
            {
                case "knight":

                    if (Valid(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1)) theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (Valid(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1)) theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (Valid(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2)) theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    if (Valid(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2)) theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    if (Valid(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1)) theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (Valid(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1)) theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (Valid(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2)) theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    if (Valid(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2)) theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    break;
                case "king":

                    if (Valid(currentCell.RowNumber - 1, currentCell.ColumnNumber)) theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;
                    if (Valid(currentCell.RowNumber + 1, currentCell.ColumnNumber)) theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                    if (Valid(currentCell.RowNumber, currentCell.ColumnNumber - 1)) theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (Valid(currentCell.RowNumber, currentCell.ColumnNumber + 1)) theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    break;

                case "rook":

                    // Max movement our rook can make
                    for (int i = 0; i < Size-1; i++)
                    {
                        if (Valid(currentCell.RowNumber - 1 - i, currentCell.ColumnNumber)) theGrid[currentCell.RowNumber - 1 - i, currentCell.ColumnNumber].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber + 1 + i, currentCell.ColumnNumber)) theGrid[currentCell.RowNumber + 1 + i, currentCell.ColumnNumber].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber, currentCell.ColumnNumber - 1 - i)) theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1 - i].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber, currentCell.ColumnNumber + 1 + i)) theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1 + i].LegalNextMove = true;
                    }
                    break;

                case "bishop":

                    // Max movement our bishop can make
                    for (int i = 0; i < Size - 1; i++)
                    {
                        if (Valid(currentCell.RowNumber - 1 - i, currentCell.ColumnNumber - 1 - i)) theGrid[currentCell.RowNumber - 1 - i, currentCell.ColumnNumber - 1 - i].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber + 1 + i, currentCell.ColumnNumber + 1 + i)) theGrid[currentCell.RowNumber + 1 + i, currentCell.ColumnNumber + 1 + i].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber - 1 - i, currentCell.ColumnNumber + 1 + i)) theGrid[currentCell.RowNumber - 1 - i, currentCell.ColumnNumber + 1 + i].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber + 1 + i, currentCell.ColumnNumber - 1 - i)) theGrid[currentCell.RowNumber + 1 + i, currentCell.ColumnNumber - 1 - i].LegalNextMove = true;
                    }
                    break;

                case "queen":

                    // Max movement our queen can make
                    for (int i = 0; i < Size - 1; i++)
                    {
                        // Diagonals
                        if (Valid(currentCell.RowNumber - 1 - i, currentCell.ColumnNumber - 1 - i)) theGrid[currentCell.RowNumber - 1 - i, currentCell.ColumnNumber - 1 - i].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber + 1 + i, currentCell.ColumnNumber + 1 + i)) theGrid[currentCell.RowNumber + 1 + i, currentCell.ColumnNumber + 1 + i].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber - 1 - i, currentCell.ColumnNumber + 1 + i)) theGrid[currentCell.RowNumber - 1 - i, currentCell.ColumnNumber + 1 + i].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber + 1 + i, currentCell.ColumnNumber - 1 - i)) theGrid[currentCell.RowNumber + 1 + i, currentCell.ColumnNumber - 1 - i].LegalNextMove = true;

                        // Horizontals
                        if (Valid(currentCell.RowNumber - 1 - i, currentCell.ColumnNumber)) theGrid[currentCell.RowNumber - 1 - i, currentCell.ColumnNumber].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber + 1 + i, currentCell.ColumnNumber)) theGrid[currentCell.RowNumber + 1 + i, currentCell.ColumnNumber].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber, currentCell.ColumnNumber - 1 - i)) theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1 - i].LegalNextMove = true;
                        if (Valid(currentCell.RowNumber, currentCell.ColumnNumber + 1 + i)) theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1 + i].LegalNextMove = true;
                    }
                    break;

                default:
                    break;
            }
        }

        private bool Valid(int x, int y)
        {
            if (x >= 0 && x < Size && y >= 0 && y < Size)
                return true;
            else
                return false;
        }
    }
}
