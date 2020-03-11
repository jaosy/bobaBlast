using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoba : MonoBehaviour
{
    public GameObject bobaPrefab;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
          
            Fire();
        }
    }

    public void Fire() {
        var boba = (GameObject)Instantiate(bobaPrefab, transform.position, transform.rotation);
        
        // Debug.Log("Firing!");
        // boba.transform.Translate(transform.forward * Time.deltaTime);
        // Debug.Log(transform.forward);
    }

}
