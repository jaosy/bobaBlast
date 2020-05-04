using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starRotation : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector3 pos;

    // Update is called once per frame, rotates the star
    void Update()
    {
      transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
