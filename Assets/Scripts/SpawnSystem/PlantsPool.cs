using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsPool : MonoBehaviour
{
    public string plantInPool;

    private List<GameObject> poolObjects = new List<GameObject>();

    public int amountToPool = 4;
    
    public GameObject objectToSpawn;

    void Awake()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToSpawn);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }

    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }

        return null;
    }
}
