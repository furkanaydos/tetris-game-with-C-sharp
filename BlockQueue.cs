using System;

namespace Tetris
{
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[] //array with an instance of the 7 block classes.
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        private readonly Random random = new Random(); //constructor

        public Block NextBlock {  get; private set; } //property

        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        public Block GetAndUpdate() //choosing different blocks
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}
    