using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MiniGenerator
{
    public class MiniGeneratorAnimator : MonoBehaviour
    {
        [SerializeField] private MiniGeneratorState miniGeneratorState;
        [SerializeField] private Animator animator;

        // Update is called once per frame
        void Update()
        {
            animator.SetBool("following", miniGeneratorState.moving);
        }
    }
}