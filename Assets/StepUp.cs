using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepUp : MonoBehaviour
{
    [SerializeField] movementTest MT;
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
        if(other.gameObject.tag == "Stair")
        {
            MT.Triggered = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Stair")
        {
            MT.Triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        MT.Triggered = false;
    }
}
