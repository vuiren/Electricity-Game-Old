using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class MachineEnergyText : MonoBehaviour
    {
        [SerializeField] TextMeshPro energyText;
        Machine machine;
        private void Awake()
        {
            machine= GetComponent<Machine>();
        }

        // Update is called once per frame
        void Update()
        {
            energyText.text = machine.EnergyConsumption.ToString() + "/"+machine.EnergyStored.ToString();
        }
    }
}