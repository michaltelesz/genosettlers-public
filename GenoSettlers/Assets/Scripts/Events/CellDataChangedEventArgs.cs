using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
    public class CellDataChangedEventArgs : EventArgs
    {
        public EventType Type { get; private set; }

        public CellDataChangedEventArgs(EventType eventType)
        {
            Type = eventType;
        }

        public enum EventType
        {
            AddObject,
            RemoveObject
        }
    }
}
