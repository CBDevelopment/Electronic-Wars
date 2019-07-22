using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class GameState
    {
        public static int UpgradeLevel { get; set; }

        //0: TV
        //1: Plasma
        public static int CurrentLevel { get; set; }

        public static void IncrementLevel()
        {
            UpgradeLevel = 1;
            CurrentLevel = 1;
        }
    }
}
