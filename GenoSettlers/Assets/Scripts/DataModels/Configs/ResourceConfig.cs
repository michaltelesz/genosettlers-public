using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.DataModels.Configs
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Configs/Resource")]
    public class ResourceConfig : IndexedConfig
    {
        public ResourcePile ResourcePilePrefab => _ResourcePilePrefab;

        public int StackSize => _StackSize;

        [SerializeField] private ResourcePile _ResourcePilePrefab;
        [SerializeField] private int _StackSize;
    }
}