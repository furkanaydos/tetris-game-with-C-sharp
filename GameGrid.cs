 namespace Tetris
{
    public class GameGrid //two dimensional rectangular array.
    {
        private readonly int[,] grid; //readonly prevents modification outside the class.
        public int Rows { get; }    //Rows and Columns are properties.
        public int Columns { get; }

        public int this[int r, int c] //indexer provides easy access to to the array. 
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int rows, int columns) //Constructor will take the num of rows and columns as parameters.
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        public bool IsInside(int r, int c) //checks  if a given rows and columns is inside the grid or not.
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        public bool IsEmpty(int r, int c) //checks if a given cell is empty or not.
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        public bool IsRowFull(int r) //checks if an entire row is full.
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsRowEmpty(int r) //checks if an row is empty.
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void CleareRow(int r) //clear the row if it is full.
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        private void MoveRowDown(int r, int numRows) //moves a row down by a certain numbers of rows. 
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    CleareRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }
            return cleared;
        }
    }
}
