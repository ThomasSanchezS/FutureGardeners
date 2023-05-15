using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Cubes : MonoBehaviour
{
    public UnityEvent BluePP1, BluePP2, WhitePP1, WhitePP2, RedPP1, RedPP2, WrongBlue, WrongWhite, WrongRed;
    public enum CubeStatus { off, OnBlue, OnWhite, OnRed };
    public CubeStatus status;

    public Material offMaterial, blueMaterial, whiteMaterial, redMaterial;

    Renderer rend;

    void Awake()
    {
        StartCube();
    }

    private void StartCube()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial= offMaterial;
        status = CubeStatus.off;
    }

    public void SetCubeOff()
    {
        rend.sharedMaterial = offMaterial;
        status = CubeStatus.off;
    }

    public void SetCubeOnBlue()
    {
        rend.sharedMaterial = blueMaterial;
        status = CubeStatus.OnBlue;
    }

    public void SetCubeOnWhite()
    {
        rend.sharedMaterial = whiteMaterial;
        status = CubeStatus.OnWhite;
    }
     public void SetCubeOnRed() 
    {
        rend.sharedMaterial= redMaterial;
        status = CubeStatus.OnRed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (status != CubeStatus.off)
        {
            if (collision.gameObject.CompareTag("Collectibles"))
            {

                TypeOfPlant.WhoHasit whoHasit = collision.gameObject.GetComponent<TypeOfPlant>().hasIt;
                TypeOfPlant.PlantType typeOfPlant = collision.gameObject.GetComponent<TypeOfPlant>().type;

                if (whoHasit == TypeOfPlant.WhoHasit.Player1)
                {
                    if (typeOfPlant == TypeOfPlant.PlantType.Blue && status == CubeStatus.OnBlue)
                    {
                        SetCubeOff();
                        BluePP1?.Invoke();

                        //sonido planta correcta

                    }

                    else if (typeOfPlant == TypeOfPlant.PlantType.White && status == CubeStatus.OnWhite)
                    {
                        SetCubeOff();
                        WhitePP1?.Invoke();
                        //sonido planta correcta

                    }

                    else if (typeOfPlant == TypeOfPlant.PlantType.Red && status == CubeStatus.OnRed)
                    {                    
                        SetCubeOff();
                        RedPP1?.Invoke();
                        //sonido planta correcta

                    }

                    else
                    {
                        if (typeOfPlant == TypeOfPlant.PlantType.Blue)
                        {
                            WrongBlue?.Invoke();
                        }

                        if (typeOfPlant == TypeOfPlant.PlantType.White)
                        {
                            WrongWhite?.Invoke();

                        }

                        if (typeOfPlant == TypeOfPlant.PlantType.Red)
                        {
                            WrongRed?.Invoke();
                        }

                        //sonido planta incorrecta
                    }
                }

                else if  (whoHasit == TypeOfPlant.WhoHasit.Player2)
                {
                    if (typeOfPlant == TypeOfPlant.PlantType.Blue && status == CubeStatus.OnBlue)
                    {                    
                        SetCubeOff();
                        BluePP2?.Invoke();
                        //sonido planta correcta

                    }

                    else if (typeOfPlant == TypeOfPlant.PlantType.White && status == CubeStatus.OnWhite)
                    {
                        SetCubeOff();
                        WhitePP2?.Invoke();

                        //sonido planta correcta

                    }

                    else if (typeOfPlant == TypeOfPlant.PlantType.Red && status == CubeStatus.OnRed)
                    {
                        SetCubeOff();
                        RedPP2?.Invoke();

                        //sonido planta correcta

                    }

                    else
                    {
                        if (typeOfPlant == TypeOfPlant.PlantType.Blue)
                        {
                            WrongBlue?.Invoke();
                        }

                        if (typeOfPlant == TypeOfPlant.PlantType.White)
                        {
                            WrongWhite?.Invoke();

                        }

                        if (typeOfPlant == TypeOfPlant.PlantType.Red)
                        {
                            WrongRed?.Invoke();
                        }

                        //sonido planta incorrecta

                    }
                }

                collision.gameObject.SetActive(false);
            }
        }
    }
}
