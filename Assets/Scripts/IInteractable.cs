using UnityEngine;

namespace Assets.Scripts
{
    public interface IInteractable
    {
        public void Interact(GameObject interactor);
        public GameObject InteractableGameObject();
        public Renderer RendererToVisualizeAt();
        public bool ReturnDvoinikToPlayer();
    }
}
