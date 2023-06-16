using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    public Checkpoint[] checkpoints;

    public Vector3 spawnpoint;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnpoint = Movimiento.instance.transform.position;
    }
    public void DeactivateCheckpoints()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }
    public void SetSpawnPoint(Vector3 newSpawnpoint)
    {
        spawnpoint = newSpawnpoint;
    }
    
}
