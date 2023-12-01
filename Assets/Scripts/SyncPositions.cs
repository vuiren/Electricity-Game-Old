using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class SyncPositions : MonoBehaviour
    {
        [SerializeField] private Transform playerBody, playerCamera;
        [SerializeField] private Vector3 cameraOffset;

        // Update is called once per frame
        public void Sync()
        {
            playerCamera.position = playerBody.position + cameraOffset;
        }
    }
}