using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobaBall : MonoBehaviour
{
    /* Destroys Bubble, Star and Boba upon collision */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Star"))
        {
            other.gameObject.SetActive(false);
        }

    }

}
