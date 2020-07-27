namespace Game.Engine.Service
{
    using Model;

    internal interface ICellActionService
    {
        /// <summary>
        /// Adds Neighbours to the Cell.
        /// </summary>
        /// <param name="cell">Cell that we want to </param>
        void AddNeighbours(Cell cell);

        /// <summary>
        /// Updating the OddColourState of the Cell.
        /// </summary>
        /// <param name="cell">Cell that we want to change state.</param>
        void OddChangeState(Cell cell);

        /// <summary>
        /// Updating the EvenColourState of the Cell.
        /// </summary>
        /// <param name="cell">Cell that we want to change state.</param>
        void EvenChangeState(Cell cell);
    }
}
