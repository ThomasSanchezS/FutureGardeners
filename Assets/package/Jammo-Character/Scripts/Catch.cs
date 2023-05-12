using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{

    public GameObject handPoint;
    
    private GameObject pickedObject = null;

    public Animator animate;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(pickedObject != null){

            if(Input.GetKey("r")){

                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
                animate.SetLayerWeight(1, 0f);
            }
        }
    }

    private void OnTriggerStay(Collider other) {

        if (other.gameObject.CompareTag("Collectibles")) {

            if(Input.GetKey("e") && pickedObject == null){

                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                pickedObject = other.gameObject;
                animate.SetLayerWeight(1, 1f);
            }
        }
    }
}
