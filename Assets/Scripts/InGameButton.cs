using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class InGameButton : MonoBehaviour, IInteractable
    {
        [SerializeField] private UnityEvent onClick;
        Renderer firstRenderer;

        private void Awake()
        {
            firstRenderer = GetComponentInChildren<Renderer>();
        }

        public void Interact(GameObject interactor)
        {
            print("interactor: " + interactor.name);
            onClick.Invoke();
        }

        public GameObject InteractableGameObject()
        {
            return gameObject;
        }

        public Renderer RendererToVisualizeAt()
        {
            return firstRenderer;
        }

        public bool ReturnDvoinikToPlayer()
        {
            return false;
        }
    }
}