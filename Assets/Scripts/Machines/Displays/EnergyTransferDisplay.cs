using TMPro;
using UnityEngine;

namespace Assets.Scripts.Machines
{
    [RequireComponent(typeof(Machine))]
    public class EnergyTransferDisplay : MonoBehaviour
    {
        Machine machine;
        [SerializeField] private TextMeshPro displayText;
        // Use this for initialization
        void Start()
        {
            machine = GetComponent<Machine>();
            displayText.color = Color.yellow;
        }

        // Update is called once per frame
        void Update()
        {
            displayText.text = machine.energyLeftInSystem == 0 ? string.Empty : machine.energyLeftInSystem.ToString();
        }
    }
}