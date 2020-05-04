using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    public GameObject pickUpEffect; // SOURCE: https://assetstore.unity.com/packages/vfx/particles/cartoon-fx-free-109565
    public GameObject star; // SOURCE: https://assetstore.unity.com/packages/3d/environments/glowy-space-2d-toon-parallax-116509
    private GameObject instStar;
    public bool popped = false; 
    public bool containsStar;
    private AudioSource poppingSound;

    /* Initializes the AudioSource for the pop sound effect */
    void Start() {
        poppingSound = GetComponent<AudioSource>();
    }
    
    /* Handles what to do after boba collides with it */
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Oh no! I was just hit! " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Boba"))
        {
            other.GetComponent<bobaBall>().beenLaunched(gameObject);
        }
  
        // Play pickup effect and destroy the star
        if (containsStar)
        {
            GameObject instPickUp = Instantiate(pickUpEffect, GetComponent<Transform>().position, Quaternion.identity);
            instPickUp.GetComponent<ParticleSystem> ().Play();
            Destroy(instStar);
        }
        
        // "Pop" the bubble (illusion), play pop sound effect and begin reforming
        if (popped == false)
        {
            GetComponent<Transform>().position += Vector3.forward;
            popped = true;
            playPop();
            StartCoroutine("reform");
        }
    }

    /* Method that randomly determines if a star should be added. If so, includes star */ 
    public void addStar()
    {
        Vector3 pos = GetComponent<Transform>().position;
        if (Random.Range(0, 100) % 3 == 0)
        {
            instStar = Instantiate(star, pos, Quaternion.identity);
            containsStar = true;
            instStar.GetComponent<starBehav>().setConstraint(gameObject); // Makes the bubble its parent constraint
        }
        else
        {
            containsStar = false;
        }
       
    }
    
    /* Plays the Popping noise when the bubble is hit */
    private void playPop()
    {
        poppingSound.Play();
    }

    /* Once the bubble pops, reforms after 3 seconds and calls method to randomly add a star */
     IEnumerator reform() {
        yield return new WaitForSeconds(10f);
        GetComponent<Transform>().position -= Vector3.forward;
        popped = false;
        addStar();
    }

}
