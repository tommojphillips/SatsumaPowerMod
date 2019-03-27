using UnityEngine;
using MSCLoader;

namespace TommoJProductions.SatsumaPower
{
    internal class TurboMono : MonoBehaviour
    {
        // Written, 25.03.2019

        internal float initialRpm = 2500f;
        internal float rpmAtMaxBoost = 6400f;
        internal float boost = 7f;
        private float boostMultiplier = 0.00016f;
        private Drivetrain drivetrain = null;

        private void Start()
        {
            // Written, 25.03.2019
            
#if DEBUG
            ModConsole.Print(nameof(TurboMono) + ": Started");
#endif
        }
        private void LateUpdate()
        {
            // Written, 25.03.2019

            this.drivetrain = this.gameObject.GetComponent<Drivetrain>();

            if (this.drivetrain.rpm > this.initialRpm)
            {
                if (this.drivetrain.rpm > this.rpmAtMaxBoost)
                {
                    this.drivetrain.powerMultiplier = (this.rpmAtMaxBoost * this.boostMultiplier) + (this.boost * 0.1f);
                }
                else
                {
                    this.drivetrain.powerMultiplier = (this.drivetrain.rpm * this.boostMultiplier) + (this.boost * 0.1f);
                }
            }
        }
        private void OnGUI()
        {
            // Written, 25.03.2019

            if (PlayMakerGlobals.Instance.Variables.FindFsmString("PlayerCurrentVehicle").Value == "Satsuma")
            {
                using (new GUILayout.AreaScope(new Rect(Screen.width - 270, Screen.height - 120, 250, 100), "", new GUIStyle() { fontSize = 18 }))
                {
                    GUILayout.Label("Max Power: " + this.drivetrain.maxPower);
                    GUILayout.Label("Power Multiplier: " + this.drivetrain.powerMultiplier);
                    GUILayout.Label("Rpm: " + this.drivetrain.rpm);
                    GUILayout.Label("Speed: " + PlayMakerGlobals.Instance.Variables.FindFsmFloat("SpeedKMH").Value);
                }
            }
        }
    }
}
