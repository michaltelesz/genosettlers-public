using Assets.Scripts.DataModels.Configs;
using Assets.Scripts.Helpers;
using Assets.Scripts.Helpers.Interfaces;
using Assets.Scripts.Helpers.Structs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.DataModels
{
    public class ResourcesStackData : CellObjectData, IResourceSource
    {
        private const int RESOURCES_STACK_SIZE = 5;
        public override string ObjectName => "ResourcesStack";

        public ReadOnlyCollection<ResourceAmount> Resources => _resources;

        private ReadOnlyCollection<ResourceAmount> _resources = new ReadOnlyCollection<ResourceAmount>(new ResourceAmount[RESOURCES_STACK_SIZE]);

        public ResourcesStackData(GridPosition position) : base(position)
        {
        }

        internal int ChangeResourceAmount(uint resourceId, int amount, bool abortIncomplete = false)
        {
            List<ResourceAmount> resourcesCopy = new List<ResourceAmount>(_resources);
            ResourceConfig resource = Context.GameConfig.Resources.FirstOrDefault(r => r.Id == resourceId);
            for (int i=0; i < resourcesCopy.Count; i++)
            {
                if (resourcesCopy[i] == null || resourcesCopy[i].Resource == null)
                    continue;

                amount += resourcesCopy[i].ChangeAmount(amount, true);
            }

            if(amount != 0 && abortIncomplete)
            {
                return amount;
            }

            if(amount > 0)
            {
                for (int i = 0; i < resourcesCopy.Count; i++)
                {
                    if (resourcesCopy[i] == null || resourcesCopy[i].Amount <= 0)
                    {
                        int amountChange = Mathf.Min(amount, resource.StackSize);
                        int newAmount = amountChange;
                        resourcesCopy[i] = new ResourceAmount(resource, newAmount);
                        amount -= amountChange;
                    }
                }
            }

            _resources = new System.Collections.ObjectModel.ReadOnlyCollection<ResourceAmount>(resourcesCopy);
            OnCellObjectDataChanged(new CellObjectChangedEventArgs());

            return amount;
        }
    }
}
