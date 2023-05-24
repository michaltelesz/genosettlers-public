using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers.Interfaces;
using Assets.Scripts.Helpers.Interfaces.Resources;
using Assets.Scripts.Helpers.Structs;
using System;
using System.Collections.ObjectModel;
using UnityEngine;
using Random = UnityEngine.Random;

public class Villager : MonoBehaviour
{
    private VillagerData _villagerData;

    private IWork _currentWork;

    public bool WaitingForWork => _currentWork == null || _currentWork.Terminated;

    public ReadOnlyCollection<ResourceAmount> Resources => throw new NotImplementedException();

    internal void InvokeWorkStep(float deltaTime)
    {
        _currentWork.InvokeStep(this, deltaTime);
    }

    internal void Setup()
    {
    }

    internal bool SetWork(IWork work)
    {
        _currentWork = work;
        return _currentWork != null;
    }
}
