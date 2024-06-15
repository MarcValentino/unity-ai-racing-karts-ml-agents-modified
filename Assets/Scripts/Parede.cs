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

            other.GetComponent<ParedeManager>().BateuNaParede();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ParedeManager>() != null)
        {

            other.GetComponent<ParedeManager>().EstaNaParede();
        }
    }
}
