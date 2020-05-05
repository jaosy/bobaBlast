using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Keeps track of whether the boba has been launched and if it hit something 
 * Required for scoring and collision detection 
 */
public class bobaBall : MonoBehaviour
{
    public bool launched;
    public GameObject hitObj;

    public void Start()
    {
        launched = false;
        hitObj = null;
    }

    public void Update()
    {
        //Debug.Log("y" + transform.position.y);
        if (transform.position.y < 1.7) {
            transform.position = new Vector3(0f,-200f,0f);
        }
        if (launched)
        {
            if(hitObj != null)
            {
                Debug.Log("Oh! I Just hit something!: " + hitObj.tag);
            }

            
            
        }
    }

    public void beenLaunched(GameObject obj)
    {
        launched = true;
        hitObj = obj;

    }

}
