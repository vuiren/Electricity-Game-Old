using UnityEngine;

namespace Player
{
    public class PlayerDvoinikSpawner : MonoBehaviour, IRootReader
    {
        [SerializeField] private GameObject dvoinikPrefab;
        PlayerStats playerStats;
        GameObject root;

        public void ReadRoot(GameObject root)
        {
            playerStats = root.GetComponentInChildren<PlayerStats>();
            this.root = root;
        }

        public void TryToSpawn()
        {
            if (playerStats.currentPlayerTool != PlayerToolEnum.Dvoinik)
            {
                return;
            }
            if (Input.GetMouseButtonDown(1) && playerStats.dvoiniksCount > 0)
            {
                if(playerStats.energyInputLookingAt || playerStats.energyOutputLookingAt) { return; }
                playerStats.dvoiniksCount--;
                CmdSpawnDvoinik(playerStats.latestLookAtHit.point, playerStats.latestLookAtHit.normal);
            }
        }

        private void CmdSpawnDvoinik(Vector3 spawnPoint, Vector3 spawnNormal)
        {
            var rotation = Quaternion.FromToRotation(Vector3.forward, spawnNormal.normalized);
            Instantiate(dvoinikPrefab, spawnPoint, rotation);
        }
    }
}
