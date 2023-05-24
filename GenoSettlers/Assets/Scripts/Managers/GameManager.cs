using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers.Interfaces;
using Assets.Scripts.Helpers.Interfaces.Resources;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private IGridManager _GridManager;
        private IResourcesManager _ResourcesManager;
        private IVillagersManager _VillagersManager;
        private InteractionManager _InteractionManager;


        // Start is called before the first frame update
        void Awake()
        {
            if (_GridManager == null)
                _GridManager = GetComponentInChildren<IGridManager>();

            if (_ResourcesManager == null)
                _ResourcesManager = GetComponentInChildren<IResourcesManager>();

            if (_VillagersManager == null)
                _VillagersManager = GetComponentInChildren<IVillagersManager>();

            if (_InteractionManager == null)
                _InteractionManager = GetComponentInChildren<InteractionManager>();
        }

        private void Start()
        {
            _InteractionManager.Init(_GridManager, _VillagersManager);

            _GridManager.Init(11, 9);
            _VillagersManager.AddVillager(new Vector2(15, 15));
            _VillagersManager.AddVillager(new Vector2(15, -15));
            _VillagersManager.AddVillager(new Vector2(-15, 15));

            ResourcesStackData resourcesStack1 = new ResourcesStackData(new GridPosition(-2, 0), _ResourcesManager);
            ResourcesStackData resourcesStack2 = new ResourcesStackData(new GridPosition(1, 2), _ResourcesManager);
            resourcesStack1.ChangeResourceAmount(1, 6);
            resourcesStack2.ChangeResourceAmount(1, 12);
            _GridManager.AddCellObject(resourcesStack1);
            _GridManager.AddCellObject(resourcesStack2);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}