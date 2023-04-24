using Assets.Scripts.Helpers.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagersManager : MonoBehaviour, IVillagersManager
{
    [SerializeField] private Transform _VillagersContainer;

    IWork IVillagersManager.GetNextWork()
    {
        throw new System.NotImplementedException();
    }
}
