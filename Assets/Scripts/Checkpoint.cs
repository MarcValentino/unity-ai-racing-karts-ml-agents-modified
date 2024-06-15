using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CheckpointManager>() != null)
        {
            //Debug.Log("Passou no checkpoint");
            other.GetComponent<CheckpointManager>().CheckPointReached(this);
        }
    }
}
