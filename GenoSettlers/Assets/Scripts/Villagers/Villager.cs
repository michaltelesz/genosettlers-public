using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    private VillagerData _villagerData;

    private IWork _currentWork;

    public IWork CurrentWork => _currentWork;

    internal void InvokeWorkStep()
    {
        //Debug.Log($"Villager: {name}, Work: {CurrentWork.GetType()}");
    }

    internal bool SetWork(IWork work)
    {
        _currentWork = work;
        return _currentWork != null;
    }
}
