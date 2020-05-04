using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;
}
public class ObjectPooler1 : MonoBehaviour
{
    public static ObjectPooler1 sharedInstance;
    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;
    

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        //crates the item pools that you want with the size and objects you choose
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        //returns the pooled objects from the list that are not active
        //and have the tag that you requested
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        //expands pool by one if all objects in pool are being used and another
        //is needed and shouldExpand variable is true
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag) 
            { 
                if (item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }    
            }
        }
       
        return null;
       
    }
}
