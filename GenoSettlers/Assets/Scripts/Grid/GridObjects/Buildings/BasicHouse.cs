using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers.Interfaces;
using Assets.Scripts.Helpers.Structs;
using Assets.Scripts.Villagers.Works;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Assets.Scripts.Grid.GridObjects.Buildings
{
    public class BasicHouse : Building
    {
        [SerializeField] GameObject _InProgress;
        [SerializeField] Transform _Built;

        public override void Setup(BuildingData buildingData)
        {
            _InProgress.SetActive(buildingData.BuildingProgress < 1);
            _Built.localScale = Vector3.one * Mathf.Clamp(buildingData.BuildingProgress, 0, 1f);
            ReadOnlyCollection<ResourceAmount> cost = buildingData.BuildingConfig.Cost;
            for (int i = 0; i<cost.Count; i++)
            {
                for (int j = 0; j < cost[i].Amount; j++)
                {
                    IWork work = new WorkConvey(cost[i].Id, buildingData);
                    //TODO Loose reference to instance of VillagersManager
                    VillagersManager villagersManager = FindObjectOfType<VillagersManager>();
                    villagersManager.AddWork(work);
                }
            }
        }
    }
}