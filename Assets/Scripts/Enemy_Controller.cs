﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{
    //our enemy controller class which does what we want when the object is enabled
    //IMPORTANT make sure not to have both a navmeshagent and a rigidbody2D(non-kinematic)
    //on your game object or you will get undefined behaviour same with NavMesh Agent and 
    //Animator with Root Motion
    public GameObject target;
    public NavMeshAgent agent;
    [SerializeField]
    private int health = 50;

    [SerializeField] GameObject damagePopup;
    GameObject popUp;

    private void Update()
    {
        //if our health = 0 set our object to false in our hierarchy and reset its health to 
        //throw it back into our object pooler.
        if (health == 0)
        {
            gameObject.SetActive(false);
            Destroy(popUp);
            health = 50;
        }
    }
    //Set our navmesh agents destination to our level target position
    public void OnEnable()
    {
        agent.SetDestination(target.transform.position);
    }

    //A public function we can use to apply damage to our enemies
    //We are also spawning our damage popups here should refactor to use object pooler
    public void ApplyDamage(int damage)
    {
        Vector3 randHeight = new Vector3(0, Random.Range(0, 10) * 0.1f, 0);
        popUp = Instantiate(damagePopup, transform.position + randHeight, Quaternion.identity);
        popUp.GetComponent<DamagePopup>().Setup(damage);
        popUp.transform.SetParent(transform);
        health -= damage;
    }

    public void SetHealth(int healthVar)
    {
        health = healthVar;
    }

    public int GetHealth()
    {
        return health;
    }
}
