using UnityEngine;
using MSCLoader;

namespace TommoJProductions.SatsumaPower
{
    public class SatsumaPowerMod : Mod
    {
        // Written, 25.03.2019

        public override string ID => "SatsumaPowerMod";
        public override string Name => "Satsuma Power Mod";
        public override string Version => "0.1";
        public override string Author => "tommojphillips";

        public override void OnLoad()
        {
            // Written, 25.03.2019

            GameObject satsuma = GameObject.Find("SATSUMA(557kg, 248)");
            satsuma.AddComponent<TurboMono>();

            ModConsole.Print(this.Name + ": Loaded");
        }
    }
}
