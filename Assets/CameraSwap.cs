using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject[] Cameras;

    public bool Cameratype;

    public GameObject[] Walls;

    public Material[] WallMaterials;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cameras[0].SetActive(Cameratype == true);
        Cameras[1].SetActive(Cameratype == false);
    }

    public void change()
    {
        Cameratype = !(Cameratype);
    }
}
