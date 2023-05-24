using Assets.Scripts.DataModels;
using Assets.Scripts.Helpers;
using Assets.Scripts.Helpers.Interfaces;
using Assets.Scripts.Villagers.Works;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour, IVillagersManager
{
    [SerializeField] private Transform _VillagersContainer;

    [SerializeField] private List<Villager> _VillagersPrefabs;

    private IGridManager _GridManager;

    private BuildingData[] _buildings = new BuildingData[0];
    private List<Villager> _villagers = new List<Villager>();

    // Start is called before the first frame update
    void Awake()
    {
        if (_GridManager == null)
            _GridManager = GetComponentInChildren<IGridManager>();
    }

    private void Start()
    {
        _GridManager.Init(10, 9);
        AddVillager(new Vector2(0, 0));
        AddVillager(new Vector2(0, 0));
        AddVillager(new Vector2(0, 0));
        AddVillager(new Vector2(0, 0));

        _buildings = new BuildingData[]{
            new BuildingData(new GridPosition(-2, 0), GameContext.GameConfig.Buildings[0], true),
            new BuildingData(new GridPosition(-1, 1), GameContext.GameConfig.Buildings[0], true),
            new BuildingData(new GridPosition(0, -2), GameContext.GameConfig.Buildings[0], true),
            new BuildingData(new GridPosition(2, -2), GameContext.GameConfig.Buildings[0], true)
        };
        foreach (BuildingData building in _buildings)
        {
            _GridManager.AddCellObject(building);
        }
    }

    private void Update()
    {
        foreach (Villager villager in _villagers)
        {
            if (villager.WaitingForWork && _buildings.Length > 0)
            {
                IWork work = new WorkConvey(1, _buildings[Random.Range(0, _buildings.Length)]);
                if (work == null)
                    continue;

                villager.SetWork(work);
                work.Begin();

            }
            villager.InvokeWorkStep(Time.deltaTime);
        }
    }

    public void AddVillager(Vector2 position)
    {
        if (_VillagersPrefabs.Count > 0)
        {
            Villager newVillager = Instantiate(_VillagersPrefabs[Random.Range(0, _VillagersPrefabs.Count)], _VillagersContainer);
            newVillager.Setup();
            newVillager.transform.localPosition = new Vector3(position.x, 0, position.y);
            _villagers.Add(newVillager);
        }
    }

    public void OpenMainScene()
    {
        SceneManager.LoadSceneAsync("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
