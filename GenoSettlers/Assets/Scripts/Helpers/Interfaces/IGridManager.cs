using Assets.Scripts.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers.Interfaces
{
    internal interface IGridManager
    {
        void AddCellObject(GridPosition position, CellObjectData cellObjectData);
        void Setup(int width, int height);
    }
}
