using Mirror;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class InGameLever : NetworkBehaviour, IInteractable
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Renderer handleRenderer;
        [SyncVar]
        public bool activated;

        public void Interact(GameObject interactor)
        {
            activated = !activated;
        }

        private void Update()
        {
            animator.SetBool("activated", activated);
        }

        public GameObject InteractableGameObject()
        {
            return gameObject;
        }

        public Renderer RendererToVisualizeAt()
        {
            return handleRenderer;
        }

        public bool ReturnDvoinikToPlayer()
        {
            return false;
        }
    }
}