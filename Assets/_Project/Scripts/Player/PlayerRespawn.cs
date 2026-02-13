using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 _lastCheckpointPosition;

    private void Start()
    {
        _lastCheckpointPosition = transform.position;
    }

    public void SetCheckpoint(Vector3 newPosition)
    {
        _lastCheckpointPosition = newPosition;
        Debug.Log("Checkpoint salvato!");
    }

    public void Respawn()
    {
        transform.position = _lastCheckpointPosition;
    }
}
