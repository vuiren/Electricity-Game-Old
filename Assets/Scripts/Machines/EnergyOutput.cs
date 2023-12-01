using Mirror;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnergyOutput : NetworkBehaviour
    {
        public int id;
        public EnergyInput connectedEnergyInput;
        public float transferingEnergy;
        public GameObject connectedMachine;

        public readonly SyncList<Vector3> wirePositions = new SyncList<Vector3>();
        public readonly SyncList<Vector3> wireNormals = new SyncList<Vector3>();

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