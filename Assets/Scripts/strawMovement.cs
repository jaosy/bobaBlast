using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Animates the straw so it appears to move side-to-side
 * with linear interpolation applied to tranform's rotation 
 * component (represented by Euler angles)
 */
public class strawMovement : MonoBehaviour
{
    public Vector3 from; // set in Inspector
    public Vector3 to;

    /* Called once per frame, moves the straw starting from x axis 
     * SOURCE: https://answers.unity.com/questions/822484/rotate-object-over-time-and-oscillate.html
     */
    void Update()
    {
        float t = Mathf.PingPong(Time.time, 1.0f); 
        transform.eulerAngles = Vector3.Lerp(from, to, t);
    }
}
