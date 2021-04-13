using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Simple rotation animation for star */
public class starRotation : MonoBehaviour
{
    // Update is called once per frame, rotates the star
    void Update()
    {
      transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
