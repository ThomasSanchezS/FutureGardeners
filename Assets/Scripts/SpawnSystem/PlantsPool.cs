using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsPool : MonoBehaviour
{
    public string plantInPool;

    private List<GameObject> poolObjects = new List<GameObject>();

    private int amountToPool = 6;
    
    public GameObject objectToSpawn;

    void Awake()
    {
        GeneratePlants();
    }

    //generate and put inactive the plants
    private void GeneratePlants()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToSpawn);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }
    }

    //Return the plant to the spawner
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
