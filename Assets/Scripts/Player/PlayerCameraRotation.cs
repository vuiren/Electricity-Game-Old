using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerCameraRotation : MonoBehaviour
    {
        public float Sensitivity
        {
            get { return sensitivity; }
            set { sensitivity = value; }
        }

        [SerializeField] public GameObject playerCamera;
        [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
        [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
        [Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

        public Vector2 rotation = Vector2.zero;
        const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
        const string yAxis = "Mouse Y";

        public void RotateCamera()
        {
            rotation.x += Input.GetAxis(xAxis) * sensitivity;
            rotation.y += Input.GetAxis(yAxis) * sensitivity;
            rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
            var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
            var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

            playerCamera.transform.localRotation = xQuat * yQuat;
        }
    }
}