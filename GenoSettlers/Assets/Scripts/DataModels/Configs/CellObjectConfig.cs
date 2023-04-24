using Assets.Scripts.Grid;
using Sirenix.Serialization;
using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace Assets.Scripts.DataModels.Configs
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Configs/Cell Object")]
    public class CellObjectConfig : ScriptableObject
    {
        public string ObjectName => _ObjectName;
        public CellObject ObjectPrefab => _ObjectPrefab;

        [SerializeField] private string _ObjectName;
        [SerializeField] private CellObject _ObjectPrefab;
    }
}
