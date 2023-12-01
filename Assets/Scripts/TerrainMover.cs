using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class TerrainMover : MonoBehaviour
    {
        [SerializeField] private Transform terrain;
        [SerializeField] private float moveSpeed, xToTeleport;
        [SerializeField] private Vector3 moveVector;

        // Update is called once per frame
        void Update()
        {
            terrain.position += moveSpeed * Time.deltaTime * moveVector;
            if(terrain.position.x > xToTeleport )
            {
                terrain.position = new Vector3(-900, terrain.position.y, terrain.position.z);
            }
        }
    }
}