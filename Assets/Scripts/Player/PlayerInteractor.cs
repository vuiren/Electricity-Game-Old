using Mirror;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerInteractor : NetworkBehaviour, IRootReader
    {
        PlayerStats playerStats;
        GameObject root;

        // Update is called once per frame
        public void Interact()
        {
            if (playerStats.interactableLookingAt != null && Input.GetMouseButtonDown(0))
            {
                if(isClientOnly)
                {
                    CmdInteract(playerStats.interactableLookingAt.InteractableGameObject().GetComponentInParent<NetworkIdentity>(), root);
                }
                else
                {
                    playerStats.interactableLookingAt.Interact(root);
                }

                if (playerStats.interactableLookingAt.ReturnDvoinikToPlayer())
                {
                    playerStats.dvoiniksCount++;
                }
            }
        }

        [Command]
        public void CmdInteract(NetworkIdentity interactableNI, GameObject interactor)
        {
            interactableNI.GetComponentInChildren<IInteractable>().Interact(interactor);
        }

        public void ReadRoot(GameObject root)
        {
            playerStats = root.GetComponentInChildren<PlayerStats>();
            this.root = root;
        }
    }
}