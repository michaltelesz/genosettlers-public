using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IResourcesManager
    {
        void SubscribeResourceChange(UnityEngine.Object subscriber, int resourceId, Action<uint, int> action);

        void UnsubscribeAll(UnityEngine.Object subscriber);
    }
}
