﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class bubbleConfig : MonoBehaviour
{
    public GameObject star;
    public GameObject bubble;

    // Start is called before the first frame update
    //Set up the bubble sheet w/ bubbles and stars in random places
    void Start()
    {
        //Starting Values: 
        Vector3 wrapPos = GetComponent<Transform>().position;
        Vector3 rowStart = new Vector3(-3.83f, 7.28f, 6.33f);

        //Moving Vectors
        Vector3 angle = Vector3.Cross(rowStart, wrapPos).normalized; // Gives the right depth for the bubble on the sheet
        Vector3 stepAcross = new Vector3(1.5f, 0, 0);
        Vector3 zeroed = new Vector3(0, 0, 1); 
        Vector3 stepDown = Vector3.Scale(zeroed, angle) + new Vector3(0, -1.5f, 0);

        //Steps 
        Vector3 currPos; //Where to place the next bubble

        Debug.Log("Wrap Position: " + wrapPos + "\tStart Position: " + rowStart);

        for (int row = 0; row <= 3; ++row)
        {
            currPos = rowStart;
            for (int col = 1; col <= 6; ++col)
            {

                GameObject instBubble = Instantiate(bubble, currPos, Quaternion.identity);
                instBubble.GetComponent<bubble>().addStar();

                currPos += stepAcross;

            }

            rowStart += stepDown;
        }

    }
}

