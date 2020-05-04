using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{
    //our enemy controller class which does what we want when the object is enabled
    public GameObject target;
    public NavMeshAgent agent;
    // Update is called once per frame
    public void OnEnable()
    {
        agent.SetDestination(target.transform.position);
    }

}
