using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers.Interfaces;
using Assets.Scripts.Helpers.Interfaces.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers.Interfaces.Resources
{
    public interface IResourcesManager
    {
        void UpdateResources(IResourcesContainer container, int amountChange);
        List<GridPosition> FindResource(uint resourceId, int amount, bool allowIncomplete = true);
    }
}
