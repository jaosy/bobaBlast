using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strawMovement : MonoBehaviour
{
    public Vector3 from = new Vector3(0f, 0f, 100f);
    public Vector3 to = new Vector3(0f, 0f, 255f);
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed * 1.0f, 1.0f);
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
