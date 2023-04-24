using Assets.Scripts.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Grid
{
    public abstract class CellObject : MonoBehaviour
    {
        public abstract void Setup(CellObjectData objectData);
    }
}
