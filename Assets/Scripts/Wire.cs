using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public EnergyOutput from;
    public EnergyInput to;

    [SerializeField] private GameObject plugPrefab;

    LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        if (!lineRenderer || !from || !to) { return; }
        var middlePoint = GetMiddlePoint(from.transform.position, to.transform.position);
        middlePoint.y -= Random.Range(0.17f, 0.21f);

        if (from.wirePositions != null && from.wirePositions.Count > 0)
        {
            lineRenderer.positionCount = from.wirePositions.Count;
            lineRenderer.SetPositions(from.wirePositions.ToArray());

            for (int i = 1; i < from.wirePositions.Count - 1; i++)
            {
                Vector3 position = from.wirePositions[i];
                Instantiate(plugPrefab, position, Quaternion.FromToRotation(Vector3.up, from.wireNormals[i - 1]), transform);
                lineRenderer.SetPosition(i, position + from.wireNormals[i - 1] * 0.006f);
            }
        }
        else
        {
            lineRenderer.positionCount = 3;
            lineRenderer.SetPositions(new Vector3[3] { from.transform.position, middlePoint, to.transform.position });
        }
    }

    private Vector3 GetMiddlePoint(Vector3 vector1, Vector3 vector2)
    {
        var middlePoint = vector1 + vector2;
        middlePoint.x /= 2;
        middlePoint.y /= 2;
        middlePoint.z /= 2;

        return middlePoint;
    }

    private void OnDrawGizmos()
    {
        if (!from || !to) return;

        Gizmos.DrawLine(from.transform.position, to.transform.position);
    }
}
