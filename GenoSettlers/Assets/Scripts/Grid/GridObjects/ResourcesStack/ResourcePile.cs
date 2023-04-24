using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePile : MonoBehaviour
{
    [SerializeField] GameObject[] _Slots;

    public void Setup(int count)
    {
        for(int i = 0; i < _Slots.Length; i++)
        {
            bool newValue = count > i;
            if (_Slots[i].activeSelf != newValue)
                _Slots[i].SetActive(newValue);
        }
    }
}
