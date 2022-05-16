using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    //list of objects containing specific tag
    private string[] tags;
    private List<GameObject> gameObjects = new List<GameObject>();

    //tracking variables for gameObject currently and previously interacted with
    private GameObject closestGO, prevGo;

    // math variables for finding closed GO
    private Transform tMin = null;
    private float minDist = Mathf.Infinity;
    private Vector3 currentPos;


    // Start is called before the first frame update
    void Start()
    {
        //populate array with relevant tags, and list with relevant GOs
        tags = new string[] { "Item", "Bot" };
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (tags.Contains(go.tag))
                gameObjects.Add(go);
        }

        //initialize GO tracking variables, and set it's color
        prevGo = closestGO = GetClosestObject().gameObject;
        SetClosestColor(true);
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        //Consistently check and trigger closest GO
        SetClosestColor();
    }

    //Returns transform of closest GO in list
    Transform GetClosestObject()
    {
        //re-init math variables
        tMin = null;
        minDist = Mathf.Infinity;
        currentPos = transform.position;

        foreach(GameObject t in gameObjects)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }

    //changes color of closest GO and resets color of previous closest GO
    void SetClosestColor()
    {
        closestGO = GetClosestObject().gameObject;

        if (prevGo != closestGO)
        {
            closestGO.GetComponent<Object>().highLight = true;
            prevGo.GetComponent<Object>().highLight = false;
            prevGo = closestGO;
        }

    }
    
    //overloaded function to force change color of currently closest GO
    void SetClosestColor(bool force)
    {
        if (force)
        {
            closestGO = GetClosestObject().gameObject;
            closestGO.GetComponent<Object>().highLight = true;
        }
    }
}
