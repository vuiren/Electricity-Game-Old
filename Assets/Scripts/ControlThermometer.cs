using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class ControlThemometer : MonoBehaviour
{
    [SerializeField]
    Renderer rend;

    [SerializeField]
    private bool reverse;

    void Update()
    {
        // Animate the Shininess value
        float percent = Mathf.PingPong(Time.time, 1.0f);
        rend.material.SetFloat("_drawPercent", reverse ? 1 - percent : percent);
    }
}