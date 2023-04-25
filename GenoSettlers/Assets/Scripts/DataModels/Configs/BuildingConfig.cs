using Assets.Scripts.Grid.GridObjects.Buildings;
using Assets.Scripts.Helpers.Structs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Assets.Scripts.DataModels.Configs
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Configs/Building")]
    public class BuildingConfig : IndexedConfig
    {
        public Building BuildingPrefab => _BuildingPrefab;

        public ReadOnlyCollection<ResourceAmount> Cost => new ReadOnlyCollection<ResourceAmount>(_Cost);

        [SerializeField] private Building _BuildingPrefab;

        [SerializeField] private List<ResourceAmount> _Cost = new List<ResourceAmount>();
    }
}