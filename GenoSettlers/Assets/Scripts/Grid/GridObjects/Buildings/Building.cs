using Assets.Scripts.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Grid.GridObjects.Buildings
{
    public abstract class Building : MonoBehaviour
    {
        public abstract void Setup(BuildingData buildingData);
    }
}
