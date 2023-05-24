using Assets.Scripts.Helpers.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VillagersManager : MonoBehaviour, IVillagersManager
{
    [SerializeField] private Transform _VillagersContainer;

    [SerializeField] private List<Villager> _VillagersPrefabs;

    //TODO Switch to IVillager interface without MonoBehaviour instantiation
    private List<Villager> _villagers = new List<Villager>();

    private List<IWork> _works = new List<IWork>();

    public void AddVillager(Vector2 position)
    {
        if(_VillagersPrefabs.Count > 0)
        {
            Villager newVillager = Instantiate(_VillagersPrefabs[Random.Range(0, _VillagersPrefabs.Count())], _VillagersContainer);
            newVillager.Setup();
            newVillager.transform.localPosition = new Vector3(position.x, 0, position.y);
            _villagers.Add(newVillager);
        }   
    }

    private void Update()
    {
        foreach(Villager villager in _villagers)
        {
            if(villager.WaitingForWork)
            {
                IWork work = GetNextWork();
                if (work == null)
                    continue;

                villager.SetWork(work);
                work.Begin();

            }
            villager.InvokeWorkStep(Time.deltaTime);
        }
    }

    private IWork GetNextWork()
    {
        return _works.FirstOrDefault(w => !w.InProgress);
    }

    internal void AddWork(IWork work)
    {
        _works.Add(work);
    }
}
