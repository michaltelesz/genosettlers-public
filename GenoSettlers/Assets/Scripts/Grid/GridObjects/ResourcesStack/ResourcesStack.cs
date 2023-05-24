using Assets.Scripts.DataModels;
using Assets.Scripts.Events;
using Assets.Scripts.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesStack : CellObject
{
    [SerializeField] Transform[] _Slots;

    public override void Setup(CellObjectData objectData)
    {
        if (objectData is ResourcesStackData data)
        {
            for (int i = 0; i < _Slots.Length; i++)
            {
                if (data.ResourcesSlots.Count < i || data.ResourcesSlots[i]?.Resource == null)
                {
                    ClearSlot(_Slots[i]);
                    continue;
                }

                ResourcePile pile = _Slots[i].GetComponentInChildren<ResourcePile>();
                if (pile == null || pile.ResourceId != data.ResourcesSlots[i].Resource.Id)
                {
                    ClearSlot(_Slots[i]);
                    pile = Instantiate(data.ResourcesSlots[i].Resource.ResourcePilePrefab, _Slots[i]);
                }

                pile.Setup(data.ResourcesSlots[i]);
            }
        }
    }

    private void ClearSlot(Transform transform)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    protected override void CellObjectDataChanged(object sender, CellObjectDataChangedEventArgs e)
    {
        if (sender is ResourcesStackData data)
        {
            Setup(data);
        }
    }
}
