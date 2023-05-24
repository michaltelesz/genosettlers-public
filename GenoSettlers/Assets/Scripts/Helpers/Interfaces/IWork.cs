using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers.Interfaces
{
    //TODO Switch to IVillager interface without MonoBehaviour instantiation
    public interface IWork
    {
        bool Terminated { get; }

        bool InProgress { get; }

        void Begin();
        void InvokeStep(Villager villager, float deltaTime);
    }
}
