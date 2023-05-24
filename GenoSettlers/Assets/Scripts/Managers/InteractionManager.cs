using Assets.Scripts.DataModels;
using Assets.Scripts.Grid.GridObjects.Buildings;
using Assets.Scripts.Helpers;
using Assets.Scripts.Helpers.Interfaces;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Managers
{
    public class InteractionManager : MonoBehaviour
    {
        private IGridManager _gridManager;
        private IVillagersManager _villagersManager;

        private InteractionControls _inputActions;

        private States _currentState;
        private Building _buildingInstance;

        private enum States
        {
            None = 0,
            Build = 1
        }

        public void Init(IGridManager gridManager, IVillagersManager villagersManager)
        {
            _gridManager = gridManager;
            _villagersManager = villagersManager;
        }

        private void OnEnable()
        {
            _inputActions = new InteractionControls();
            _inputActions.UI.Click.performed += Click_performed;
            _inputActions.UI.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }

        private void Update()
        {
            if (_currentState == States.Build)
            {
                RaycastHit hit;
                Vector3 coor = Mouse.current.position.ReadValue();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(coor), out hit))
                {
                    GridPosition gridPosition = GridPosition.FromPixels(hit.point);
                    if (!_gridManager.HasGridObject(gridPosition))
                    {
                        if (_buildingInstance == null)
                        {
                            _buildingInstance = Instantiate(GameContext.GameConfig.Buildings[0].BuildingPrefab, transform);
                        }
                        _buildingInstance.transform.position = gridPosition.ToPixels();
                    }
                }
                
            }
        }

        private void Click_performed(InputAction.CallbackContext ctx)
        {
            if (_gridManager == null || _currentState == States.None)
                return;

            RaycastHit hit;
            Vector3 coor = Mouse.current.position.ReadValue();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(coor), out hit))
            {
                BuildingData building = new BuildingData(GridPosition.FromPixels(hit.point), GameContext.GameConfig.Buildings[0]);
                _gridManager.AddCellObject(building);
            }
        }

        internal void SetState()
        {
            _currentState = States.Build;
        }
    }
}
