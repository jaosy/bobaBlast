using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strawMovement : MonoBehaviour
{
    public Vector3 from;
    public Vector3 to;
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time * 0.8f, 0.9f);
        transform.eulerAngles = Vector3.Lerp(from, to, t);
       
    }

    private void pause()
    {
        Time.timeScale = 0.0f;
    }

    private void cont()
    {
        Time.timeScale = 1.0f;
    }
}
