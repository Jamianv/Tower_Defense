using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyEnter : MonoBehaviour
{
    //our enemy goal class which disables enemy objects once they collide
    //with the goal gameobject
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.SendMessage("SetHealth", 50);
            other.gameObject.SetActive(false);
        }
    }
}
