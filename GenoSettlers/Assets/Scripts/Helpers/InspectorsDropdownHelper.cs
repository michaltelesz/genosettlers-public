using Assets.Scripts.DataModels.Configs;
using Assets.Scripts.Helpers.Structs;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class InspectorsDropdownHelper
    {
        public static ValueDropdownList<ResourceAmount> ResourcesIDs
        {
            get
            {
                ValueDropdownList<ResourceAmount> resources = new ValueDropdownList<ResourceAmount>();
                if (GameContext.GameConfig != null)
                {
                    foreach (var item in GameContext.GameConfig.Resources)
                    {
                        resources.Add($"{item.name}", new ResourceAmount(item, 0));
                    }
                }
                return resources;


            }
        }
    }
}
