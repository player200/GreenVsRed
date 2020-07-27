using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Game.Test")]
namespace Game.Engine
{
    using Model;
    using Service;
    using Service.Implementations;
    using System;
    using System.Linq;

    public class Game : IGame
    {
        public void Start()
        {
            var sizeTokensForGrid = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var width = sizeTokensForGrid[0];
            var height = sizeTokensForGrid[1];

            Cell[][] grid = new Cell[height][];
            IGridService gridService = new GridService(grid);
            ICellActionService cellAction = new CellActionService(gridService);
            ITwoDGridActionService gridAction = new TwoDGridActionService(grid, cellAction);

            for (int row = 0; row < height; row++)
            {
                var inputRowValues = Console.ReadLine()
                    .ToCharArray()
                    .Select(x => int.Parse(x.ToString()))
                    .ToArray();

                var gridRow = new Cell[width];
                for (int col = 0; col < inputRowValues.Length; col++)
                {
                    gridRow[col] = new Cell(row, col, inputRowValues[col]);
                }
                gridAction.AddRow(gridRow, row);
            }
            gridAction.SetNeighboursToAllCells();

            var startPointRotationTokens = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var targetX = startPointRotationTokens[0];
            var targetY = startPointRotationTokens[1];
            var generationCount = startPointRotationTokens[2];

            gridAction.SetTargetCell(targetY, targetX);
            gridAction.Generate(generationCount);

            Console.WriteLine(gridAction.GetCountOfTargetBeingGreen());
        }
    }
}
