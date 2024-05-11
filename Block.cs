using System.Collections.Generic;
using System.Reflection;
namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int Id { get; }

        private int rotationState; //0, 1 ,2 ,3 
        private Position offSet;

        public Block()
        {
            offSet = new Position(StartOffset.Row, StartOffset.Column);

        }

        public IEnumerable<Position> TilePosition() // calculates and returns positions at the current location of the block.
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offSet.Row, p.Column + offSet.Column); //yield is used to temporarily return a value in a method loop or iterations.

            }
        }

        public void RotateCW() //clockwise
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCCW() //counter clockwise
        {
            if(rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }

            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int colums)
        {
            offSet.Row += rows ;
            offSet.Column += colums ;
        }

        public void Reset()
        {
            rotationState = 0;
            offSet.Row = StartOffset.Row;
            offSet.Column = StartOffset.Column;

        }
    }
}
