namespace Game.Engine.Model
{
    using System.Collections.Generic;

    internal class Cell
    {
        public Cell(int y, int x, int colourValue)
        {
            this.Y = y;
            this.X = x;
            this.OddColourState = colourValue;
            this.EvenColourState = colourValue;
        }

        public int Y { get; private set; }

        public int X { get; private set; }

        public int OddColourState { get; set; }

        public int EvenColourState { get; set; }

        public List<Cell> Neighbours { get; set; } = new List<Cell>();
    }
}
