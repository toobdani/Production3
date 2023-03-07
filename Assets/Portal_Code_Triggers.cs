using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Code_Triggers : MonoBehaviour
{
    public bool Triggered;

    public bool Swapped;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Triggered = true;
        if(Swapped == true)
        {
            Triggered = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Triggered = false;
        if(Swapped == true)
        {
            Triggered = false;
        }
    }
}
