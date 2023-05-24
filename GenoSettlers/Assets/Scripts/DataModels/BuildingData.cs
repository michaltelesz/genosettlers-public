using Assets.Scripts.DataModels.Configs;
using Assets.Scripts.Grid.GridObjects.Buildings;
using Assets.Scripts.Helpers.Interfaces.Resources;
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

        public BuildingData(GridPosition position, BuildingConfig buildingConfig, bool fullyBuilt = false) : base(position)
        {
            _buildingConfig = buildingConfig;
            if(fullyBuilt) {
                _buildingProgress = 1f;
            }
        }

        public override string ObjectName => "Building";
    }
}
