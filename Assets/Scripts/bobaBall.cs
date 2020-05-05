using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Keeps track of whether the boba has been launched and if it hit something 
 * Required for scoring and collision detection 
 */
public class bobaBall : MonoBehaviour
{
    public bool landed;
    public List<GameObject> hitObj = new List<GameObject>();

    public void Start()
    {
        landed = false;
    }

    public void Update()
    {
        if (landed)
        //Debug.Log("y" + transform.position.y);
        if (transform.position.y < 1.7) {
            transform.position = new Vector3(0f,-200f,0f);
        }
        {
            foreach(GameObject hit in hitObj)
            {
                Debug.Log("Looks like I hit A: " + hit.tag);
            }

            
            
        }
    }

    public void hasLanded(GameObject obj)
    {
        if(obj != null)
        {
            GameObject newHit = obj;
            hitObj.Add(newHit);
            landed = true;
        }
       
    }

}
