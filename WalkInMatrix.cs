using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    public class WalkInMatrix
    {
        private readonly int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private readonly int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        private int[,] matrix;
        private int currRow = -1;
        private int currCol = -1;
        private int currDirectionIndex = 0;
       
        public int Size
        {
            get 
            {
                return this.matrix.GetLength(0);
            }
        }

        public bool IsFull
        {
            get
            {
                for (int row = 0; row < this.Size; row++)
                {
                    for (int col = 0; col < this.Size; col++)
                    {
                        if (this[row, col] == 0)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }
        
        public int this[int row, int col]
        {
            get 
            {
                if (!IsMatrixIndexInBounds(row, col))
                {
                    throw new ArgumentOutOfRangeException("Index outside the bounds of the matrix!");
                }

                return matrix[row, col];
            }
            set 
            {
                if (!IsMatrixIndexInBounds(row, col))
                {
                    throw new ArgumentOutOfRangeException("Index outside the bounds of the matrix!");
                }

                this.matrix[row, col] = value;
            }
        }

        public WalkInMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Matrix size should be a positive number!");
            }

            this.matrix = new int[size, size];
        }

        public void FillMatrix()
        {
            int value = 1;

            while(!this.IsFull)
            {
                SetNextFreeCellAsCurrent();
                
                this[currRow, currCol] = value;
                
                value++;
            }            
        }

        public bool IsMatrixIndexInBounds(int row, int col)
        {
            if ((row < 0 || row >= this.Size) || (col < 0 || col >= this.Size))
            {
                return false;
            }

            return true;
        }

        private void SetNextFreeCellAsCurrent()
        {
            if (SetNextCellByDirectionAsCurrent() == false)
            {
                SetFirstFreeCellAsCurrent();
            }
        }

        private void SetFirstFreeCellAsCurrent()
        {
            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    if (this[row, col] == 0)
                    {
                        currRow = row;
                        currCol = col;
                        currDirectionIndex = 0;
                    }
                }
            }
            return;
        }
        
        private bool SetNextCellByDirectionAsCurrent()
        {
            bool isSet = false;

            for (int i = currDirectionIndex; i < 8; i++)
            {
                if (IsMatrixIndexInBounds(currRow + directionX[i], currCol + directionY[i]))
                {
                    if (this[currRow + directionX[i], currCol + directionY[i]] == 0)
                    {
                        currRow += directionX[i];
                        currCol += directionY[i];
                        currDirectionIndex = i;
                        isSet = true;
                        break;
                    }
                }
            }

            if (!isSet)
            {
                for (int i = 0; i < currDirectionIndex; i++)
                {
                    if (IsMatrixIndexInBounds(currRow + directionX[i], currCol + directionY[i]))
                    {
                        if (this[currRow + directionX[i], currCol + directionY[i]] == 0)
                        {
                            currRow += directionX[i];
                            currCol += directionY[i];
                            currDirectionIndex = i;
                            isSet = true;
                            break;
                        }
                    }
                }
            }

            return isSet;
        }

        private void SetDirectionIndex()
        {
        }

        public override string ToString()
        {
            StringBuilder matrixString = new StringBuilder();

            for (int row = 0; row < this.Size; row++)
            {
                for (int col = 0; col < this.Size; col++)
                {
                    matrixString.AppendFormat("{0,3}", this[row, col]);
                }
                matrixString.Append(Environment.NewLine);
            }

            return matrixString.ToString();
        }
    }
}
