using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerBuildingPreviewWorker : PlayerComponent
    {
        public override void Construct(PlayerSettings playerSettings, PlayerStats playerStats)
        {
            base.Construct(playerSettings, playerStats);
        }

        public void DrawPreview()
        {
            var previewObject = PlayerSettings.dvoinikPreviewInstance;
            previewObject.SetActive(PlayerStats.currentPlayerTool == PlayerToolEnum.Dvoinik);
            if (PlayerStats.currentPlayerTool != PlayerToolEnum.Dvoinik) return;

            previewObject.transform.position = PlayerStats.latestLookAtHit.point;
            var rotation = Quaternion.FromToRotation(Vector3.forward, PlayerStats.latestLookAtHit.normal);
            previewObject.transform.rotation = rotation;
        }
    }
}