using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parede : MonoBehaviour
{

    //public KartAgent kartAgent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ParedeManager>() != null)
        {
            //Debug.Log("Bateu na parede");
            other.GetComponent<ParedeManager>().BateuNaParede();
            //other.GetComponent<CheckpointManager>().CheckPointReached(this);
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.GetComponent<CheckpointManager>() != null)
    //    {
    //        //Debug.Log("Ainda está na parede");
    //        kartAgent.AddReward(-0.1f);
    //        //other.GetComponent<CheckpointManager>().CheckPointReached(this);
    //    }
    //}
}
