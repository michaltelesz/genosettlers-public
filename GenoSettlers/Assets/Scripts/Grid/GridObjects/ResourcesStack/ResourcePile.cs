using Assets.Scripts.Helpers.Structs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePile : MonoBehaviour
{
    [SerializeField] GameObject[] _Slots;

    public uint ResourceId { get; private set; }

    public void Setup(ResourceAmount resourceAmount)
    {
        ResourceId = resourceAmount.Id;
        for(int i = 0; i < _Slots.Length; i++)
        {
            bool newValue = resourceAmount.Amount > i;
            if (_Slots[i].activeSelf != newValue)
                _Slots[i].SetActive(newValue);
        }
    }
}
