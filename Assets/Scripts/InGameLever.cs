using UnityEngine;

namespace Assets.Scripts
{
    public class InGameLever : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Renderer handleRenderer;
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