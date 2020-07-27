namespace Game.Engine.Service.Implementations
{
    using Model;

    internal class TwoDGridActionService : ITwoDGridActionService
    {
        private readonly Cell[][] _twoDGrid;
        private readonly ICellActionService _cellAction;
        private Cell _target;
        private int _countOfTargetBeingGreen;

        public TwoDGridActionService(Cell[][] grid, ICellActionService cellAction)
        {
            this._twoDGrid = grid;
            this._cellAction = cellAction;
        }

        public void SetNeighboursToAllCells()
        {
            foreach (var row in this._twoDGrid)
            {
                foreach (var cell in row)
                {
                    this._cellAction.AddNeighbours(cell);
                }
            }
        }

        public void Generate(int generationCount)
        {
            //Depends of the iteration, it calls Even or Odd Rotation.
            //When we call Even rotation we change OddColourState in the Cells,
            //depend of the rules for colours we apply to EvenColourState Neighbours and EvenColourState.
            //When we call Odd rotation we change EvenColourState in the Cells,
            //depend of the rules for colours we apply to OddColourState Neighbours and OddColourState.
            for (int iteration = 0; iteration < generationCount; iteration++)
            {
                if (iteration % 2 == 0)
                {
                    this.EvenRotation();
                }
                else
                {
                    this.OddRotation();
                }
            }
        }

        public void AddRow(Cell[] gridRow, int row)
        {
            this._twoDGrid[row] = gridRow;
        }

        public void SetTargetCell(int targetY, int targetX)
        {
            this._target = this._twoDGrid[targetY][targetX];

            if (this._target.EvenColourState == 1)
            {
                this._countOfTargetBeingGreen = 1;
            }
        }

        public int GetCountOfTargetBeingGreen() => this._countOfTargetBeingGreen;

        /// <summary>
        /// Iterates through cells in the grid, calls thair OddColourState to update and updates the Target count value of being green.
        /// </summary>
        private void EvenRotation()
        {
            foreach (var row in this._twoDGrid)
            {
                foreach (var cell in row)
                {
                    this._cellAction.OddChangeState(cell);
                }
            }

            //update count of the target after the new rotation
            if (this._target.OddColourState == 1)
            {
                this._countOfTargetBeingGreen += 1;
            }
        }

        /// <summary>
        /// Iterates through cells in the grid, calls thair EvenColourState to update and updates the Target count value of being green.
        /// </summary>
        private void OddRotation()
        {
            foreach (var row in this._twoDGrid)
            {
                foreach (var cell in row)
                {
                    this._cellAction.EvenChangeState(cell);
                }
            }

            //update count of the target after the new rotation
            if (this._target.EvenColourState == 1)
            {
                this._countOfTargetBeingGreen += 1;
            }
        }
    }
}
