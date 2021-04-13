using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Keeps track of whether the boba has been launched and if it hit something; 
 * is attached to Boba prefab, required for scoring and collision detection 
 */
public class bobaBall : MonoBehaviour
{
    public bool landed;
    public List<GameObject> hitObj = new List<GameObject>(); 

    public void Start()
    {
        landed = false;
    }

    /* Takes in a GameObject and adds to list of all GameObjects that
     * instance of boba has collided with. Called from bubble.cs script
     * when entering trigger collision with instance of Bubble GameObject
     */
    public void hasLanded(GameObject obj)
    {
        if (obj != null)
        {
            GameObject newHit = obj;
            // Debug.Log (newHit.tag); 
            hitObj.Add(newHit);
            landed = true;
        }
    }
}
