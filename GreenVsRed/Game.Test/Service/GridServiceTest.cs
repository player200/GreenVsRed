namespace Game.Test.Service
{
    using Engine.Model;
    using Engine.Service.Implementations;
    using FluentAssertions;
    using Game.Test.MockData;
    using System;
    using Xunit;

    public class GridServiceTest
    {
        [Fact]
        public void FindUpRigthNeighbourShouldReturnRigthCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 1;
            var testedCellX = 1;

            // Act
            var result = gridService.FindUpRigthNeighbour(testedCellY, testedCellX);

            // Assert
            result
                .Should()
                .BeEquivalentTo<Cell>(grid[0][2]);
        }

        [Fact]
        public void FindUpRigthNeighbourShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 0;
            var testedCellX = 1;

            // Act
            Action action = () => gridService.FindUpRigthNeighbour(testedCellY, testedCellX);

            // Assert
            action
                .Should()
                .Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void FindUpNeighbourShouldReturnRigthCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 1;
            var testedCellX = 1;

            // Act
            var result = gridService.FindUpNeighbour(testedCellY, testedCellX);

            // Assert
            result
                .Should()
                .BeEquivalentTo<Cell>(grid[0][1]);
        }

        [Fact]
        public void FindUpNeighbourShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 0;
            var testedCellX = 1;

            // Act
            Action action = () => gridService.FindUpNeighbour(testedCellY, testedCellX);

            // Assert
            action
                .Should()
                .Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void FindUpLeftNeighbourShouldReturnRigthCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 1;
            var testedCellX = 1;

            // Act
            var result = gridService.FindUpLeftNeighbour(testedCellY, testedCellX);

            // Assert
            result
                .Should()
                .BeEquivalentTo<Cell>(grid[0][0]);
        }

        [Fact]
        public void FindUpLeftNeighbourShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 0;
            var testedCellX = 1;

            // Act
            Action action = () => gridService.FindUpLeftNeighbour(testedCellY, testedCellX);

            // Assert
            action
                .Should()
                .Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void FindLeftNeighbourShouldReturnRigthCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 1;
            var testedCellX = 1;

            // Act
            var result = gridService.FindLeftNeighbour(testedCellY, testedCellX);

            // Assert
            result
                .Should()
                .BeEquivalentTo<Cell>(grid[1][0]);
        }

        [Fact]
        public void FindLeftNeighbourShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 1;
            var testedCellX = 0;

            // Act
            Action action = () => gridService.FindLeftNeighbour(testedCellY, testedCellX);

            // Assert
            action
                .Should()
                .Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void FindDownLeftNeighbourShouldReturnRigthCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 1;
            var testedCellX = 1;

            // Act
            var result = gridService.FindDownLeftNeighbour(testedCellY, testedCellX);

            // Assert
            result
                .Should()
                .BeEquivalentTo<Cell>(grid[2][0]);
        }

        [Fact]
        public void FindDownLeftNeighbourThrowIndexOutOfRangeException()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 3;
            var testedCellX = 0;

            // Act
            Action action = () => gridService.FindDownLeftNeighbour(testedCellY, testedCellX);

            // Assert
            action
                .Should()
                .Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void FindDownNeighbourShouldReturnRigthCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 1;
            var testedCellX = 1;

            // Act
            var result = gridService.FindDownNeighbour(testedCellY, testedCellX);

            // Assert
            result
                .Should()
                .BeEquivalentTo<Cell>(grid[2][1]);
        }

        [Fact]
        public void FindDownNeighbourShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 3;
            var testedCellX = 3;

            // Act
            Action action = () => gridService.FindDownNeighbour(testedCellY, testedCellX);

            // Assert
            action
                .Should()
                .Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void FindDownRigthNeighbourShouldReturnRigthCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 1;
            var testedCellX = 1;

            // Act
            var result = gridService.FindDownRigthNeighbour(testedCellY, testedCellX);

            // Assert
            result
                .Should()
                .BeEquivalentTo<Cell>(grid[2][2]);
        }

        [Fact]
        public void FindDownRigthNeighbourThrowIndexOutOfRangeException()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 1;
            var testedCellX = 3;

            // Act
            Action action = () => gridService.FindDownRigthNeighbour(testedCellY, testedCellX);

            // Assert
            action
                .Should()
                .Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void FindRigthNeighbourShouldReturnRigthCell()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 1;
            var testedCellX = 1;

            // Act
            var result = gridService.FindRigthNeighbour(testedCellY, testedCellX);

            // Assert
            result
                .Should()
                .BeEquivalentTo<Cell>(grid[1][2]);
        }

        [Fact]
        public void FindRigthNeighbourThrowIndexOutOfRangeException()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var testedCellY = 1;
            var testedCellX = 3;

            // Act
            Action action = () => gridService.FindRigthNeighbour(testedCellY, testedCellX);

            // Assert
            action
                .Should()
                .Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void GetHeightShouldReturnGridLength()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);

            // Act
            var result = gridService.GetHeight();

            // Assert
            result
                .Should()
                .Be(4);
        }

        [Fact]
        public void GetWidthShouldReturnGridsRowLength()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var rowIndex = 1;

            // Act
            var result = gridService.GetWidth(rowIndex);

            // Assert
            result
                .Should()
                .Be(4);
        }

        [Fact]
        public void GetWidthShouldThrowIndexOutOfRangeExeptionWithGreaterParameter()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var rowIndex = 5;

            // Act
            Action action = () => gridService.GetWidth(rowIndex);

            // Assert
            action
                .Should()
                .Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void GetWidthShouldThrowIndexOutOfRangeExeptionWithNegativeParameter()
        {
            // Arrange
            var grid = MockGrid.Context();

            var gridService = new GridService(grid);
            var rowIndex = -1;

            // Act
            Action action = () => gridService.GetWidth(rowIndex);

            // Assert
            action
                .Should()
                .Throw<IndexOutOfRangeException>();
        }
    }
}
