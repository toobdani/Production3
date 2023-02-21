using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_CameraRotate : MonoBehaviour
{
    public float mousesense = 100f;

    float xrotation = 0f;

    [SerializeField]
    public Transform Playerbody;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesense;
        float mouseY = Input.GetAxis("Mouse Y") * mousesense;

        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        Playerbody.Rotate(Vector3.up * mouseX);
    }
}
