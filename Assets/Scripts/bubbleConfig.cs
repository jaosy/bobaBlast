using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class bubbleConfig : MonoBehaviour
{
    public GameObject star;
    public GameObject bubble;
    public int totalBubbles = 28;

    // Start is called before the first frame update
    //Set up the bubble sheet w/ bubbles and stars in random places
    void Start()
    {
        float x = -3.8f;
        float y = 6.35f;
        //float[] zvals = {6.42f, 5.79f, 5.22f, 4.61f};
        //int z = 0;
        //float z = 6.64f;

        for (int i = 0; i < totalBubbles; ++i)
        {
            
            GameObject instBubble = Instantiate(bubble, new Vector3(x, y, 6), Quaternion.identity);
            
            if(Random.Range(0, 100) % 3 == 0)
            { 
                GameObject instStar = Instantiate(star, new Vector3(x, y, 6), Quaternion.identity);
                instBubble.GetComponent<bubble>().star = instStar;
                setConstraint(instStar, instBubble);
                instBubble.GetComponent<bubble>().containsStar = true;
            }
            //Updates Position
            x += 1.5f;
            if(x >= 6.7f)
            {
                x = -3.8f; 
                y -= 1.5f;
            }
        }
    }

    // Makes the bubble the parent constraint of the star so that it forms inside it.
    void setConstraint(GameObject star, GameObject bubble)
    {
        ParentConstraint parentsCons = star.GetComponent<ParentConstraint>();
        
        ConstraintSource bubbSource = new ConstraintSource();
        bubbSource.sourceTransform = bubble.transform;

        parentsCons.AddSource(bubbSource);
        parentsCons.SetTranslationOffset(0, new Vector3(0, 0, 0));
        parentsCons.weight = 1;
        parentsCons.locked = true;
        parentsCons.constraintActive = true;
    }

}
