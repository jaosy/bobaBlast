using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Adds Wall to Boba instance's list of the GameObjects collided with */
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
