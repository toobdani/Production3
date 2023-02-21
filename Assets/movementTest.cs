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

    public bool Groundbool;

    public int MoveAllow;

    public Test_Scriptable_Object TSO;
    // Start is called before the first frame update
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
        MyTransform = GetComponent<Transform>();
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
}
