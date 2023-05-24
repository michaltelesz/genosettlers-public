using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Villagers.Works
{
    internal class WorkConvey : BasicWork
    {
        private uint _id;
        private BuildingData _buildingData;
        private bool secondPart;

        public WorkConvey(uint id, BuildingData buildingData)
        {
            _id = id;
            _buildingData = buildingData;
        }

        public override bool Terminated { get; protected set; }

        public override void InvokeStep(Villager villager, float deltaTime)
        {
            if(!secondPart)
            {
                Vector3 vector = -villager.transform.localPosition;
                float distance = vector.magnitude;
                float stepDistance = deltaTime;// * villager.TestSpeed;
                if (distance < 2 * stepDistance)
                {
                    villager.transform.localPosition = Vector3.zero;
                    secondPart = true;
                    return;
                }
                villager.transform.localPosition += stepDistance * (vector / distance);
                return;
            } 
            else
            {
                Vector3 pixelsPosition = _buildingData.Position.ToPixels();
                Vector3 vector = pixelsPosition - villager.transform.localPosition;
                float distance = vector.magnitude;
                float stepDistance = deltaTime;// * villager.TestSpeed;
                if (distance < 2 * stepDistance)
                {
                    villager.transform.localPosition = pixelsPosition;
                    Terminated = true;
                    return;
                }
                villager.transform.localPosition += stepDistance * (vector / distance);
                return;
            }
        }
    }
}