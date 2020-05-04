using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strawMovement : MonoBehaviour
{
    public Vector3 from;
    public Vector3 to;
    public float speed = 1.0f;

    /* Called once per frame, moves the straw starting from x axis 
     * SOURCE: https://answers.unity.com/questions/822484/rotate-object-over-time-and-oscillate.html
     */
    void Update()
    {
        float t = Mathf.PingPong(Time.time * 0.8f, 0.9f);
        transform.eulerAngles = Vector3.Lerp(from, to, t);
       
    }

}
