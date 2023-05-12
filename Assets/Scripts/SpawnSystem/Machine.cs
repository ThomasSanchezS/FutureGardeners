using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
 private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Group"))
        {
            gameObject.SetActive(false);
        }
    }
}
