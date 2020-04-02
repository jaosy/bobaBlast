using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Shooting mechanism for the boba - attached to Top of Straw */
public class FireBoba : MonoBehaviour
{
    [SerializeField]
    public Rigidbody bobaPrefab; // store the prefab
    private Rigidbody boba; // instance of boba
    private float angle = 45f;
    private float startTime; 
    private float charge = 0;

    /* Start is called before the first frame update */
    void Start() {}

    /* Update is called once per frame */
    void Update()
    {
        // foreach(Touch touch in Input.touches)
        // // {
        // if (touch.phase == TouchPhase.Began) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                
                startTime = Time.time;
            }

            if (Input.GetKeyUp(KeyCode.Space)) {

                charge = Time.time - startTime;

                boba = Instantiate(bobaPrefab);
                // transform.eulerAngles gives the straw's angle of rotation
                Ray ray = new Ray(transform.position, transform.eulerAngles);

                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    ShootBoba(hitInfo.point, charge);
                }

                charge = 0f;
            }

        // }
        // }
    }

    /* Sets boba velocity and moves the boba */
    private void ShootBoba(Vector3 point, float charge)
    {
        var velocity = BallisticVelocity(point, angle, charge);
        Debug.Log("Firing at " + point + " velocity " + velocity); // console debugging

        boba.transform.position = transform.position;
        boba.velocity = velocity;
    }

    /* Calculates the velocity of the boba */
    private Vector3 BallisticVelocity(Vector3 destination, float angle, float charge)
    {
        Debug.Log("charge: " + charge);
        Vector3 dir = destination - transform.position; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences
       
        float velocity = Mathf.Sqrt(dist * charge * Physics.gravity.magnitude / Mathf.Sin(2 * a));  // Calculate the velocity magnitude
        return velocity * dir.normalized; // Return a normalized vector.
    }

}
