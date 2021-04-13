using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobafaceanimation : MonoBehaviour
{
    public Sprite[] BobaFaceSprites;
    
    // dizzybobaface
    public void dizzyFace()
    {
     GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[0];
    }

    // happybobaface
    public void happyFace()
    {
        GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[1];
    }

    // missedbobaface
    public void missedFace()
    {
        GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[2];
    }

    // sadbobaface
    public void sadFace()
    {
        GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[3];
    }

    // smilebobaface
    public void smileFace()
    {
        GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[4];
    }

    public void winkFace()
    {
        GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[5];
    }
}

