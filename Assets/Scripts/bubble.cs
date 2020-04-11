using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    public GameObject star;
    public bool popped = false; 
    public bool containsStar;
    private AudioSource poppingSound;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit!");
        Destroy(collision.gameObject);
        if (containsStar)
        {
            Destroy(star);
        }
        //To Do: Play Popping Noise
        if (!popped) //To Do: Make it Look Like its been popped 
        {
            GetComponent<Transform>().position = GetComponent<Transform>().position + Vector3.back;
        }
        popped = true;
        //To do: Work on reforming
    }

    //Method that randomly determines if a star should be added. If so, includes star 
    public void addStar()
    {
        Vector3 pos = GetComponent<Transform>().position;
        if (Random.Range(0, 100) % 3 == 0)
        {
            star = Instantiate(star, pos, Quaternion.identity);
            containsStar = true;
            star.GetComponent<starBehav>().setConstraint(gameObject); // Makes the bubble its parent constraint
        }
        else
        {
            containsStar = false;
        }
       
    }
    //Plays the Popping noise when the bubble is hit
    private void playPop()
    {

    }
    //Once the bubble pops, essentially starts a timer for it to be reformed again 
    private void beginReform()
    {

    }

}
