using System.Collections;
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
        Vector3 startPos = new Vector3(-3.83f, 7.28f, 6.33f);

        //Moving Vectors
        Vector3 angle = Vector3.Cross(startPos, wrapPos).normalized; // Gives the right depth for the bubble on the sheet
        Vector3 across = new Vector3(1.5f, 0, 0);
        Vector3 zeroed = new Vector3(0, 0, 1);
        Vector3 down = new Vector3(0, -1.5f, 0);

        //Steps
        Vector3 oldPos; //Keep track of last places bubble
        Vector3 newPos; //Where to place the next bubble

        Debug.Log("Wrap Position: " + wrapPos + "\tStart Position: " + startPos);

        for (int r = 0; r <= 3; ++r)
        {
            oldPos = startPos;  //Resets 
            newPos = oldPos;
            for (int i = 1; i <= 6; ++i)
            {

                GameObject instBubble = Instantiate(bubble, newPos, Quaternion.identity);
                instBubble.GetComponent<bubble>().addStar();

                newPos = oldPos + across;

                Debug.Log("Moved from: " + oldPos + "to \tNew Position " + newPos
                          + "\nBy" + across + "Across and: " + down + "Down");

                oldPos = newPos;
            }

            startPos = startPos + (Vector3.Scale(zeroed, angle)) + down;
        }

    }
}

