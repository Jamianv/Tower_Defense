using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    void FixedUpdate()
    {
        spawn();
    }

    IEnumerator spawn()
    {
        objectPooler.SpawnFromPool("Cube", transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
    }
}
