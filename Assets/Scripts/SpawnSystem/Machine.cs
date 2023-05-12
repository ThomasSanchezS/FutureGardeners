using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Machine : MonoBehaviour
{
    public UnityEvent TakingBluePlant;
    public UnityEvent TakingWhitePlant;
    public UnityEvent TakingRedPlant;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collectibles"))
        {
            //string typeOfPlant= collision.gameObject.GetComponent<TypeOfPlant>().type;

            TypeOfPlant.PlantType typeOfPlant = collision.gameObject.GetComponent<TypeOfPlant>().type;

            switch (typeOfPlant)
            {
                case TypeOfPlant.PlantType.Blue:
                    TakingBluePlant?.Invoke();
                    break;
                case TypeOfPlant.PlantType.White:
                    break;
                case TypeOfPlant.PlantType.Red:
                    break;
                default:
                    break;
            }

            gameObject.SetActive(false);
        }
    }
}
