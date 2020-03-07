using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    Transform b;

    // Update is called once per frame
    void Update()
    {
        b.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
