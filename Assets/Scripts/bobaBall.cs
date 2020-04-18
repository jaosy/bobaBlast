using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobaBall : MonoBehaviour
{
    //private AudioSource source; 

    /* Destroys Bubble, Star and Boba upon collision.
     * plays sound effect */
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("I hit a bubble");

        if (other.gameObject.CompareTag("Bubble"))
        {
           // PlaySound();
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Star"))
        {
           // PlaySound();
            other.gameObject.SetActive(false);
        }
    }

    /* Sets up audio*/
    // public void PlaySound() 
    // {
    //     if (source == null) {
    //         source = GetComponent<AudioSource>();
    //     }
    //     source.Play();
    // }

}
