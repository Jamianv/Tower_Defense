using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    private float elapsed = 0.0f;
    public float spawnRate = 2.0f;
    public float spawnAmount = 1;
    
    //Our Enemy spawner which asks for an enemy from our object pooler
    //and spawns it if it is available. Uses a spawn rate and amount to control
    //how fast units spawn and how many at a time.
    private void Start()
    {
       elapsed = 0.0f;
    }
    void Update()
    {
        Spawn();
    }
    void Spawn()
    {
        elapsed += Time.deltaTime;
        if (elapsed > spawnRate)
        {
            elapsed -= spawnRate;
            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject enemy = ObjectPooler1.sharedInstance.GetPooledObject("Enemy");
                if (enemy != null)
                {
                    //Debug.Log("enemy != null");
                    enemy.transform.position = transform.position;
                    enemy.transform.rotation = Quaternion.identity;
                    enemy.SetActive(true);
                }
            }
        }
    }
}
