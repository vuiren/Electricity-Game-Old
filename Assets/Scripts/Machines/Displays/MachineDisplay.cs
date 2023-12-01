using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Machines
{
    [RequireComponent(typeof(Machine))]
    public class MachineDisplay : MonoBehaviour
    {
        protected Machine machine;
        [SerializeField] protected TextMeshPro displayText;

        protected void Awake()
        {
            machine = GetComponent<Machine>();
        }

        // Update is called once per frame
        protected void Update()
        {
            UpdateText();
        }

        protected virtual void UpdateText()
        {
            if(machine.EnergyStored == 0)
            {
                displayText.text = string.Empty;
                return;
            }
            displayText.color = machine.GotEnoughEnergyToWork ? Color.green : Color.yellow;
            displayText.text = machine.EnergyStored.ToString() + "/" + machine.EnergyConsumption.ToString();
        }
    }
}