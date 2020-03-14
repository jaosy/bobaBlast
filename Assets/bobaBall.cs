using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobaBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("Star"))
        {
            other.gameObject.SetActive(false);
        }

    }
}
