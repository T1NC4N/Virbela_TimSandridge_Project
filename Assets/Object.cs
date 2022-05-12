using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    [SerializeField]
    private Color startColor;

    [SerializeField]
    private Color highColor;

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

    virtual protected void SetHighColor()
    {
        GetComponent<Renderer>().material.SetColor("_Color", highColor);
    }

    virtual protected void UnHighLight()
    {
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }

}
