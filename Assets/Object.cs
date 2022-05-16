using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //serialized fields to allow setting of colors within Inspector
    [SerializeField]
    private Color startColor;

    [SerializeField]
    private Color highColor;

    //abstracted bool to be used by other scripts
    private bool highlight;
    public bool highLight
    {
        get { return highlight; }
        set {
            highlight = value;
            if(value)
            {
                SetHighColor();
            }
            else
            {
                UnHighLight();
            }
        }
    }

    // Start is called before the first frame update
    virtual protected void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // sets color of children classes
    virtual protected void SetHighColor()
    {
        GetComponent<Renderer>().material.SetColor("_Color", highColor);
    }

    //resets color of children classes
    virtual protected void UnHighLight()
    {
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }

}
