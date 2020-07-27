namespace Game.Engine.Service.Implementations
{
    using Model;
    using Service;
    using System.Linq;

    internal class CellActionService : ICellActionService
    {
        private readonly IGridService _grid;

        public CellActionService(IGridService grid)
        {
            this._grid = grid;
        }

        public void AddNeighbours(Cell cell)
        {
            var height = this._grid.GetHeight();
            var width = this._grid.GetWidth(cell.Y);

            if (cell.Y == 0
                || cell.Y == height - 1
                || cell.X == 0
                || cell.X == width - 1)
            {
                if ((cell.Y == 0 && cell.X == 0)
                            || (cell.Y == height - 1 && cell.X == 0)
                            || (cell.Y == 0 && cell.X == width - 1)
                            || (cell.Y == height - 1 && cell.X == width - 1))
                {
                    //add neighbours to courners cell
                    this.AddNeighboursToCorners(cell);
                }
                else
                {
                    //add neighbours to sides cell but not the courners
                    this.AddNeighboursToSides(cell);
                }
            }
            else
            {
                //add neighbours to middle cell
                this.AddNeighboursToMiddles(cell);
            }
        }

        public void OddChangeState(Cell cell)
        {
            this.UpdateOddState(this.CheckOddToChange(cell), cell);
        }

        public void EvenChangeState(Cell cell)
        {
            this.UpdateEvenState(this.CheckEvenToChange(cell), cell);
        }

        /// <summary>
        /// Adds Neibours to the Cell. Cell is in the middle part of the grid.
        /// </summary>
        /// <param name="cell">Cell we want to add Neighbours to.</param>
        private void AddNeighboursToMiddles(Cell cell)
        {
            //up
            cell.Neighbours.Add(this._grid.FindUpNeighbour(cell.Y, cell.X));
            //uprigth
            cell.Neighbours.Add(this._grid.FindUpRigthNeighbour(cell.Y, cell.X));
            //rigth
            cell.Neighbours.Add(this._grid.FindRigthNeighbour(cell.Y, cell.X));
            //downrigth
            cell.Neighbours.Add(this._grid.FindDownRigthNeighbour(cell.Y, cell.X));
            //down
            cell.Neighbours.Add(this._grid.FindDownNeighbour(cell.Y, cell.X));
            //downleft
            cell.Neighbours.Add(this._grid.FindDownLeftNeighbour(cell.Y, cell.X));
            //left
            cell.Neighbours.Add(this._grid.FindLeftNeighbour(cell.Y, cell.X));
            //upleft
            cell.Neighbours.Add(this._grid.FindUpLeftNeighbour(cell.Y, cell.X));
        }

        /// <summary>
        /// Adds Neibours to the Cell. Cell is in one of the sides of the grid.
        /// </summary>
        /// <param name="cell">Cell we want to add Neighbours to.</param>
        private void AddNeighboursToSides(Cell cell)
        {
            var width = this._grid.GetWidth(cell.Y);

            //leftSide
            if (cell.X == 0)
            {
                //up
                cell.Neighbours.Add(this._grid.FindUpNeighbour(cell.Y, cell.X));
                //uprigth
                cell.Neighbours.Add(this._grid.FindUpRigthNeighbour(cell.Y, cell.X));
                //rigth
                cell.Neighbours.Add(this._grid.FindRigthNeighbour(cell.Y, cell.X));
                //downrigth
                cell.Neighbours.Add(this._grid.FindDownRigthNeighbour(cell.Y, cell.X));
                //down
                cell.Neighbours.Add(this._grid.FindDownNeighbour(cell.Y, cell.X));
            }
            //upSide
            else if (cell.Y == 0)
            {
                //left
                cell.Neighbours.Add(this._grid.FindLeftNeighbour(cell.Y, cell.X));
                //downleft
                cell.Neighbours.Add(this._grid.FindDownLeftNeighbour(cell.Y, cell.X));
                //down
                cell.Neighbours.Add(this._grid.FindDownNeighbour(cell.Y, cell.X));
                //downright
                cell.Neighbours.Add(this._grid.FindDownRigthNeighbour(cell.Y, cell.X));
                //rigth
                cell.Neighbours.Add(this._grid.FindRigthNeighbour(cell.Y, cell.X));
            }
            //rigthSide
            else if (cell.X == width - 1)
            {
                //up
                cell.Neighbours.Add(this._grid.FindUpNeighbour(cell.Y, cell.X));
                //upleft
                cell.Neighbours.Add(this._grid.FindUpLeftNeighbour(cell.Y, cell.X));
                //left
                cell.Neighbours.Add(this._grid.FindLeftNeighbour(cell.Y, cell.X));
                //downleft
                cell.Neighbours.Add(this._grid.FindDownLeftNeighbour(cell.Y, cell.X));
                //down
                cell.Neighbours.Add(this._grid.FindDownNeighbour(cell.Y, cell.X));
            }
            //downSide
            else
            {
                //left
                cell.Neighbours.Add(this._grid.FindLeftNeighbour(cell.Y, cell.X));
                //upleft
                cell.Neighbours.Add(this._grid.FindUpLeftNeighbour(cell.Y, cell.X));
                //up
                cell.Neighbours.Add(this._grid.FindUpNeighbour(cell.Y, cell.X));
                //uprigth
                cell.Neighbours.Add(this._grid.FindUpRigthNeighbour(cell.Y, cell.X));
                //rigth
                cell.Neighbours.Add(this._grid.FindRigthNeighbour(cell.Y, cell.X));
            }
        }

        /// <summary>
        /// Adds Neibours to the Cell. Cell is in one of the corners but not the sides of the grid.
        /// </summary>
        /// <param name="cell">Cell we want to add Neighbours to.</param>
        private void AddNeighboursToCorners(Cell cell)
        {
            var height = this._grid.GetHeight();
            var width = this._grid.GetWidth(cell.Y);

            //check 4-th corners
            //upleft
            if (cell.Y == 0 && cell.X == 0)
            {
                //right
                cell.Neighbours.Add(this._grid.FindRigthNeighbour(cell.Y, cell.X));
                //downright
                cell.Neighbours.Add(this._grid.FindDownRigthNeighbour(cell.Y, cell.X));
                //down
                cell.Neighbours.Add(this._grid.FindDownNeighbour(cell.Y, cell.X));
            }
            //upright
            else if (cell.Y == 0 && cell.X == width - 1)
            {
                //left
                cell.Neighbours.Add(this._grid.FindLeftNeighbour(cell.Y, cell.X));
                //donwleft
                cell.Neighbours.Add(this._grid.FindDownLeftNeighbour(cell.Y, cell.X));
                //donw
                cell.Neighbours.Add(this._grid.FindDownNeighbour(cell.Y, cell.X));
            }
            //downleft
            else if (cell.Y == height - 1 && cell.X == 0)
            {
                //up
                cell.Neighbours.Add(this._grid.FindUpNeighbour(cell.Y, cell.X));
                //upright
                cell.Neighbours.Add(this._grid.FindUpRigthNeighbour(cell.Y, cell.X));
                //right
                cell.Neighbours.Add(this._grid.FindRigthNeighbour(cell.Y, cell.X));
            }
            //downright
            else
            {
                //up
                cell.Neighbours.Add(this._grid.FindUpNeighbour(cell.Y, cell.X));
                //upleft
                cell.Neighbours.Add(this._grid.FindUpLeftNeighbour(cell.Y, cell.X));
                //left
                cell.Neighbours.Add(this._grid.FindLeftNeighbour(cell.Y, cell.X));
            }

        }

        /// <summary>
        /// Updates EvenColourState of the cell param depends toChange param and OddColourState.
        /// </summary>
        /// <param name="toChange">Param that says if we the rules for green and red passed.</param>
        /// <param name="cell">Cell we want to change.</param>
        private void UpdateEvenState(bool toChange, Cell cell)
        {
            if (cell.OddColourState == 1)
            {
                if (toChange)
                {
                    cell.EvenColourState = 0;
                }
                else
                {
                    cell.EvenColourState = 1;
                }
            }
            else
            {
                if (toChange)
                {
                    cell.EvenColourState = 1;
                }
                else
                {
                    cell.EvenColourState = 0;
                }
            }
        }

        /// <summary>
        /// Updates OddColourState of the cell param depends toChange param and EvenColourState.
        /// </summary>
        /// <param name="toChange">Param that says if we the rules for green and red passed.</param>
        /// <param name="cell">Cell we want to change.</param>
        private void UpdateOddState(bool toChange, Cell cell)
        {
            if (cell.EvenColourState == 1)
            {
                if (toChange)
                {
                    cell.OddColourState = 0;
                }
                else
                {
                    cell.OddColourState = 1;
                }
            }
            else
            {
                if (toChange)
                {
                    cell.OddColourState = 1;
                }
                else
                {
                    cell.OddColourState = 0;
                }
            }
        }

        /// <summary>
        /// Checks if the EvenColourState should be changed depend of OddColourState by the rules for green and red Cell.
        /// </summary>
        /// <param name="cell">Cell that we want to change.</param>
        /// <returns>Returns value that says if we need to change EvenColourState.</returns>
        private bool CheckEvenToChange(Cell cell)
        {
            var greenNeiboursCount = this.GetCountGreenNeighboursOdd(cell);

            if (cell.OddColourState == 1)
            {

                return (greenNeiboursCount != 2
                    && greenNeiboursCount != 3
                    && greenNeiboursCount != 6);
            }

            return (greenNeiboursCount == 3
                || greenNeiboursCount == 6);

        }

        /// <summary>
        /// Checks if the OddColourState should be changed depend of EvenColourState by the rules for green and red Cell.
        /// </summary>
        /// <param name="cell">Cell that we want to change.</param>
        /// <returns>Returns value that says if we need to change EvenColourState.</returns>
        private bool CheckOddToChange(Cell cell)
        {
            var greenNeiboursCount = this.GetCountGreenNeighboursEven(cell);

            if (cell.EvenColourState == 1)
            {

                return (greenNeiboursCount != 2
                     && greenNeiboursCount != 3
                     && greenNeiboursCount != 6);

            }

            return (greenNeiboursCount == 3
                || greenNeiboursCount == 6);
        }

        /// <summary>
        /// Gets the number of green OddColourState Neighbours contained in the Cell.
        /// </summary>
        /// <param name="cell">The Cell to look.</param>
        /// <returns>The number of green Neighbours contained in the Cell.</returns>
        private int GetCountGreenNeighboursOdd(Cell cell)
            => cell.Neighbours.Where(x => x.OddColourState == 1).Count();

        /// <summary>
        /// Gets the number of green EvenColourState Neighbours contained in the Cell.
        /// </summary>
        /// <param name="cell">The Cell to look.</param>
        /// <returns>The number of green Neighbours contained in the Cell.</returns>
        private int GetCountGreenNeighboursEven(Cell cell)
            => cell.Neighbours.Where(x => x.EvenColourState == 1).Count();
    }
}
