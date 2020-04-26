using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Boba")) {
            Debug.Log("oops"); // change this to subtract points, obv
            Destroy(collision.gameObject);
        }
    }
}
