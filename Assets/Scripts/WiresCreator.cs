using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts
{
    internal class WiresCreator : MonoBehaviour
    {
        [SerializeField] private Wire wirePrefab;

        [Button]
        public void ReCreateWires()
        {
            var wires = FindObjectsOfType<Wire>();
            foreach (var w in wires)
            {
                Destroy(w.gameObject);
            }

            var outputs = FindObjectsOfType<EnergyOutput>();
            foreach (var output in outputs)
            {
                if (!output.connectedEnergyInput) continue;

                var wire = Instantiate(wirePrefab.gameObject).GetComponent<Wire>();
                wire.from = output;
                wire.to = output.connectedEnergyInput;
            }
        }
    }
}
