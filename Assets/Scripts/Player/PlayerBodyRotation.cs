using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerBodyRotation : MonoBehaviour, IRootReader
    {
        [SerializeField] private PlayerCameraRotation cameraRotation;
        CharacterController characterController;

        // Update is called once per frame
        public void Rotate()
        {
            characterController.transform.rotation = Quaternion.AngleAxis(cameraRotation.rotation.x, Vector3.up);
        }

        public void ReadRoot(GameObject root)
        {
            characterController = root.GetComponentInChildren<CharacterController>();
        }
    }
}