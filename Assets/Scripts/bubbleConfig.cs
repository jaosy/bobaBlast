using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

/* Sets up the bubble wrap sheet */
public class bubbleConfig : MonoBehaviour
{
    public float bubbleSpacing = 1.1f;
    public GameObject star;
    public GameObject bubble;

    /* Set up the bubble sheet with bubbles and stars in random places */
    void Start()
    {
        // Starting Values 
        Transform sheetTransform = GetComponent<Transform>(); // transform of Bubble Sheet GameObject
        Vector3 rowStart = new Vector3(-3.83f, 7.28f, 6.33f);

        // Moving Vectors
        Vector3 stepAcross = sheetTransform.right * bubbleSpacing; // horizontal 
        Vector3 stepDown = sheetTransform.forward * -bubbleSpacing * Mathf.Sqrt(0.75f); // move closer to camera and down in 3D space

        // Steps 
        Vector3 currPos; // where to place the next bubble

        // Positions the bubles in a hexagonal pattern and calls method for randomly adding star
        for (int row = 0; row <= 5; ++row)
        {
            currPos = rowStart + stepAcross * 0.5f * (row % 2);
            for (int col = row % 2; col <= 7; ++col)
            {
                GameObject instBubble = Instantiate(bubble, currPos, Quaternion.identity); 
                instBubble.GetComponent<bubble>().addStar();

                currPos += stepAcross; // increment horizontal position
            }

            rowStart += stepDown; // increment vertical position
        }
    }
}

