using Assets.Scripts.DataModels.Configs;
using Mono.Cecil;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers.Structs
{
    [Serializable]
    public class IdAmount
    {
        public uint Id => _Id;
        public int Amount => _Amount;

        [SerializeField]
        [ReadOnly]
        [HorizontalGroup("IdAmount")]
        [LabelWidth(30)]
        protected uint _Id;

        [SerializeField]
        [HorizontalGroup("IdAmount")]
        protected int _Amount;

        public IdAmount(uint id, int amount)
        {
            _Id = id;
            _Amount = amount;
        }

        public virtual int ChangeAmount(int amount, bool clearEmpty = false)
        {
            _Amount += amount;
            if (clearEmpty && _Amount <= 0)
                _Id = 0;

            return amount;
        }
    }
}
