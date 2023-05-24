using Assets.Scripts.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Villagers.Works
{
    public abstract class BasicWork : IWork
    {
        public bool InProgress
        {
            get; private set;
        }
        public abstract bool Terminated { get; protected set; }

        public void Begin()
        {
            InProgress = true;
        }

        public abstract void InvokeStep(Villager villager, float deltaTime);
    }
}
