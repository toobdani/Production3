using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalStageRotate : MonoBehaviour
{

    [SerializeField] movementTest MT;

    [SerializeField] int loopcount;

    [SerializeField] GameObject Player;

    public Transform T;
    float x;
    float y;
    float z;


    [SerializeField] string RDirection;

    /*
    RotateModifiers[0] = XLeft 
    RotateModifiers[1] = XRight 
    RotateModifiers[2] = YLeft 
    RotateModifiers[3] = YRight 
    RotateModifiers[4] = Forward 
    RotateModifiers[5] = Backward 
     */
    // Start is called before the first frame update
    void Start()
    {
        T = gameObject.GetComponent<Transform>();
        Player.transform.rotation = new Quaternion(0, 0, 0, 0);
        x = T.transform.rotation.x;
        y = T.transform.rotation.y;
        z = T.transform.rotation.z;

        RotationPlan("Left");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void RotationPlan(string Direction)
    {
        switch(Direction)
        {
            case "Left":
                {
                    MT.MyRigidbody.velocity = new Vector3(0, 0, 0);
                    MT.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    MT.gameObject.layer = 7;
                    x = T.transform.rotation.x;
                    y = T.transform.rotation.y;
                    z = T.transform.rotation.z;
                    RDirection = Direction;
                    StartCoroutine(Rotate());
                }
                break;
            case "Right":
                {

                }
                break;
        }
    }

    IEnumerator Rotate()
    {
        T.transform.Rotate(XRotate(x), y, ZRotate(z), Space.World);

        loopcount++;
        yield return new WaitForSeconds(0.001f);
        if (loopcount != 900)
        {
            StartCoroutine(Rotate());
        }
        else
        {
            MT.MyRigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
            MT.MoveAllow = 2;        
            MT.gameObject.layer = 0;
            //Direction = null;
            x = T.transform.rotation.x;
            y = T.transform.rotation.y;
            z = T.transform.rotation.z;

        }
    }

    float XRotate(float Modify)
    {
        switch (RDirection)
        {
            case "Left":
                {
                    Modify -= 0.1f;
                }
                break;
            case "Right":
                {
                    Modify += 0.1f;
                }
                break;
            default:
                {
                    x = T.transform.rotation.x;
                }
                break;
        }
        return (Modify);
    }

    float ZRotate(float Modify)
    {
        switch (RDirection)
        {
            case "Forward":
                {
                    Modify -= 0.1f;
                }
                break;
            case "Backward":
                {
                    Modify += 0.1f;
                }
                break;
            default:
                {
                    z = T.transform.rotation.z;
                }
                break;
        }
        return (Modify);
    }
}
