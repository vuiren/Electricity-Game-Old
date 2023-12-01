using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Machines
{
    public class MachineOutputIdsAssigner : MonoBehaviour
    {
        private void OnValidate()
        {
            var outputs = GetComponentsInChildren<EnergyOutput>();
            for (int i = 0; i < outputs.Length; i++)
            {
                EnergyOutput output = outputs[i];
                output.id = i;
            }
        }
    }
}