namespace Game.Test.MockData
{
    using Game.Engine.Model;

    public static class MockGrid
    {
        internal static Cell[][] Context()
        {
            var grid = new Cell[4][];
            PopulateData(grid);
            return grid;
        }

        private static Cell[][] GetTestData()
        {
            return new Cell[4][]
            {
                new Cell[]
                {
                    new Cell(0,0,1),
                    new Cell(0,1,0),
                    new Cell(0,2,0),
                    new Cell(0,3,1)
                },
                new Cell[]
                {
                    new Cell(1,0,1),
                    new Cell(1,1,1),
                    new Cell(1,2,1),
                    new Cell(1,3,1)
                },
                new Cell[]
                {
                    new Cell(2,0,0),
                    new Cell(2,1,1),
                    new Cell(2,2,0),
                    new Cell(2,3,0)
                },
                new Cell[]
                {
                    new Cell(3,0,1),
                    new Cell(3,1,0),
                    new Cell(3,2,1),
                    new Cell(3,3,0)
                }
            };
        }

        private static void PopulateData(Cell[][] grid)
        {
            var data = GetTestData();
            for (int row = 0; row < grid.Length; row++)
            {
                for (int itemList = 0; itemList < data.Length; itemList++)
                {
                    grid[itemList] = data[itemList];
                }
            }
        }
    }
}
