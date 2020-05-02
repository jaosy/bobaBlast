using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobaBall : MonoBehaviour
{
    
    private AudioSource source;
    private bool launched;
    private GameObject hitObj;

    /* Destroys Bubble, Star and Boba upon collision.
     * plays sound effect */

    public void Start()
    {
        launched = false;
        hitObj = null;
    }

    public void Update()
    {
        if (launched)
        {
            if(hitObj != null)
            {
                Debug.Log("Oh! I Just hit something!: " + hitObj.tag);
               // PlaySound();
            }
            else
            {
                Debug.Log("lol this shit empty.");
            }
            
        }
    }

    public void beenLaunched(GameObject obj)
    {
        launched = true;
        hitObj = obj;

    }

    /* Sets up audio*/
    public void PlaySound() 
    {
        if (source == null) {
            source = GetComponent<AudioSource>();
        }
        source.Play();
    }

}
