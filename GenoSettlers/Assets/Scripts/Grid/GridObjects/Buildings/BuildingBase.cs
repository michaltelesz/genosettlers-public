using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Grid.GridObjects.Buildings
{
    public class BuildingBase : CellObject
    {
        public override void Setup(CellObjectData objectData)
        {
            if(objectData is BuildingData buildingData)
            {
                Building building = Instantiate(buildingData.BuildingPrefab, transform);
                building.Setup(buildingData);
            }   
        }
    }
}