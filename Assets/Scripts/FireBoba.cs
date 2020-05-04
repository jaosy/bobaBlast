using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Shooting mechanism for the boba - attached to Top of Straw */
public class FireBoba : MonoBehaviour
{
    [SerializeField]
    public GameObject bobaPrefab; // store the prefab
    public Rigidbody chargeMeter;
    
    //Charging Parameters
    // public float shootingForce = 275f; 
    private float maxCharge = 1.80f;
    private float minCharge = 1.06f;
    private float angle = 45f;
    private float charge;
    //Charging Visuals
    private float progress;
    private Vector3 initialScale;
    private Vector3 finalScale; 
    public Camera cam;
    //Current Game Variables
    private GameObject currBoba;
    public bool fired;

    /* Start is called before the first frame update */
    void Start()
    {
        currBoba = null;
        fired = false;
        initialScale = new Vector3(2f, 0.1f, 2f);
        finalScale = new Vector3(2f, 5f, 2f);
        chargeMeter.transform.localScale = initialScale;
    }

    /* Update is called once per frame */
    void Update()
    {
        if (fired)
        {
            fired = false;
        } 
    }
    public void Shoot(GameObject ball)
    {
        currBoba = ball;
        arcDirection();
        fired = true;
    }
    /* Sets boba velocity and moves the boba */
    private void ShootBoba(Vector3 point)
    {
        var velocity = BallisticVelocity(point, angle);
        //Debug.Log("Firing at " + point + " velocity " + velocity); // console debugging
        Rigidbody bobaRig = currBoba.GetComponent<Rigidbody>();
        bobaRig.transform.position = transform.position;
        bobaRig.velocity = velocity;

   }

    private void arcDirection()
    {
        // transform.eulerAngles gives the straw's angle of rotation
        Ray ray = new Ray(transform.position, transform.eulerAngles);

        RaycastHit hitInfo;
       if (Physics.Raycast(ray, out hitInfo))
        {
           ShootBoba(hitInfo.point);
        }
    }

    /* Calculates the velocity of the boba */
    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        Vector3 dir = destination + cam.transform.up + cam.transform.forward; // get target direction
        if (dir.z < 0) {
            dir.z = Mathf.Abs(dir.z);
        }
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences
       
        float velocity = Mathf.Sqrt(dist * charge * Physics.gravity.magnitude / Mathf.Sin(2 * a));  // Calculate the velocity magnitude
        return velocity * dir.normalized; // Return a normalized vector.
    }
    
    public void calculateCharge(float end, float start)
    {
        charge = end - start;

        if (charge < minCharge) {
            charge = minCharge;
        }
        if (charge > maxCharge) {
            charge = maxCharge;
        }
    }

    IEnumerator ChargeTeaUp() {
        progress = 0;
        while (progress <= 1) {
            chargeMeter.transform.localScale = Vector3.Lerp(initialScale, finalScale, progress);
            progress += Time.deltaTime * 0.4f;
            yield return null;
        }
    }
    public void startCharge()
    {
        StartCoroutine("ChargeTeaUp");
    }
    public void endCharge()
    {
        StopCoroutine("ChargeTeaUp");
    }
    public GameObject getCurrBall()
    {
        return currBoba;
    }
}
