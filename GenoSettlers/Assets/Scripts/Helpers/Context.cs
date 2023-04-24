using Assets.Scripts.DataModels.Configs;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    public static class Context
    {
        private static GameConfig _GameConfig;

        [CanBeNull]
        public static GameConfig GameConfig
        {
            get
            {
                if (_GameConfig == null)
                {
                    _GameConfig = UnityEngine.Resources.Load<GameConfig>("Data/Configs/_GameConfig");
                }
                return _GameConfig;
            }

        }
    }
}
