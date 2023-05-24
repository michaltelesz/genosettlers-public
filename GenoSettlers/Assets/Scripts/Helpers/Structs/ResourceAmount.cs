using Assets.Scripts.DataModels.Configs;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Helpers.Structs
{
    [Serializable]
    [ValueDropdown("@InspectorsDropdownHelper.ResourcesIDs", IsUniqueList = true, ExcludeExistingValuesInList = true)]
    public class ResourceAmount : IdAmount, IEquatable<ResourceAmount>
    {
        public override string ToString()
        {
            if (Resource == null)
                return string.Empty;

            return Resource.name;
        }
        public ResourceConfig Resource => GameContext.GameConfig.Resources.FirstOrDefault(c => c.Id == _Id);

        public ResourceAmount(ResourceConfig resource, int amount) : base(resource.Id, amount) { }

        public ResourceAmount(uint id, int amount) : base(id, amount) { }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ResourceAmount && Equals((ResourceAmount)obj);
        }

        public bool Equals(ResourceAmount other)
        {
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }

        public override int ChangeAmount(int amount, bool clearEmpty = false)
        {
            if (Resource == null)
                return 0;

            int amountChange = amount > 0
                        ? Mathf.Min(amount, Resource.StackSize - _Amount)
                        : Mathf.Max(amount, -_Amount);
            _Amount += amountChange;
            if (clearEmpty && _Amount <= 0)
            {
                _Id = 0;
            }

            return amountChange;
        }
    }
}