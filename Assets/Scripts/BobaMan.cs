using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaMan : MonoBehaviour
{
    public GameObject bobaFab;
    private List<GameObject> currBoba = new List<GameObject>(); //all bobas currently in the air
    private gameManger gameControl;

    public void Start()
    {
        gameControl = GameObject.Find("Game Manager").GetComponent<gameManger>();
    }

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

    //Removes and destroies the ball once its been landed
    public void removeBall(GameObject landedBall)
    {
        currBoba.Remove(landedBall);
        Destroy(landedBall);
    }

    //Keeps track of the bobas in the air and reports back to game manager when one has landed
    private void Track()
    {
        foreach(GameObject curr in currBoba)
        {
            if (curr.GetComponent<bobaBall>().landed){
                List<GameObject> allHits = curr.GetComponent<bobaBall>().hitObj;
                gameControl.checkHits(allHits);
                removeBall(curr);
            }
        }
    }
}
