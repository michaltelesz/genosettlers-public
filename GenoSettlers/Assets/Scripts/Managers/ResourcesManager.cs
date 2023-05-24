using Assets.Scripts.Helpers.Interfaces.Resources;
using Assets.Scripts.Helpers.Structs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class ResourcesManager : MonoBehaviour, IResourcesManager
    {
        private Dictionary<uint, ResourceData> _resourcesSummary = new Dictionary<uint, ResourceData>();

        public void UpdateResources(IResourcesContainer container, int amountChange)
        {
            foreach (uint resourceId in container.Resources.Keys)
            {
                if(!_resourcesSummary.ContainsKey(resourceId))
                {
                    _resourcesSummary.Add(resourceId, new ResourceData());
                    Debug.Log($"Adding resource [{resourceId}] to ResourceManager");
                }
                
                if(_resourcesSummary[resourceId].Locations.All(l => l != container))
                {
                    _resourcesSummary[resourceId].Locations.Add(container);
                    Debug.Log($"Resource [{resourceId}]: adding location ({container}) to ResourceManager");
                }

                _resourcesSummary[resourceId].Sum += amountChange;
                Debug.Log($"Changing amount of resource [{resourceId}] ({amountChange} -> {_resourcesSummary[resourceId].Sum}) in ResourceManager");
            }
        }

        public List<GridPosition> FindResource(uint resourceId, int amount, bool allowIncomplete)
        {
            if(!_resourcesSummary.ContainsKey(resourceId))
                return new List<GridPosition>();


            _resourcesSummary[resourceId].Locations.RemoveAll(l =>
            {
                if(!l.Resources.TryGetValue(resourceId, out int value) || value <= 0)
                {
                    Debug.Log($"Remove location of resource [{resourceId}] {l}");
                    return true;
                }
                return false;
            });

            return _resourcesSummary[resourceId].Locations.Select(l => l.Position).ToList();
        }

        private class ResourceData
        {
            public int Sum;
            public List<IResourcesContainer> Locations = new List<IResourcesContainer>();
        }
    }
}