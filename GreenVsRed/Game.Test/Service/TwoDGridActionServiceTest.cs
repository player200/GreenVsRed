namespace Game.Test.Service
{
    using Engine.Model;
    using Engine.Service.Implementations;
    using FluentAssertions;
    using Game.Test.MockData;
    using System;
    using Xunit;

    public class TwoDGridActionServiceTest
    {
        [Fact]
        public void SetNeighboursToAllCellsShouldSetThreeNeighboursToCornerCells()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);
            var twoDGridService = new TwoDGridActionService(grid, cellActionService);

            // Act
            twoDGridService.SetNeighboursToAllCells();

            // Assert
            grid[0][0]
                .Neighbours
                .Count
                .Should()
                .Be(3);

            grid[3][3]
                .Neighbours
                .Count
                .Should()
                .Be(3);

            grid[3][0]
                .Neighbours
                .Count
                .Should()
                .Be(3);

            grid[0][3]
                .Neighbours
                .Count
                .Should()
                .Be(3);
        }

        [Fact]
        public void SetNeighboursToAllCellsShouldSetFiveNeighboursToSideCells()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);
            var twoDGridService = new TwoDGridActionService(grid, cellActionService);

            // Act
            twoDGridService.SetNeighboursToAllCells();

            // Assert
            grid[0][1]
                .Neighbours
                .Count
                .Should()
                .Be(5);

            grid[1][0]
                .Neighbours
                .Count
                .Should()
                .Be(5);

            grid[2][3]
                .Neighbours
                .Count
                .Should()
                .Be(5);

            grid[3][2]
                .Neighbours
                .Count
                .Should()
                .Be(5);
        }

        [Fact]
        public void SetNeighboursToAllCellsShouldSetEightNeighboursToMiddleCells()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);
            var twoDGridService = new TwoDGridActionService(grid, cellActionService);

            // Act
            twoDGridService.SetNeighboursToAllCells();

            // Assert
            grid[1][2]
                .Neighbours
                .Count
                .Should()
                .Be(8);

            grid[2][2]
                .Neighbours
                .Count
                .Should()
                .Be(8);
        }

        [Fact]
        public void GetCountOfTargetBeingGreenReturnsZeroWithNotSetTargetCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);
            var twoDGridService = new TwoDGridActionService(grid, cellActionService);

            // Act

            // Assert
            twoDGridService
                .GetCountOfTargetBeingGreen()
                .Should()
                .Be(0);
        }

        [Fact]
        public void GetCountOfTargetBeingGreenReturnsOneWithSetTargetCellEqualToGreenColour()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);
            var twoDGridService = new TwoDGridActionService(grid, cellActionService);

            var targetY = 1;
            var targetX = 1;

            // Act
            twoDGridService.SetTargetCell(targetY, targetX);

            // Assert
            twoDGridService
                .GetCountOfTargetBeingGreen()
                .Should()
                .Be(1);
        }

        [Fact]
        public void GetCountOfTargetBeingGreenReturnsZeroWithSetTargetCellEqualToRedColour()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);
            var twoDGridService = new TwoDGridActionService(grid, cellActionService);

            var targetY = 0;
            var targetX = 1;

            // Act
            twoDGridService.SetTargetCell(targetY, targetX);

            // Assert
            twoDGridService
                .GetCountOfTargetBeingGreen()
                .Should()
                .Be(0);
        }

        [Fact]
        public void GenerateWithoutSetTargetSellShouldThrowNullReferenceException()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);
            var twoDGridService = new TwoDGridActionService(grid, cellActionService);

            var numberOfGeneration = 15;

            // Act
            Action action = () => twoDGridService.Generate(numberOfGeneration);

            // Assert
            action
                .Should()
                .Throw<NullReferenceException>();
        }

        [Fact]
        public void CountOfTargetBeingGreenWithSetTargetSellAfterGenerateShouldReturnRigthCount()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);
            var twoDGridService = new TwoDGridActionService(grid, cellActionService);

            var targetY = 2;
            var targetX = 2;
            var numberOfGeneration = 15;

            twoDGridService.SetNeighboursToAllCells();
            twoDGridService.SetTargetCell(targetY, targetX);

            // Act
            twoDGridService.Generate(numberOfGeneration);

            // Assert
            twoDGridService
                .GetCountOfTargetBeingGreen()
                .Should()
                .Be(14);
        }

        [Fact]
        public void AddRowShouldAddSuccessfullyRowIntoTheGrid()
        {
            // Arrange
            var grid = new Cell[4][];

            var gridService = new GridService(grid);
            var cellActionService = new CellActionService(gridService);
            var twoDGridService = new TwoDGridActionService(grid, cellActionService);

            var rowIndex = 0;
            var testingRowData = new Cell[]
            {
                new Cell(rowIndex,0,1),
                new Cell(rowIndex,1,0),
                new Cell(rowIndex,2,1),
                new Cell(rowIndex,3,0)
            };

            // Act
            twoDGridService.AddRow(testingRowData, rowIndex);

            // Assert
            grid[0][0]
                .EvenColourState
                .Should()
                .Be(1);

            grid[0][1]
                .EvenColourState
                .Should()
                .Be(0);

            grid[0][2]
                .EvenColourState
                .Should()
                .Be(1);

            grid[0][3]
                .EvenColourState
                .Should()
                .Be(0);
        }
    }
}
