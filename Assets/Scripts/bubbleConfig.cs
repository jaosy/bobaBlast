using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class bubbleConfig : MonoBehaviour
{
    public float bubbleSpacing = 1.1f;
    public GameObject star;
    public GameObject bubble;

    // Start is called before the first frame update
    //Set up the bubble sheet w/ bubbles and stars in random places
    void Start()
    {
        //Starting Values: 
        Transform sheetTransform = GetComponent<Transform>();
        Vector3 rowStart = new Vector3(-3.83f, 7.28f, 6.33f);

        //Moving Vectors
        Vector3 stepAcross = sheetTransform.right * bubbleSpacing; 
        Vector3 stepDown = sheetTransform.forward * -bubbleSpacing * Mathf.Sqrt(0.75f);

        //Steps 
        Vector3 currPos; //Where to place the next bubble

        //Positions the bubles in a hexagonal pattern and calls method for randomly adding star
        for (int row = 0; row <= 5; ++row)
        {
            currPos = rowStart + stepAcross * 0.5f * (row % 2);
            for (int col = row % 2; col <= 7; ++col)
            {
               
                GameObject instBubble = Instantiate(bubble, currPos, Quaternion.identity);
                instBubble.GetComponent<bubble>().addStar();

                currPos += stepAcross;

            }

            rowStart += stepDown;
        }

    }
}

