using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTest : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    public Rigidbody MyRigidbody;

    [SerializeField] Vector3 MoveValues;

    [SerializeField] Transform MyTransform;

    [SerializeField] float RayCastDistance;
    [SerializeField] float RayCastRadius;

    //[SerializeField] GameObject UpperStep;

    //[SerializeField] GameObject LowerStep;

    [SerializeField] float StepHeight = 0.3f;
    [SerializeField] float StepSmooth = 0.1f;

    [SerializeField] float YRotation;

    public bool Groundbool;

    public int MoveAllow;

    public Test_Scriptable_Object TSO;

    public bool Triggered;

    [SerializeField] bool Step;

    [SerializeField] float RotateSpeed;

    [SerializeField] bool RegularMove;
    // Start is called before the first frame update
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
        MyTransform = GetComponent<Transform>();

        //UpperStep.transform.localPosition = new Vector3(UpperStep.transform.localPosition.x, StepHeight, UpperStep.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit GHit;

        //Debug.DrawRay(LowerStep.transform.position, transform.TransformDirection(Vector3.left) * 0.3f, Color.white);
        //Debug.DrawRay(UpperStep.transform.position, transform.TransformDirection(Vector3.left) * 0.4f, Color.white);



        Groundbool = Physics.SphereCast(transform.position, RayCastRadius ,Vector3.down, out GHit, RayCastDistance);

        if(MoveAllow == 2)
        {
            if(Groundbool)
            {
                MoveAllow = 0;
            }
        }

    }

    private void FixedUpdate()
    {
        if (MoveAllow == 0)
        {
            move();
            rotate();
        }

        if(Triggered == true)
        {
            StepUp();
        }
    }

    void move()
    {
        MoveValues = new Vector3();

        if(RegularMove == true)
        {
            MoveValues.x = -MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            MoveValues.z = MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            MoveValues.y = MyRigidbody.velocity.y;
        }
        else
        {
            MoveValues.x = MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            MoveValues.z = -MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            MoveValues.y = MyRigidbody.velocity.y;
        }
        MyRigidbody.velocity = MoveValues;

        if(MoveValues.x != 0 || MoveValues.z != 0)
        {
            Step = true;
        }
        else
        {
            Step = false;
        }
    }

    void rotate()
    {
        switch (RegularMove)
        {
            case true:
                {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                    {
                        if (YRotation > -90 && YRotation < 90)
                        {
                            YRotation += RotateSpeed * MoveValues.z * Time.deltaTime;

                        }
                        else if (YRotation > 90 && Input.GetKey(KeyCode.D))
                        {
                            YRotation += RotateSpeed * -MoveValues.z * Time.deltaTime;
                        }

                        if (YRotation >= 90 && MoveValues.z < 0)
                        {
                            YRotation += RotateSpeed * MoveValues.z * Time.deltaTime;
                        }
                        else if (YRotation <= 90 && MoveValues.z > 0)
                        {
                            YRotation += RotateSpeed * MoveValues.z * Time.deltaTime;
                        }
                    }


                    if (Input.GetKey(KeyCode.S))
                    {
                        if (YRotation > -180 && YRotation < 180)
                        {
                            if (YRotation < 0)
                            {
                                YRotation += RotateSpeed * -MoveValues.x * Time.deltaTime;
                            }
                            else if (YRotation > 0)
                            {
                                YRotation += RotateSpeed * MoveValues.x * Time.deltaTime;
                            }
                        }
                        else
                        {
                            YRotation = 180;
                        }
                    }

                    if (Input.GetKey(KeyCode.W))
                    {
                        if (YRotation != 0)
                        {
                            if (YRotation < 0)
                            {
                                YRotation += RotateSpeed * -MoveValues.x * Time.deltaTime;
                            }
                            else if (YRotation > 0)
                            {
                                YRotation += RotateSpeed * MoveValues.x * Time.deltaTime;
                            }
                        }
                        else
                        {
                            YRotation = 0;
                        }
                    }
                }
                break;
            case false:
                {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                    {
                        if (YRotation > -90 && YRotation < 90)
                        {
                            YRotation += RotateSpeed * -MoveValues.z * Time.deltaTime;

                        }
                        else if (YRotation > 90 && Input.GetKey(KeyCode.D))
                        {
                            YRotation += RotateSpeed * MoveValues.z * Time.deltaTime;
                        }

                        if (YRotation >= 90 && MoveValues.z < 0)
                        {
                            YRotation += RotateSpeed * -MoveValues.z * Time.deltaTime;
                        }
                        else if (YRotation <= 90 && MoveValues.z > 0)
                        {
                            YRotation += RotateSpeed * -MoveValues.z * Time.deltaTime;
                        }
                    }


                    if (Input.GetKey(KeyCode.S))
                    {
                        if (YRotation > -180 && YRotation < 180)
                        {
                            if (YRotation < 0)
                            {
                                YRotation += RotateSpeed * MoveValues.x * Time.deltaTime;
                            }
                            else if (YRotation > 0)
                            {
                                YRotation += RotateSpeed * -MoveValues.x * Time.deltaTime;
                            }
                        }
                        else
                        {
                            YRotation = 180;
                        }
                    }

                    if (Input.GetKey(KeyCode.W))
                    {
                        if (YRotation != 0)
                        {
                            if (YRotation < 0)
                            {
                                YRotation += RotateSpeed * MoveValues.x * Time.deltaTime;
                            }
                            else if (YRotation > 0)
                            {
                                YRotation += RotateSpeed * -MoveValues.x * Time.deltaTime;
                            }
                        }
                        else
                        {
                            YRotation = 0;
                        }
                    }
                }
                break;
        }
            
      

        transform.localRotation = Quaternion.Euler(0f, YRotation, 0f);
    }

    void StepUp()
    {

        //RaycastHit LowerHit;


        /*if (Physics.Raycast(LowerStep.transform.position, transform.TransformDirection(Vector3.left), out LowerHit, 0.3f))
        {
            RaycastHit UpperHit;
            if (!Physics.Raycast(UpperStep.transform.position, transform.TransformDirection(Vector3.left), out UpperHit, 0.4f))
            {
                MyRigidbody.position = new Vector3(MyRigidbody.position.x, (MyRigidbody.position.y + StepSmooth), MyRigidbody.position.z);
            }
        }*/

        if (Step == true)
        {
            MyRigidbody.position = new Vector3((MyRigidbody.position.x + StepSmooth), (MyRigidbody.position.y + StepSmooth), MyRigidbody.position.z);
        }
    }
}
