namespace Game.Test.Service
{
    using Engine.Service.Implementations;
    using FluentAssertions;
    using Game.Test.MockData;
    using Xunit;

    public class CellActionServiceTest
    {
        [Fact]
        public void AddNeighboursShouldSetThreeNeighboursToCornerCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);

            // Act
            cellActionService.AddNeighbours(grid[0][0]);

            // Assert
            grid[0][0]
                .Neighbours
                .Count
                .Should()
                .Be(3);
        }

        [Fact]
        public void AddNeighboursShouldSetFiveNeighboursToSideCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);

            // Act
            cellActionService.AddNeighbours(grid[0][1]);

            // Assert
            grid[0][1]
                .Neighbours
                .Count
                .Should()
                .Be(5);
        }

        [Fact]
        public void AddNeighboursShouldSetEightNeighboursToMiddleCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);

            // Act
            cellActionService.AddNeighbours(grid[1][2]);

            // Assert
            grid[1][2]
                .Neighbours
                .Count
                .Should()
                .Be(8);
        }

        [Fact]
        public void OddChangeStateShouldSetTheCellCorrectly()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);
            var twoDGridService = new TwoDGridActionService(grid, cellActionService);

            twoDGridService.SetNeighboursToAllCells();

            // Act
            cellActionService.OddChangeState(grid[2][2]);

            // Assert
            grid[2][2]
                .OddColourState
                .Should()
                .Be(0);
        }

        [Fact]
        public void EvenChangeStateShouldSetTheCellCorrectly()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);
            var twoDGridService = new TwoDGridActionService(grid, cellActionService);

            twoDGridService.SetNeighboursToAllCells();

            // Act
            cellActionService.EvenChangeState(grid[2][2]);

            // Assert
            grid[2][2]
                .OddColourState
                .Should()
                .Be(0);
        }
    }
}
