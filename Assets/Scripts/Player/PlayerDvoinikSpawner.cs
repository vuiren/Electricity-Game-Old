using Assets.Scripts.Player;
using Mirror;
using UnityEngine;

public class PlayerDvoinikSpawner : NetworkBehaviour, IRootReader
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

    [Command]
    private void CmdSpawnDvoinik(Vector3 spawnPoint, Vector3 spawnNormal)
    {
        var rotation = Quaternion.FromToRotation(Vector3.forward, spawnNormal.normalized);
        var instance = Instantiate(dvoinikPrefab, spawnPoint, rotation);
        NetworkServer.Spawn(instance, root);
    }
}
