using Assets.Scripts.Grid.GridObjects.Buildings;
using Assets.Scripts.Helpers.Structs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.DataModels.Configs
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Configs/Building")]
    public class BuildingConfig : IndexedConfig
    {
        public Building BuildingPrefab => _BuildingPrefab;

        [SerializeField] private Building _BuildingPrefab;

        [SerializeField] private List<ResourceAmount> _Cost = new List<ResourceAmount>();
    }
}