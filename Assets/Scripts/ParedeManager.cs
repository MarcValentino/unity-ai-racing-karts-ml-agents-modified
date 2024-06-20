using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeManager : MonoBehaviour
{

    public KartAgent kartAgent;

    public void BateuNaParede()
    {
        //Debug.Log("Bateu na parede");
        kartAgent.AddReward(-0.5f);
    }

    public void EstaNaParede()
    {
        //Debug.Log("Bateu na parede");
        kartAgent.AddReward(-0.05f);
    }
}
