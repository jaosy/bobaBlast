using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) {

        if (collision.gameObject.CompareTag("Boba")) {
            Debug.Log("oops, looks like you hit a wall!"); // change this to subtract points, obv
            collision.gameObject.GetComponent<bobaBall>().beenLaunched(this.gameObject);
        }
    }
}
