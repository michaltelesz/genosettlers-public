using Assets.Scripts.DataModels.Configs;
using Assets.Scripts.Grid.GridObjects.Buildings;
using Assets.Scripts.Helpers.Structs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.DataModels
{
    public class BuildingData : CellObjectData
    {
        public Building BuildingPrefab => _buildingConfig.BuildingPrefab;
        public float BuildingProgress => _buildingProgress;

        public BuildingConfig BuildingConfig => _buildingConfig;

        private BuildingConfig _buildingConfig;

        private float _buildingProgress;
        private List<IdAmount> _resources = new List<IdAmount>();

        public BuildingData(GridPosition position, BuildingConfig buildingConfig) : base(position)
        {
            _buildingConfig = buildingConfig;
        }

        public override string ObjectName => "Building";
    }
}
