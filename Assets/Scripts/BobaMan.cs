using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Responsible for instantiating the Boba prefab,
 * tracking all current boba instances in a list and operations to 
 * remove them. Linked to score check/update function of gameManger.cs 
 */
public class BobaMan : MonoBehaviour
{
    public GameObject bobaFab;
    private List<GameObject> currBoba = new List<GameObject>(); // all bobas currently in the air
    private gameManger gameControl;

    public void Start()
    {
        gameControl = GameObject.Find("Game Manager").GetComponent<gameManger>(); // associate to gameManger.cs
    }

    /* Creates instance of Boba prefab, add to list of all bobas*/
    public GameObject newBall()
    {
        GameObject newBall = Instantiate(bobaFab);
        currBoba.Add(newBall);
        return newBall;
    }

    public void Update()
    {
        Track();
    }

    /* Removes and destroys boba once landed */
    public void removeBall(GameObject landedBall)
    {
        currBoba.Remove(landedBall);
        Destroy(landedBall);
    }

    /* Clears list of all bobas*/
    public void removeAll()
    {
        foreach(GameObject curr in currBoba)
        {
            currBoba.Remove(curr);
            Destroy(curr);
        }
    }

    /* Checks if each boba in list of all bobas has landed,
     * grabbing its list of GameObjects collided with if so and calls 
     * checkHits() in gameManger.cs to check tag of collider and update
     * score accordingly, removes boba from list and game
     */
    private void Track()
    {
        foreach(GameObject curr in currBoba)
        {
            // Check landed boolean of each instance of boba
            if (curr.GetComponent<bobaBall>().landed){
                List<GameObject> allHits = curr.GetComponent<bobaBall>().hitObj; // all GameObjects collided with
                gameControl.checkHits(allHits); 
                removeBall(curr);
            }
        }
    }
}
