using Assets.Scripts.Events;
using System;

namespace Assets.Scripts.DataModels
{
    [Serializable]
    public class GridCellData
    {
        public event EventHandler<CellDataChangedEventArgs> CellDataChanged;

        public GridPosition Position => _position;

        public CellObjectData ObjectData => _objectData;

        private CellObjectData _objectData;

        private GridPosition _position;

        public GridCellData(GridPosition position)
        {
            _position = position;
        }

        internal void AddCellObject(CellObjectData cellObjectData)
        {
            _objectData = cellObjectData;
            CellDataChanged?.Invoke(this, new CellDataChangedEventArgs(CellDataChangedEventArgs.EventType.AddObject));
        }

        internal void RemoveCellObject()
        {
            CellDataChanged?.Invoke(this, new CellDataChangedEventArgs(CellDataChangedEventArgs.EventType.RemoveObject));
            _objectData = null;
        }
    }
}
