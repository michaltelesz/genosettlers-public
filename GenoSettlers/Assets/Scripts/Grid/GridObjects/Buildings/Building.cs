using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers.Interfaces;
using Assets.Scripts.Helpers.Structs;
using Assets.Scripts.Villagers.Works;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Grid.GridObjects.Buildings
{
    public abstract class Building : MonoBehaviour
    {
        [SerializeField] protected GameObject _InProgress;
        [SerializeField] protected Transform _Built;

        public virtual void Setup(BuildingData buildingData)
        {
            _InProgress.SetActive(buildingData.BuildingProgress < 1);
            _Built.gameObject.SetActive(buildingData.BuildingProgress > 0);
            _Built.localScale = Vector3.one * Mathf.Clamp(buildingData.BuildingProgress, 0, 1f);
            List<IWork> works = new List<IWork>();
            if (buildingData.BuildingProgress < 1)
            {
                ReadOnlyCollection<ResourceAmount> cost = buildingData.BuildingConfig.Cost;
                for (int i = 0; i < cost.Count; i++)
                {
                    for (int j = 0; j < cost[i].Amount; j++)
                    {
                        works.Add(new WorkConvey(cost[i].Id, buildingData));
                    }
                }
            }
        }
    }
}
