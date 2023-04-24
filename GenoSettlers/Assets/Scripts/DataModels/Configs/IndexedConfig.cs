using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DataModels.Configs
{
    public abstract class IndexedConfig : ScriptableObject
    {
        public uint Id => _Id;

        [SerializeField] private uint _Id;
    }
}
