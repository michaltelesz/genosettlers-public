using Assets.Scripts.DataModels;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesStack : CellObject
{
    [SerializeField] Transform[] _Slots;

    public override void Setup(CellObjectData objectData)
    {
        if(objectData is ResourcesStackData data)
        {
            for (int i = 0; i < _Slots.Length; i++)
            {
                if (data.Resources.Count < i)
                    return;

                foreach(GameObject child in _Slots[i])
                {
                    Destroy(child);
                }

                if (data.Resources[i].Resource == null)
                    continue;

                ResourcePile pile = Instantiate(data.Resources[i].Resource.ResourcePilePrefab, _Slots[i]);
                pile.Setup(data.Resources[i].Amount);
            }
        }
    }
}
