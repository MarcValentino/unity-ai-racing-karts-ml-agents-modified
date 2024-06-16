using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public float MaxTimeToReachNextCheckpoint = 10f;
    public float TimeLeft = 10f;

    public float TimeOnTrack = 0f;

    public KartAgent kartAgent;
    public Checkpoint nextCheckPointToReach;

    private int CurrentCheckpointIndex;
    private List<Checkpoint> Checkpoints;
    private Checkpoint lastCheckpoint;


    public event Action<Checkpoint> reachedCheckpoint;

    void Start()
    {
        Checkpoints = FindObjectOfType<Checkpoints>().checkPoints;
        ResetCheckpoints();
    }

    public void ResetCheckpoints()
    {
        CurrentCheckpointIndex = 0;
        TimeLeft = MaxTimeToReachNextCheckpoint;

        SetNextCheckpoint();
    }

    private void Update()
    {
        TimeLeft -= Time.deltaTime;
        TimeOnTrack += Time.deltaTime;

        if (TimeLeft < 0f)
        {
            kartAgent.AddReward(-1f);
            kartAgent.EndEpisode();
        }
    }

    public void CheckPointReached(Checkpoint checkpoint)
    {
        if (nextCheckPointToReach != checkpoint) return;

        lastCheckpoint = Checkpoints[CurrentCheckpointIndex];
        reachedCheckpoint?.Invoke(checkpoint);
        CurrentCheckpointIndex++;

        if (CurrentCheckpointIndex >= Checkpoints.Count)
        {
            kartAgent.AddReward(5f);
            kartAgent.AddReward(100 / TimeOnTrack);
            Debug.Log(100 / TimeOnTrack);
            TimeOnTrack = 0f;

            kartAgent.EndEpisode();
        }
        else
        {
            kartAgent.AddReward((5f) / Checkpoints.Count);
            SetNextCheckpoint();
        }
    }

    private void SetNextCheckpoint()
    {
        if (Checkpoints.Count > 0)
        {
            TimeLeft = MaxTimeToReachNextCheckpoint;
            nextCheckPointToReach = Checkpoints[CurrentCheckpointIndex];

        }
    }
}
