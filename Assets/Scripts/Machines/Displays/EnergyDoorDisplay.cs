using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Machines
{
    public class EnergyDoorDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshPro displayText;
        [SerializeField] private Material disabledMaterial, enabledMaterial;
        [SerializeField] private Renderer screenRenderer;
       // Machine machine;
        // Use this for initialization
        void Start()
        {
            var machine = GetComponent<Machine>();
            machine.OnEnergyStoredChanged.AddListener(UpdateDisplay);
            UpdateDisplay(machine.EnergyStored);
        }

        private void UpdateDisplay(float energyStored)
        {
            var materials = screenRenderer.materials;
            materials[1] = energyStored == 0 ? disabledMaterial : enabledMaterial; ;
            screenRenderer.SetMaterials(materials.ToList());
            if (energyStored == 0)
            {
                displayText.text = string.Empty;
                return;
            }
        }
    }
}