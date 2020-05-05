using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boba"))
        {
            other.GetComponent<bobaBall>().hasLanded(gameObject);
        }
    }
}
