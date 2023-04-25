using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Villagers.Works
{
    internal class WorkConvey : BasicWork
    {
        private uint id;
        private BuildingData buildingData;

        public WorkConvey(uint id, BuildingData buildingData)
        {
            this.id = id;
            this.buildingData = buildingData;
        }

        public override bool Terminated { get; }

        public override void InvokeStep(Villager villager)
        {
        }
    }
}