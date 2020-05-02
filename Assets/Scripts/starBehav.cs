using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class starBehav : MonoBehaviour
{

    private ParentConstraint parentsCons;
    private ConstraintSource bubbSource = new ConstraintSource();

    public void setConstraint(GameObject bubble)
    {
       parentsCons = GetComponent<ParentConstraint>();
       bubbSource.sourceTransform = bubble.transform;

        parentsCons.AddSource(bubbSource);
        parentsCons.SetTranslationOffset(0, new Vector3(0, 0, 0));
        parentsCons.weight = 1;
        parentsCons.locked = true;
        parentsCons.constraintActive = true;
    }

    //To do: Figure out why it doesnt move with the bubble. Try and fix that. 
}
