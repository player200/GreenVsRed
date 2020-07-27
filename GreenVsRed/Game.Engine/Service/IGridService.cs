namespace Game.Engine.Service
{
    using Model;

    internal interface IGridService
    {
        /// <summary>
        /// Gets height of the Grid.
        /// </summary>
        /// <returns>Returns height of the Grid.</returns>
        int GetHeight();

        /// <summary>
        /// Gets width of the Grid.
        /// </summary>
        /// <param name="y">Height of the row.</param>
        /// <returns>Returns width of the Grid.</returns>
        int GetWidth(int y);

        /// <summary>
        /// Finds up-rigth Neibour depends of the parameters.
        /// </summary>
        /// <param name="y">Height of the row.</param>
        /// <param name="x">Width of the row.</param>
        /// <returns>Returns up-rigth Neighbour.</returns>
        Cell FindUpRigthNeighbour(int y, int x);

        /// <summary>
        /// Finds up Neibour depends of the parameters.
        /// </summary>
        /// <param name="y">Height of the row.</param>
        /// <param name="x">Width of the row.</param>
        /// <returns>Returns up Neighbour.</returns>
        Cell FindUpNeighbour(int y, int x);

        /// <summary>
        /// Finds up-left Neibour depends of the parameters.
        /// </summary>
        /// <param name="y">Height of the row.</param>
        /// <param name="x">Width of the row.</param>
        /// <returns>Returns up-left Neighbour.</returns>
        Cell FindUpLeftNeighbour(int y, int x);

        /// <summary>
        /// Finds left Neibour depends of the parameters.
        /// </summary>
        /// <param name="y">Height of the row.</param>
        /// <param name="x">Width of the row.</param>
        /// <returns>Returns left Neighbour.</returns>
        Cell FindLeftNeighbour(int y, int x);

        /// <summary>
        /// Finds down-left Neibour depends of the parameters.
        /// </summary>
        /// <param name="y">Height of the row.</param>
        /// <param name="x">Width of the row.</param>
        /// <returns>Returns down-left Neighbour.</returns>
        Cell FindDownLeftNeighbour(int y, int x);

        /// <summary>
        /// Finds down Neibour depends of the parameters.
        /// </summary>
        /// <param name="y">Height of the row.</param>
        /// <param name="x">Width of the row.</param>
        /// <returns>Returns down Neighbour.</returns>
        Cell FindDownNeighbour(int y, int x);

        /// <summary>
        /// Finds down-rigth Neibour depends of the parameters.
        /// </summary>
        /// <param name="y">Height of the row.</param>
        /// <param name="x">Width of the row.</param>
        /// <returns>Returns down-rigth Neighbour.</returns>
        Cell FindDownRigthNeighbour(int y, int x);

        /// <summary>
        /// Finds rigth Neibour depends of the parameters.
        /// </summary>
        /// <param name="y">Height of the row.</param>
        /// <param name="x">Width of the row.</param>
        /// <returns>Returns rigth Neighbour.</returns>
        Cell FindRigthNeighbour(int y, int x);
    }
}
