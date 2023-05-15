using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cubes = new GameObject[9];

    private int activeCubes, cubeActiveOne, cubeActiveTwo,cubeActiveThree;

    private void Start()
    {
        ActivateCubes();
    }
    public void ActivateCubes()
    {
   
            cubeActiveOne = (int)Random.Range(0, 9);

            cubeActiveTwo = cubeActiveOne;

            while (cubeActiveOne == cubeActiveTwo)
            {
                cubeActiveTwo = (int)Random.Range(0, 9);
            }
            cubeActiveThree = cubeActiveOne;

            while (cubeActiveThree == cubeActiveTwo || cubeActiveOne == cubeActiveThree)
            {
            cubeActiveThree = (int)Random.Range(0, 9); ;
            }

        cubes[cubeActiveOne].GetComponent<Cubes>().SetCubeOnBlue();

        cubes[cubeActiveTwo].GetComponent<Cubes>().SetCubeOnWhite();

        cubes[cubeActiveThree].GetComponent<Cubes>().SetCubeOnRed();

        activeCubes = 3;

    }

    public void ReduceActiveCubes()
    {
        activeCubes--;

        if(activeCubes<=0) 
        {
        ActivateCubes();
        }
    }

}
