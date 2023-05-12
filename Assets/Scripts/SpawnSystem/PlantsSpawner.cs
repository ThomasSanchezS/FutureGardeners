using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlantsSpawner : MonoBehaviour
{
    [SerializeField]
    private List<PlantsPool> nG = new List<PlantsPool>();
    [SerializeField]
    private List<PlantsPool> bG = new List<PlantsPool>();
    [SerializeField]
    private List<PlantsPool> rG = new List<PlantsPool>();

    private Vector3 startPosition;

    public int movementStep = 5, spawnCount= 5;
   
   
    void Start()
    {
        startPosition= transform.position;
        StartCoroutine(SpawnRound());
    }

    public IEnumerator SpawnRound()
    {
        for(int i = 0;i < spawnCount+1; i++) 
        {
            Spawn();
            yield return new WaitForSeconds(3f);
        }
    }

    //Spawn the groups of platforms
    private void Spawn()
    {
        int groupType = Random.Range(1, 4);

        switch (groupType)
        {
            case 1:
                GameObject GroupOfPlatforms1 = nG[Random.Range(0, nG.Count)].GetPooledObject();
                if (GroupOfPlatforms1 != null)
                {
                    GroupOfPlatforms1.transform.position = transform.position;
                    GroupOfPlatforms1.SetActive(true);
                }
                break;

            case 2:
                GameObject GroupOfPlatforms2 = bG[Random.Range(0, bG.Count)].GetPooledObject();
                if (GroupOfPlatforms2 != null)
                {
                    GroupOfPlatforms2.transform.position = transform.position;
                    GroupOfPlatforms2.SetActive(true);
                }
                break;

            case 3:
                GameObject GroupOfPlatforms3 = bG[Random.Range(0, bG.Count)].GetPooledObject();
                if (GroupOfPlatforms3 != null)
                {
                    GroupOfPlatforms3.transform.position = transform.position;
                    GroupOfPlatforms3.SetActive(true);

                }
                break;

            default:
                break;
        }

        Move();

    }
    private void Move()
    {
        if(startPosition.z >= movementStep*7)
        {
            transform.position = startPosition;
        }

        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movementStep);
        }

    }
}
