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

        private BuildingConfig _buildingConfig;

        private float _buildingProgress;

        public BuildingData(BuildingConfig buildingConfig)
        {
            _buildingConfig = buildingConfig;
        }

        public override string ObjectName => "Building";
    }
}
