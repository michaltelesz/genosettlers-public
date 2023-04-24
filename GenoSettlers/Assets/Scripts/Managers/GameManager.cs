using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers.Interfaces;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private IGridManager _GridManager;
        private IResourcesManager _ResourcesManager;
        private IVillagersManager _VillagersManager;


        // Start is called before the first frame update
        void Awake()
        {
            if (_GridManager == null)
                _GridManager = GetComponentInChildren<IGridManager>();

            if (_ResourcesManager == null)
                _ResourcesManager = GetComponentInChildren<IResourcesManager>();

            if (_VillagersManager == null)
                _VillagersManager = GetComponentInChildren<IVillagersManager>();
        }

        private void Start()
        {
            _GridManager.Setup(11, 11);
        }
    }
}