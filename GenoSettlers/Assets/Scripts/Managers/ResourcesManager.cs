using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers.Interfaces;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class ResourcesManager : MonoBehaviour, IResourcesManager
    {
        private Dictionary<uint, ResourceData> _resources = new Dictionary<uint, ResourceData>();
        public void SubscribeResourceChange(UnityEngine.Object subscriber, int resourceId, Action<uint, int> action)
        {
        }

        public void UnsubscribeAll(UnityEngine.Object subscriber)
        {
        }

        private void RaiseInternal() {
        }
    }

    public class ResourceData
    {
        public int resourceId;
        public IResourceSource location;
        public bool reserved;
    }
}