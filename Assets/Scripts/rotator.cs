using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{

    float x;
    float y;
    float z;
    Vector3 pos;

    private void Start()
    {
        x = Random.Range(-3, 4);
        y = 5;
        z = Random.Range(6, 6);
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
