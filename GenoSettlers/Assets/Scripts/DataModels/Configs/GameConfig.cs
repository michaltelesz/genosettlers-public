using Assets.Scripts.Grid;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.DataModels.Configs
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Configs/Game Config", order = -1)]
    public class GameConfig : ScriptableObject
    {
        public List<CellObjectConfig> CellObjects => _CellObjects;

        public List<ResourceConfig> Resources => _Resources;

        public List<BuildingConfig> Buildings => _Buildings;

        [InlineEditor]
        [SerializeField]
        List<CellObjectConfig> _CellObjects;

        [InlineEditor]
        [SerializeField]
        List<ResourceConfig> _Resources;

        [InlineEditor]
        [SerializeField]
        List<BuildingConfig> _Buildings;
    }
}