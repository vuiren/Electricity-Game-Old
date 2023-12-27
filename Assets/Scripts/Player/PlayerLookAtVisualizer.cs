using UnityEngine;

namespace Player
{
    public class PlayerLookAtVisualizer : MonoBehaviour, IRootReader
    {
        [SerializeField] private Material defaultMaterial, lookMaterial;

        PlayerStats playerStats;
        Renderer energyOutputRenderer, energyInputRenderer, interactableRenderer;

        public void ReadRoot(GameObject root)
        {
            playerStats = root.GetComponentInChildren<PlayerStats>();
        }

        // Update is called once per frame
        public void Visualize()
        {
            if (energyOutputRenderer)
            {
                energyOutputRenderer.material = defaultMaterial;
            }

            if(energyInputRenderer)
            {
                energyInputRenderer.material = defaultMaterial;
            }

            if(interactableRenderer)
            {
                interactableRenderer.material = defaultMaterial;
            }

            if (playerStats.interactableLookingAt != null)
            {
                interactableRenderer = playerStats.interactableLookingAt.RendererToVisualizeAt();
                interactableRenderer.material = lookMaterial;
            }

            if (playerStats.energyOutputLookingAt && !playerStats.SelectedOutput)
            {
                energyOutputRenderer = playerStats.energyOutputLookingAt.GetComponentInChildren<Renderer>();
                energyOutputRenderer.material = lookMaterial;
            }

            if (playerStats.SelectedOutput)
            {
                energyOutputRenderer.material = lookMaterial;
            }

            if (playerStats.SelectedOutput && playerStats.energyInputLookingAt)
            {
                energyInputRenderer = playerStats.energyInputLookingAt.GetComponentInChildren<Renderer>();
                energyInputRenderer.material = lookMaterial;
            }
        }
    }
}