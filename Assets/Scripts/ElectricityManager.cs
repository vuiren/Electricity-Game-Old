using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NaughtyAttributes;

namespace Assets.Scripts
{
    public class ElectricityManager : MonoBehaviour
    {
        private readonly HashSet<GameObject> visitedMachines = new();

        private void shit(GameObject a, ref float energy, List<Machine> affectedMachines, HashSet<GameObject> visitedObjects)
        {
            if (visitedObjects.Contains(a)) return;
            visitedObjects.Add(a);
            var stack = new Stack<IEnergyEmitter>(a.GetComponents<IEnergyEmitter>());
            while (stack.Count > 0)
            {
                var emitter = stack.Pop();
                if (!emitter.EnergyOutput.connectedMachine)
                    continue;

                if (!emitter.EnergyOutput.connectedEnergyInput || !emitter.EnergyOutput.connectedEnergyInput.connectedMachine) continue;

                if (emitter.EnergyOutput.connectedEnergyInput.connectedMachine.TryGetComponent(out Machine machine))
                {
                    affectedMachines.Add(machine);
                    if(machine.EnergyStored < machine.EnergyConsumption)
                    {
                        machine.EnergyStored = Mathf.Clamp(energy, energy, machine.EnergyConsumption);
                        energy -= machine.EnergyStored;
                        energy = Mathf.Clamp(energy, 0, energy);
                    }
                }

                shit(emitter.EnergyOutput.connectedEnergyInput.connectedMachine, ref energy, affectedMachines, visitedObjects);
            }
        }

        [Button]
        public void TransferEnergy()
        {
            var machines = FindObjectsOfType<Machine>();
            foreach (var machine in machines)
            {
                machine.EnergyStored = 0;
                machine.energyLeftInSystem = 0;
            }
            var generators = FindObjectsOfType<Generator>();
            var affectedMachines = new List<Machine>(); 

            foreach (var generator in generators)
            {
                affectedMachines.Clear();
                visitedMachines.Clear();
                generator.generatedEnergy = generator.energyGeneration;
                shit(generator.gameObject, ref generator.generatedEnergy, affectedMachines, visitedMachines);

                foreach(var machine in affectedMachines)
                {
                    machine.energyLeftInSystem += generator.generatedEnergy;
                }
            }
        }
    }
}