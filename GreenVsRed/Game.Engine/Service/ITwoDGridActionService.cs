namespace Game.Engine.Service
{
    using Model;

    internal interface ITwoDGridActionService
    {
        /// <summary>
        /// Set each Cell neighbours.
        /// </summary>
        void SetNeighboursToAllCells();

        /// <summary>
        /// Generates new values in grid.
        /// </summary>
        /// <param name="generationCount">Count of iteration.</param>
        void Generate(int generationCount);

        /// <summary>
        /// Add row data into the grid.
        /// </summary>
        /// <param name="gridRow">Array data.</param>
        /// <param name="row">Index of grid row where to be add.</param>
        void AddRow(Cell[] gridRow, int row);

        /// <summary>
        /// Sets the Target Cell by Finding it in grid. Then sets count of it being green.
        /// </summary>
        /// <param name="targetY">Y coordinate of the Cell.</param>
        /// <param name="targetX">X coordinate of the Cell.</param>
        void SetTargetCell(int targetY, int targetX);

        /// <summary>
        /// Gets the count of Target being green through the generation of the grid.
        /// </summary>
        /// <returns>Return number of the count of the target.</returns>
        int GetCountOfTargetBeingGreen();
    }
}
