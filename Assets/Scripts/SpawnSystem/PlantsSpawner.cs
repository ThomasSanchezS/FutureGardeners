using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Pool;

public class PlantsSpawner : MonoBehaviour
{
    [SerializeField]
    private List<PlantsPool> bluePlantsPool = new List<PlantsPool>();
    [SerializeField]
    private List<PlantsPool> whitePlantsPool = new List<PlantsPool>();
    [SerializeField]
    private List<PlantsPool> redPlantsPool = new List<PlantsPool>();

    [SerializeField]
    private List<GameObject> spawnZones = new List<GameObject>();
    private bool[] spawnersUsed = { false, false,false,false,false,false, false, false, false, false, false, false, false, false, false, false, false, false};
    private int[] spawnZonesUsed = new int[9];
   
    void Start()
    {
        StartSpawn(); 
    }

    private void StartSpawn()
    {
        FindFreeZone(0);
        GameObject plant0 = bluePlantsPool[Random.Range(0, bluePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(0, plant0);

        FindFreeZone(1);
        GameObject plant1 = bluePlantsPool[Random.Range(0, bluePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(1, plant1);

        FindFreeZone(2);
        GameObject plant2 = bluePlantsPool[Random.Range(0, bluePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(2, plant2);

        FindFreeZone(3);
        GameObject plant3 = whitePlantsPool[Random.Range(0, whitePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(3, plant3);

        FindFreeZone(4);
        GameObject plant4 = whitePlantsPool[Random.Range(0, whitePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(4, plant4);

        FindFreeZone(5);
        GameObject plant5 = whitePlantsPool[Random.Range(0, whitePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(5, plant5);

        FindFreeZone(6);
        GameObject plant6 = redPlantsPool[Random.Range(0, redPlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(6, plant6);

        FindFreeZone(7);
        GameObject plant7 = redPlantsPool[Random.Range(0, redPlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(7, plant7);

        FindFreeZone(8);
        GameObject plant8 = redPlantsPool[Random.Range(0, redPlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(8, plant8);
    }

    private void FindFreeZone(int position)
    {
        do
        {
            spawnZonesUsed[position] = (int)Random.Range(0, spawnZones.Count-1);

        } while (spawnersUsed[spawnZonesUsed[position]] == true);

    }
    private void PutAPlantOnGame(int position, GameObject plant)
    {
        plant.transform.position = spawnZones[spawnZonesUsed[position]].transform.position;
        spawnersUsed[spawnZonesUsed[position]] = true;
        plant.SetActive(true);
    }

    public void CallForBluePlant()
    {
        StartCoroutine(SpawnANewBluePlant());
    }

    // Coroutine to spawn waves of plants
    public IEnumerator SpawnANewBluePlant()
    {
        yield return new WaitForSeconds(3f);

    }
}
