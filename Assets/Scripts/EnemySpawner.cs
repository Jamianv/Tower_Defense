using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Our Enemy spawner which asks for an enemy from our object pooler
    //and spawns it if it is available
    //ObjectPooler1 objectPooler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //Enemies are just being spawned through the mouse button know
        //todo: need to edit enemy spawning to be triggered at certain times
        //and release a specific amount of enemies
        if (Input.GetKeyDown("e"))
        {
            GameObject enemy = ObjectPooler1.sharedInstance.GetPooledObject("Enemy");
            if (enemy != null)
            {
                Debug.Log("enemy != null");
                enemy.transform.position = transform.position;
                enemy.transform.rotation = Quaternion.identity;
                enemy.SetActive(true);

            }
        }
        //StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        
        
        yield return new WaitForSecondsRealtime(5);

    }

    
}
