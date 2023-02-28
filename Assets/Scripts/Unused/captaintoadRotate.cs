using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class captaintoadRotate : MonoBehaviour
{
    public float mousesense = 100f;

    float xrotation = 0f;

    [SerializeField]
    public Transform Playerbody;

    [SerializeField] float RayCastDistance;

    [SerializeField] LayerMask LM;

    [SerializeField] GameObject TemporaryStorage;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesense;

        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        Playerbody.Rotate(Vector3.up * mouseX);

        RaycastHit WHit;


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out WHit, RayCastDistance, LM))
        {
            if(WHit.collider.gameObject.tag == "Wall")
            {
                foreach (Transform T in WHit.collider.gameObject.GetComponentsInChildren<Transform>())
                {
                    T.gameObject.layer = 3;
                }
                WHit.collider.gameObject.layer = 3;
                TemporaryStorage = WHit.collider.gameObject;
            }

        }
        else if(TemporaryStorage != null)
        {
            TemporaryStorage.layer = 0;
            foreach (Transform T in TemporaryStorage.GetComponentsInChildren<Transform>())
            {
                T.gameObject.layer = 0;
            }
            TemporaryStorage = null;
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RayCastDistance, Color.white);

    }
}
