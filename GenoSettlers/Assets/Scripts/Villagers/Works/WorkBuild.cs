using Assets.Scripts.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Villagers.Works
{
    internal class WorkBuild : BasicWork
    {
        public override bool Terminated { get; protected set; }

        public override void InvokeStep(Villager villager, float deltaTime)
        {
        }
    }
}
