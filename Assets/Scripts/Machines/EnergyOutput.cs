using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnergyOutput : MonoBehaviour
    {
        public int id;
        public EnergyInput connectedEnergyInput;
        public float transferingEnergy;
        public GameObject connectedMachine;

        public List<Vector3> wirePositions = new List<Vector3>();
        public List<Vector3> wireNormals = new List<Vector3>();

        // Use this for initialization
        void Awake()
        {
            connectedMachine = transform.parent.gameObject;

            if (!connectedMachine)
            {
                Debug.LogWarning("Energy Input not connected " + gameObject.name);
            }
        }

        private void OnDrawGizmos()
        {
            if(connectedEnergyInput!= null)
            {
                Gizmos.DrawLine(gameObject.transform.position, connectedEnergyInput.gameObject.transform.position);
            }
        }
    }
}