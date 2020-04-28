using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Shooting mechanism for the boba - attached to Top of Straw */
public class FireBoba : MonoBehaviour
{
    [SerializeField]
    public GameObject bobaPrefab; // store the prefab
    public GameObject currBoba;
    public Rigidbody chargeMeter;
    
    public bool launched = false;
    
    // public float shootingForce = 275f; 
    private float maxCharge = 1.6f;
    private float minCharge = 0.79f;
    private float angle = 45f;
    private float startTime;
    private float charge;
    private float progress;
    private Vector3 initialScale;
    private Vector3 finalScale;
    // private Vector3 forwardHalved;
    // private Vector3 upHalved;
    // private Vector3 bobaDirection;
    // private Vector3 bobaYZDirection; 
    public Camera cam;
   

    /* Start is called before the first frame update */
    void Start()
    {
        initialScale = new Vector3(2f, 0.1f, 2f);
        finalScale = new Vector3(2f, 0.9f, 2f);
        chargeMeter.transform.localScale = initialScale;
    }

    /* Update is called once per frame */
    void Update()
    {
        // float startTime = 0;

        // foreach(Touch touch in Input.touches) {
        // if (touch.phase == TouchPhase.Began) {
        if (Input.GetKeyDown(KeyCode.Space)) {
            launched = false;
            startTime = Time.time;
            StartCoroutine("ChargeTeaUp");
        }

        // if (touch.phase == TouchPhase.Ended) {
        if (Input.GetKeyUp(KeyCode.Space)) { 
            StopCoroutine("ChargeTeaUp");
            charge = calculateCharge(Time.time, startTime);
            arcDirection(charge);
         }
        // }
    }

    /* Sets boba velocity and moves the boba */
    private void ShootBoba(Vector3 point, float charge, Collider hit)
    {
        currBoba = Instantiate(bobaPrefab);
        // currBoba.transform.position = transform.position;
        // currBoba.GetComponent<bobaBall>().setHit(hit);
        
        // Rigidbody bobaRig = currBoba.GetComponent<Rigidbody>();
        // bobaRig.transform.position = transform.position;
        // bobaRig.useGravity = true;
        // forwardHalved = Vector3.Scale(currBoba.transform.forward, new Vector3(0.1f, 0.1f, 0.1f));
        // upHalved = Vector3.Scale(currBoba.transform.up, new Vector3(0.8f, 0.8f, 0.8f));
        // bobaDirection = forwardHalved + upHalved;
        // bobaYZDirection = new Vector3(0f, -1*transform.position.y, -1*transform.position.z);
        // bobaRig.AddForce((cam.transform.up + cam.transform.forward) * shootingForce);

        var velocity = BallisticVelocity(point, angle, charge);
        Debug.Log("Firing at " + point + " velocity " + velocity); // console debugging
        Rigidbody bobaRig = currBoba.GetComponent<Rigidbody>();
        bobaRig.transform.position = transform.position;
        bobaRig.velocity = velocity;

        launched = true;
   }

    private void arcDirection(float charge)
    {
        // transform.eulerAngles gives the straw's angle of rotation
        Ray ray = new Ray(transform.position, transform.eulerAngles);

        RaycastHit hitInfo;
       if (Physics.Raycast(ray, out hitInfo))
        {
           ShootBoba(hitInfo.point, charge, hitInfo.collider);
        }
    }

    /* Calculates the velocity of the boba */
    private Vector3 BallisticVelocity(Vector3 destination, float angle, float charge)
    {
        Debug.Log("charge: " + charge);
        //Vector3 dir = destination - transform.position + transform.forward; // get Target Direction
        Vector3 dir = destination + cam.transform.up + cam.transform.forward;
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences
       
        float velocity = Mathf.Sqrt(dist * charge * Physics.gravity.magnitude / Mathf.Sin(2 * a));  // Calculate the velocity magnitude
        return velocity * dir.normalized; // Return a normalized vector.
    }
    private float calculateCharge(float end, float start)
    {
        float charge = end - start;
        if (charge < minCharge)
        {
            charge = 0.70f;
        }

        if (charge > maxCharge)
        {
            charge = 1.4f;
        }

        return charge*1.5f;
    }

    IEnumerator ChargeTeaUp() {
        progress = 0;
        while (progress <= 1) {
            chargeMeter.transform.localScale = Vector3.Lerp(initialScale, finalScale, progress);
            progress += Time.deltaTime * 0.5f;
            yield return null;
        }
    }
    
    public GameObject getCurrBall()
    {
        return currBoba;
    }
}
