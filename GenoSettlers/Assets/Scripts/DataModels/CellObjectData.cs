using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataModels
{
    public class CellObjectData
    {
        public GridPosition Postion => _position;

        private GridPosition _position;

        public virtual string ObjectName { get; }

        public event EventHandler<CellObjectChangedEventArgs> CellObjectDataChanged;

        public CellObjectData(GridPosition position, string name = null)
        {
            _position = position;
            ObjectName = name;
        }

        protected virtual void OnCellObjectDataChanged(CellObjectChangedEventArgs e)
        {
            CellObjectDataChanged?.Invoke(this, e);
        }
    }

    public class CellObjectChangedEventArgs : EventArgs
    {

    }
}
