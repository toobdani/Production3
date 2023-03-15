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

    [SerializeField] GameObject UpperStep;

    [SerializeField] GameObject LowerStep;

    [SerializeField] float StepHeight = 0.3f;
    [SerializeField] float StepSmooth = 0.1f;

    public bool Groundbool;

    public int MoveAllow;

    public Test_Scriptable_Object TSO;

    public bool Triggered;

    [SerializeField] bool Step;
    // Start is called before the first frame update
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
        MyTransform = GetComponent<Transform>();

        UpperStep.transform.localPosition = new Vector3(UpperStep.transform.localPosition.x, StepHeight, UpperStep.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit GHit;

        Debug.DrawRay(LowerStep.transform.position, transform.TransformDirection(Vector3.left) * 0.3f, Color.white);
        Debug.DrawRay(UpperStep.transform.position, transform.TransformDirection(Vector3.left) * 0.4f, Color.white);

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

        MoveValues.x = -MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        MoveValues.z = MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        MoveValues.y = MyRigidbody.velocity.y;
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
