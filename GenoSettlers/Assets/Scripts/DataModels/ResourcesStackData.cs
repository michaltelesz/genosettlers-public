using Assets.Scripts.DataModels.Configs;
using Assets.Scripts.Events;
using Assets.Scripts.Helpers;
using Assets.Scripts.Helpers.Interfaces.Resources;
using Assets.Scripts.Helpers.Structs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.DataModels
{
    public class ResourcesStackData : CellObjectData
    {
        IResourcesManager _resourcesManager;

        private const int RESOURCES_STACK_SIZE = 5;
        public override string ObjectName => "ResourcesStack";

        public override ReadOnlyDictionary<uint, int> Resources {
            get {
                Dictionary<uint, int> dictionary = new Dictionary<uint, int>();
                foreach(ResourceAmount resource in _resourcesSlots)
                {
                    if(!dictionary.ContainsKey(resource.Id))
                    {
                        dictionary.Add(resource.Id, 0);
                    }
                    dictionary[resource.Id] += resource.Amount;
                }

                return new ReadOnlyDictionary<uint, int>(dictionary);
            }
        }

        public ReadOnlyCollection<ResourceAmount> ResourcesSlots => _resourcesSlots;

        private ReadOnlyCollection<ResourceAmount> _resourcesSlots = new ReadOnlyCollection<ResourceAmount>(new ResourceAmount[RESOURCES_STACK_SIZE]);
        
        public ResourcesStackData(GridPosition position, IResourcesManager resourcesManager) : base(position)
        {
            _resourcesManager = resourcesManager;
        }

        public override int ChangeResourceAmount(uint resourceId, int amount, bool abortIncomplete = true)
        {
            int remainingAmount = amount;
            List<ResourceAmount> resourcesCopy = new List<ResourceAmount>(_resourcesSlots);
            ResourceConfig resource = GameContext.GameConfig.Resources.FirstOrDefault(r => r.Id == resourceId);
            for (int i = 0; i < resourcesCopy.Count; i++)
            {
                if (resourcesCopy[i] == null || resourcesCopy[i].Resource == null)
                    continue;

                remainingAmount += resourcesCopy[i].ChangeAmount(remainingAmount, true);
            }

            if (remainingAmount < 0 && abortIncomplete)
            {
                return remainingAmount;
            }

            if (remainingAmount > 0)
            {
                for (int i = 0; i < resourcesCopy.Count; i++)
                {
                    if (resourcesCopy[i] == null || resourcesCopy[i].Amount <= 0)
                    {
                        int amountChange = Mathf.Min(remainingAmount, resource.StackSize);
                        int newAmount = amountChange;
                        resourcesCopy[i] = new ResourceAmount(resource, newAmount);
                        remainingAmount -= amountChange;
                    }
                }
            }

            if (remainingAmount != 0 && abortIncomplete)
            {
                return remainingAmount;
            }

            _resourcesSlots = new ReadOnlyCollection<ResourceAmount>(resourcesCopy);
            _resourcesManager.UpdateResources(this, amount - remainingAmount);
            OnCellObjectDataChanged(new CellObjectDataChangedEventArgs());
            return remainingAmount;
        }
    }
}
