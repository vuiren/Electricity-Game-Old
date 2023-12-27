using UnityEngine;

namespace Player
{
    public class PlayerInteractor : MonoBehaviour, IRootReader
    {
        PlayerStats playerStats;
        GameObject root;

        // Update is called once per frame
        public void Interact()
        {
            if (playerStats.interactableLookingAt != null && Input.GetMouseButtonDown(0))
                playerStats.interactableLookingAt.Interact(root);

            if (playerStats.interactableLookingAt != null &&  playerStats.interactableLookingAt.ReturnDvoinikToPlayer())
            {
                playerStats.dvoiniksCount++;
            }
        }

        public void ReadRoot(GameObject root)
        {
            playerStats = root.GetComponentInChildren<PlayerStats>();
            this.root = root;
        }
    }

}