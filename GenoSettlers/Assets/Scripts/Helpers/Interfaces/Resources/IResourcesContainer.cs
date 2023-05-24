using Assets.Scripts.Helpers.Structs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers.Interfaces.Resources
{
    public interface IResourcesContainer
    {
        GridPosition Position { get; }
        ReadOnlyDictionary<uint, int> Resources { get; }
        ReadOnlyDictionary<uint, int> Reserved { get; }
        public int ChangeResourceAmount(uint resourceId, int amount, bool abortIncomplete = false);
        public bool ReserveResource(uint resourceId, int amount);
    }
}
