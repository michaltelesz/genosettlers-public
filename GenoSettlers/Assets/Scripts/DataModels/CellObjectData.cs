using Assets.Scripts.Events;
using Assets.Scripts.Helpers.Interfaces.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Assets.Scripts.DataModels
{
    public class CellObjectData : IResourcesContainer
    {
        public GridPosition Position => _position;

        private GridPosition _position;

        private Dictionary<uint, int> _reservedResources = new Dictionary<uint, int>();

        private Dictionary<uint, int> _resources = new Dictionary<uint, int>();

        public virtual string ObjectName { get; }

        public virtual ReadOnlyDictionary<uint, int> Resources => new ReadOnlyDictionary<uint, int>(_resources);

        public ReadOnlyDictionary<uint, int> Reserved => new ReadOnlyDictionary<uint, int>(_reservedResources);

        public event EventHandler<CellObjectDataChangedEventArgs> CellObjectDataChanged;

        public CellObjectData(GridPosition position, string name = null)
        {
            _position = position;
            ObjectName = name;
        }

        protected virtual void OnCellObjectDataChanged(CellObjectDataChangedEventArgs e)
        {
            CellObjectDataChanged?.Invoke(this, e);
        }

        public virtual int ChangeResourceAmount(uint resourceId, int amount, bool abortIncomplete = false)
        {
            OnCellObjectDataChanged(new CellObjectDataChangedEventArgs());
            return 0;
        }

        public bool ReserveResource(uint resourceId, int amount)
        {
            if (!_reservedResources.ContainsKey(resourceId))
            {
                _reservedResources.Add(resourceId, 0);
            }
            int currentReserved = _reservedResources[resourceId];

            if (Resources.TryGetValue(resourceId, out int value) && value >= currentReserved + amount)
            {
                if(currentReserved + amount < 0)
                {
                    Debug.LogWarning($"Resources [{resourceId}] returned from reservation greater then reserved!!!");
                    amount = currentReserved;
                }
                Debug.Log($"Reserve ({amount}/{value}) of resource [{resourceId}]");
                _reservedResources[resourceId] += amount;
                return true;
            }
            return false;
        }
    }
}
