using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Shooting mechanism for the boba - attached to Top of Straw */
public class FireBoba : MonoBehaviour
{
    [SerializeField]
    public GameObject bobaPrefab; 
    public Rigidbody chargeMeter;
    
    //Charging Parameters
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

    /* Start is called before the first frame update */
    void Start()
    {
        initialScale = new Vector3(2f, 0.1f, 2f);
        finalScale = new Vector3(2f, 5f, 2f);
        chargeMeter.transform.localScale = initialScale;
    }

    /* Update is called once per frame */
    void Update()
    {
    }

    /* Transfer control from GameManager.cs script to boba shooting */
    public void Shoot(GameObject ball, float end, float start)
    {
        currBoba = ball;
        calculateCharge(end, start);
        arcDirection();
    }

    /* Casts a ray that determines the boba's trajectory */
    private void arcDirection()
    {
        Ray ray = new Ray(transform.position, transform.eulerAngles);

        RaycastHit hitInfo;
       if (Physics.Raycast(ray, out hitInfo))
        {
           ShootBoba(hitInfo.point);
        }
    }

     /* Sets boba velocity and moves the boba */
    private void ShootBoba(Vector3 point)
    {
        var velocity = BallisticVelocity(point, angle);
        // Debug.Log("Firing at " + point + " velocity " + velocity); 
        Rigidbody bobaRig = currBoba.GetComponent<Rigidbody>();
        bobaRig.transform.position = transform.position;
        bobaRig.velocity = velocity;

   }

    /* Calculates the velocity of the boba - responsible for movement
     * SOURCE - https://unity3d.college/2017/06/30/unity3d-cannon-projectile-ballistics/
     */
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
    
    /* Calculates charge applied to boba and fixes charging limits */
    private void calculateCharge(float end, float start)
    {
        charge = end - start;

        if (charge < minCharge) {
            charge = minCharge;
        }
        if (charge > maxCharge) {
            charge = maxCharge;
        }
    }

    /* Grows the charge meter */
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
