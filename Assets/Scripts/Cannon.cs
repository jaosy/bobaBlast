using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField]
    public Rigidbody cannonBallInstance;

    [SerializeField]
    [Range(10f, 80f)]
    private float angle = 45f;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches) {
        if (touch.phase == TouchPhase.Began) {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            RaycastHit hitInfo; 
            if (Physics.Raycast(ray, out hitInfo)) {
                FireCannonAtPoint(hitInfo.point);
            }
        }    
        }
    }

    private void FireCannonAtPoint(Vector3 point) {
        var velocity = BallisticVelocity(point, angle);
        cannonBallInstance.transform.position = transform.position; // reset cannonBall to cannon center
        cannonBallInstance.velocity = velocity; // set cannonBall velocity to calculated velocity
    }

    private Vector3 BallisticVelocity(Vector3 destination, float angle) {
        Vector3 dir = destination - transform.position; // get Target direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return a normalized vector.
    }

}
