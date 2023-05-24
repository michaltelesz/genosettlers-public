using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _ControlsLayer;

    [SerializeField] private Button _Button;

    [SerializeField] private InteractionManager _InteractionManager;

    public void ShowControls()
    {
        _ControlsLayer.SetActive(true);
    }

    public void HideControls()
    {
        _ControlsLayer.SetActive(false);
    }

    public void SelectBuild()
    {
        _InteractionManager.SetState();
    }
}
