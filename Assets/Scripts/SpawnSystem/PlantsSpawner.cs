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
    private int[] spawnZonesUsed = new int[18];

    private int timeBetweenNewPlants = 5;
   
    void Start()
    {
        StartSpawn();

        //ReSpawnSystem
        CallForNewPlants();
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

    //Aquí comienza el ReSpawnsysten improvisado

    public void CallForNewPlants()
    {
        StartCoroutine(SpawnNewPlants());
    }

    // Coroutine to spawn waves of plants
    public IEnumerator SpawnNewPlants()
    {
        yield return new WaitForSeconds(timeBetweenNewPlants);

        FindFreeZone(9);
        GameObject plant0 = bluePlantsPool[Random.Range(0, bluePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(9, plant0);

        yield return new WaitForSeconds(timeBetweenNewPlants);

        FindFreeZone(10);
        GameObject plant3 = whitePlantsPool[Random.Range(0, whitePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(10, plant3);

        yield return new WaitForSeconds(timeBetweenNewPlants);

        FindFreeZone(11);
        GameObject plant8 = redPlantsPool[Random.Range(0, redPlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(11, plant8);

        yield return new WaitForSeconds(timeBetweenNewPlants);

        FindFreeZone(12);
        GameObject plant1 = bluePlantsPool[Random.Range(0, bluePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(12, plant1);

        yield return new WaitForSeconds(timeBetweenNewPlants);

        FindFreeZone(13);
        GameObject plant5 = whitePlantsPool[Random.Range(0, whitePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(13, plant5);

        yield return new WaitForSeconds(timeBetweenNewPlants);

        FindFreeZone(14);
        GameObject plant6 = redPlantsPool[Random.Range(0, redPlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(14, plant6);

        yield return new WaitForSeconds(timeBetweenNewPlants);

        FindFreeZone(15);
        GameObject plant2 = bluePlantsPool[Random.Range(0, bluePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(2, plant2);

        yield return new WaitForSeconds(timeBetweenNewPlants);

        FindFreeZone(16);
        GameObject plant4 = whitePlantsPool[Random.Range(0, whitePlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(4, plant4);

        yield return new WaitForSeconds(timeBetweenNewPlants);

        FindFreeZone(17);
        GameObject plant7 = redPlantsPool[Random.Range(0, redPlantsPool.Count)].GetPooledObject();
        PutAPlantOnGame(17, plant7);

    }
}
