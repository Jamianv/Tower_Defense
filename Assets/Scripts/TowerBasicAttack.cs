using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBasicAttack : MonoBehaviour
{
    private float elapsed = 0.0f;
    public float rate = 0.1f;
    private LineRenderer line;
    public float sphereRadius = 3.0f;
    public int damage = 5;
    private bool enable = true;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }
    
    private void Update()
    {
        CollisionCheck();
        if (enable)
        {
            line.enabled = true;
        }
        else
        {
            line.enabled = false;
        }
    }
    
    //Creates a physics overlap sphere and stores the collisions in hitColliders[] then we go through
    //the hitcolliders[] and check if we have an enemy, if we do we draw a line enable line renderer 
    //call applyDamage function and stop checking colliders. If not we disable the line renderer
    private void CollisionCheck()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereRadius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag("Enemy"))
            {
                enable = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hitColliders[i].transform.position);

                elapsed += Time.deltaTime;
                if (elapsed > rate)
                {
                    elapsed -= rate;
                    hitColliders[i].SendMessage("ApplyDamage", damage);
                }
                break;
            }
            enable = false;
        }
    }

    //Just draws a sphere to show where our overlap sphere is
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
}
