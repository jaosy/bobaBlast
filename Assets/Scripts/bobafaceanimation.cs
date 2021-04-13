using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobafaceanimation : MonoBehaviour
{

    public Sprite[] BobaFaceSprites;
    
    public void chargingFace()
    {
     GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[0];
    }

    public void anxiousFace()
    {
        GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[2];
    }

    public void happyFace()
    {
        GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[3];
    }

    public void sadFace()
    {
        GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[1];
    }

    // Addition for interview
    public void smileFace()
    {
        GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[5];
    }
}

