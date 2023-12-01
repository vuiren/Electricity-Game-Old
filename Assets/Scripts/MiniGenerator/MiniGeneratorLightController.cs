using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MiniGenerator
{
    public class MiniGeneratorLightController : MonoBehaviour
    {
        [SerializeField] private MiniGeneratorState miniGeneratorState;
        [SerializeField] private Light[] standByLights, followingLights;

        bool followedPlayerPreviousFrame;
        private void Update()
        {
            if (miniGeneratorState.moving && !followedPlayerPreviousFrame)
            {
                foreach (var light in standByLights)
                {
                    light.enabled = false;
                }

                foreach (var light in followingLights)
                {
                    light.enabled = true;
                }
            }

            if (!miniGeneratorState.moving && followedPlayerPreviousFrame)
            {
                foreach (var light in standByLights)
                {
                    light.enabled = true;
                }

                foreach (var light in followingLights)
                {
                    light.enabled = false;
                }
            }

            followedPlayerPreviousFrame = miniGeneratorState.moving;
        }
    }
}