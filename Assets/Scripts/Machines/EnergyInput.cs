using UnityEngine;

namespace Assets.Scripts
{
    public class EnergyInput : MonoBehaviour
    {
        public GameObject connectedMachine;

        // Use this for initialization
        void Awake()
        {
            connectedMachine = transform.parent.gameObject;

            if (!connectedMachine)
            {
                Debug.LogWarning("Energy Input not connected " + gameObject.name);
            }
        }
    }
}