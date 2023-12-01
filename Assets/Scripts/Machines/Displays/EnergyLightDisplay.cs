using TMPro;
using UnityEngine;

namespace Assets.Scripts.Machines
{
    [RequireComponent(typeof(Machine),typeof(EnergyLightState))]
    public class EnergyLightDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshPro displayText;
        Machine machine;
        EnergyLightState energyLightState;
        // Use this for initialization
        void Start()
        {
            machine= GetComponent<Machine>();
            energyLightState= GetComponent<EnergyLightState>();
        }

        // Update is called once per frame
        void Update()
        {
            if (machine.EnergyStored == 0)
            {
                displayText.text = string.Empty;
                return;
            }

            if (!energyLightState.LightTurnedOn)
            {
                displayText.color = Color.red;
                displayText.text = "OFF";
            }
            else
            {
                if (machine.GotEnoughEnergyToWork)
                {
                    displayText.color = Color.green;
                    displayText.text = "ON";
                }
                else
                {
                    displayText.color = Color.yellow;
                    displayText.text = machine.EnergyStored + "/" + machine.EnergyConsumption;
                }
            }
        }
    }
}