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
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereRadius);
        for(int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].CompareTag("Enemy"))
            {               
                
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hitColliders[i].transform.position);
                          
                elapsed += Time.deltaTime;
                if (elapsed > rate)
                {
                    elapsed -= rate;
                    hitColliders[i].SendMessage("ApplyDamage", damage);
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("enemy");
            other.gameObject.SetActive(false);
        }
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, other.transform.position);
            elapsed += Time.deltaTime;
            if(elapsed > rate)
            {
                elapsed -= rate;
                other.SendMessage("ApplyDamage", 5);
            }
            
        }
    }
    */

}
