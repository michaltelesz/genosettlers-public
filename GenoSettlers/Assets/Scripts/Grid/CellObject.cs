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
        protected CellObjectData _objectData;
        public virtual void Setup(CellObjectData objectData) {
            _objectData = objectData;
        }

        private void OnEnable()
        {
            if (_objectData != null)
                _objectData.CellObjectDataChanged += CellObjectDataChanged;
        }

        private void OnDisable()
        {
            if (_objectData != null)
                _objectData.CellObjectDataChanged -= CellObjectDataChanged;
        }

        protected virtual void CellObjectDataChanged(object sender, CellObjectChangedEventArgs e)
        {
        }
    }
}
