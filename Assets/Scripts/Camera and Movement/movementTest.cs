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

        StepUp();
    }

    void move()
    {
        MoveValues = new Vector3();

        MoveValues.x = -MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        MoveValues.z = MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        MoveValues.y = MyRigidbody.velocity.y;
        MyRigidbody.velocity = MoveValues;
    }

    void rotate()
    {
    }

    void StepUp()
    {

        RaycastHit LowerHit;

        Debug.DrawRay(LowerStep.transform.localPosition, transform.TransformDirection(Vector3.forward) * 10f, Color.white);

        if (Physics.Raycast(LowerStep.transform.position, transform.TransformDirection(Vector3.forward), out LowerHit, 0.1f))
        {

        }
    }
}
