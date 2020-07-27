namespace Game.Engine.Service.Implementations
{
    using Model;

    internal class GridService : IGridService
    {
        private readonly Cell[][] _grid;

        public GridService(Cell[][] grid)
        {
            this._grid = grid;
        }

        public Cell FindUpRigthNeighbour(int y, int x)
        {
            return this._grid[y - 1][x + 1];
        }

        public Cell FindUpNeighbour(int y, int x)
        {
            return this._grid[y - 1][x];
        }

        public Cell FindUpLeftNeighbour(int y, int x)
        {
            return this._grid[y - 1][x - 1];
        }

        public Cell FindLeftNeighbour(int y, int x)
        {
            return this._grid[y][x - 1];
        }

        public Cell FindDownLeftNeighbour(int y, int x)
        {
            return this._grid[y + 1][x - 1];
        }

        public Cell FindDownNeighbour(int y, int x)
        {
            return this._grid[y + 1][x];
        }

        public Cell FindDownRigthNeighbour(int y, int x)
        {
            return this._grid[y + 1][x + 1];
        }

        public Cell FindRigthNeighbour(int y, int x)
        {
            return this._grid[y][x + 1];
        }

        public int GetHeight()
        {
            return this._grid.Length;
        }

        public int GetWidth(int y)
        {
            return this._grid[y].Length;
        }
    }
}
