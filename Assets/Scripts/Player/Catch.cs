using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{

    public GameObject handPoint;
    
    private GameObject pickedObject = null;

    public Animator animate;
    
    //Soltar

    void Update()
    {
        if(pickedObject != null){

            if(Input.GetKey("l")){
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
                animate.SetLayerWeight(1, 0f);
            }
        }
    }

    //Agarrar

    private void OnTriggerStay(Collider other) {

        if (other.gameObject.CompareTag("Collectibles")) {

            if(Input.GetKey("k") && pickedObject == null){
                TypeOfPlant plant = other.GetComponent<TypeOfPlant>();
                plant.hasIt = TypeOfPlant.WhoHasit.Player1;
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                pickedObject = other.gameObject;
                animate.SetLayerWeight(1, 1f);  
                Debug.Log(plant.hasIt);
            }
        }
    }
}
