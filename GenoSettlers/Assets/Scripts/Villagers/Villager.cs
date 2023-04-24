using Assets.Scripts.Helpers.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    private IVillagersManager _villagersManager;

    private IWork _currentWork;

    public void Setup(IVillagersManager manager)
    {
        _villagersManager = manager;
    }

    private void Update()
    {
        if(_currentWork == null) {
            _currentWork = _villagersManager.GetNextWork();
        }
    }
}
