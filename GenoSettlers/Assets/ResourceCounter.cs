using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private IResourcesManager _ResourcesManager;
    [SerializeField] private TMP_Text _Text;

    private void OnEnable()
    {
        _ResourcesManager.SubscribeResourceChange(this, 1, OnResourceChanged);
    }

    private void OnDisable()
    {
        _ResourcesManager.UnsubscribeAll(this);
    }

    private void OnResourceChanged(uint resourceId, int resourceCount)
    {
        _Text.text = resourceCount.ToString();
    }
}
