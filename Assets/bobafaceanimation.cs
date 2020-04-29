using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobafaceanimation : MonoBehaviour
{
    private int rand;
    public Sprite[] BobaFaceSprites;
    // Start is called before the first frame update
    void Start()
    {
        Change();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Change();
        }
    }

    void Change()
    {
        rand = Random.Range(0, BobaFaceSprites.Length);
        GetComponent<SpriteRenderer>().sprite = BobaFaceSprites[rand];
    }
}

