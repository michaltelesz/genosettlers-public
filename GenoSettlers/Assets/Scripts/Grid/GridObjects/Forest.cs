using Assets.Scripts.DataModels;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : CellObject
{
    [SerializeField] private List<Transform> _TreesPrefabs = new List<Transform>();

    private List<Transform> _trees = new List<Transform>();

    public override void Setup(CellObjectData objectData)
    {
        //foreach(Transform child in transform)
        //{
        //    Destroy(child);
        //}

        //for (int i=0;i<tier;i++)
        //{
        //    float size = Random.Range(progress / (i + 1), progress);
        //    float radius = Random.Range(0, HexMetrics.innerRadius);
        //    float angle = Random.Range(0, 2 * Mathf.PI);
        //    Vector3 position = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
        float rotation = Random.Range(0, 360);
        //    Transform tree = Instantiate(_TreesPrefabs[Random.Range(0, _TreesPrefabs.Count)], transform);
        //    tree.localScale = Vector3.one * size;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        //    tree.localPosition = position;
            
        //}
    }
}
