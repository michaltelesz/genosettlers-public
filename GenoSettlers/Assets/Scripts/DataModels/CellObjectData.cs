using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataModels
{
    public class CellObjectData
    {
        public virtual string ObjectName { get; }

        public event EventHandler<CellObjectChangedEventArgs> CellObjectChanged;

        protected CellObjectData() { }

        public CellObjectData(string name)
        {
            ObjectName = name;
        }

        protected virtual void OnCellObjectChanged(CellObjectChangedEventArgs e)
        {
            CellObjectChanged?.Invoke(this, e);
        }
    }



    public class CellObjectChangedEventArgs : EventArgs
    {

    }
}
