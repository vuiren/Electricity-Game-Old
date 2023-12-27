using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class StretchingHandController : MonoBehaviour
{
    [SerializeField] private Transform root, endBone;
    [SerializeField] private float scaleSpeed = 5;
    [SerializeField] private Transform target;

    Vector3 targetScale;
    // Start is called before the first frame update
    void Start()
    {
        targetScale = endBone.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        root.LookAt(target.position);
        endBone.localScale = Vector3.MoveTowards(endBone.localScale, targetScale, Time.deltaTime * scaleSpeed);
        endBone.position = Vector3.MoveTowards(endBone.position, target.position / 1.5f, Time.deltaTime * scaleSpeed);
    }

    [Button]
    private void ScaleDown()
    {
        targetScale /= 1.5f;
    }
}
