using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 lastCheckpointPosition;

    private void Start()
    {
        lastCheckpointPosition = transform.position;
    }

    public void SetCheckpoint(Vector3 newPosition)
    {
        lastCheckpointPosition = newPosition;
        Debug.Log("Checkpoint salvato!");
    }

    public void Respawn()
    {
        transform.position = lastCheckpointPosition;
    }
}
