using UnityEngine;

namespace Player
{
    public class PlayerSettings : MonoBehaviour
    {
        [Header("Movement")]
        public CharacterController characterController;
        public float moveSpeed = 5f, gravity = 10;

        [Header("Mini Genrator Calling")]
        public Transform callPoint;

        [Header("Other")]
        public float playerHeight = 1f;
        public GameObject dvoinikPreviewInstance;
        public Animator playerCharacterAnimator;
        public Camera playerCamera;
    }
}