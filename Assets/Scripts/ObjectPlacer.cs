using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectPlacer : MonoBehaviour
    {
        Camera mainCamera;
        public GameObject objectToPlace;
        // Use this for initialization
        void Start()
        {
            mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}