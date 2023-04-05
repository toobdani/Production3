using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCameraTrigger : MonoBehaviour
{
    [SerializeField] LobbyCameraSwap LCS;

    [SerializeField] int swapnumber;
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
        LCS.SwapCamera = swapnumber;
    }
}
