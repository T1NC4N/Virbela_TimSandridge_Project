using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    string[] tags;
    List<GameObject> gameObjects = new List<GameObject>();

    GameObject closestGO, prevGo;


    // Start is called before the first frame update
    void Start()
    {
        tags = new string[] { "Item", "Bot" };
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (tags.Contains(go.tag))
                gameObjects.Add(go);
        }

        prevGo = closestGO = GetClosestObject().gameObject;
        SetClosestColor(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetClosestColor();
    }

    Transform GetClosestObject()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
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
    
    void SetClosestColor(bool force)
    {
        if (force)
        {
            closestGO = GetClosestObject().gameObject;
            closestGO.GetComponent<Object>().highLight = true;
        }
    }
}
