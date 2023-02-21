using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changegravity : MonoBehaviour
{
    Rigidbody R;
    public Transform T;

    float x;
    float y;
    float z;

    [SerializeField] CameraSwap CS;

    [SerializeField] GameObject[] Temp;

    [SerializeField] Material[] WallTemp;
    
    [SerializeField] movementTest MT;

    [SerializeField] int loopcount;

    [SerializeField] Color Material3;
    [SerializeField] Color Material2;
    [SerializeField] Color Material1;
    [SerializeField] Color Material0;    

    [SerializeField] float alphacount;

    [SerializeField] Transform Cameratransform;


    // Start is called before the first frame update
    void Start()
    {
        R = gameObject.GetComponent<Rigidbody>();
        x = T.transform.rotation.x;

        if (CS.gameObject.activeSelf == true)
        {
            Material0 = CS.WallMaterials[0].color;
            Material1 = CS.WallMaterials[1].color;
            Material2 = CS.WallMaterials[2].color;
            Material3 = CS.WallMaterials[3].color;

            Material0.a = 1;
            Material1.a = 1;
            Material2.a = 0;
            Material3.a = 0;

            CS.WallMaterials[0].color = Material0;
            CS.WallMaterials[1].color = Material1;
            CS.WallMaterials[2].color = Material2;
            CS.WallMaterials[3].color = Material3;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (CS.gameObject.activeSelf == true)
        {
            CS.WallMaterials[0].color = Material0;
            CS.WallMaterials[1].color = Material1;
            CS.WallMaterials[2].color = Material2;
            CS.WallMaterials[3].color = Material3;
        }

        if (MT.Groundbool == true && MT.MoveAllow == 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

                //Physics.gravity = new Vector3(0, 5f, 0);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {

                //Physics.gravity = new Vector3(0, -5f, 0);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                MT.MoveAllow = 1;
                MT.MyRigidbody.velocity = new Vector3(0, 0, 0);
                MT.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                MT.gameObject.layer = 7;
                loopcount = 0;
                StartCoroutine(LeftRotate());
                if (CS.gameObject.activeSelf == true)
                {
                    MoveArrayup();
                }
                //Physics.gravity = new Vector3(0, 0, -5f);
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                MT.MoveAllow = 1;
                MT.MyRigidbody.velocity = new Vector3(0, 0, 0);
                MT.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                MT.gameObject.layer = 7;
                loopcount = 0;
                StartCoroutine(RightRotate());
                if (CS.gameObject.activeSelf == true)
                {
                    MoveArrayDown();
                }
                //Physics.gravity = new Vector3(0, 0, 5f);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            CS.change();
        }
    }

    IEnumerator LeftRotate()
    {
        if (CS.gameObject.activeSelf == true)
        {
            Material2.a -= 0.0011111111111111f;
            Material0.a += 0.0011111111111111f;
        }

        T.transform.Rotate((x - 0.1f), y, z, Space.World);
        
        if(Cameratransform != null)
        {
            Cameratransform.transform.Rotate((x + 0.1f), y, z, Space.World);
        }

        loopcount++;
        yield return new WaitForSeconds(0.001f);
        if(loopcount != 900)
        {
            StartCoroutine(LeftRotate());
        }
        else
        {
            MT.MyRigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
            MT.MoveAllow = 2;

            if (CS.gameObject.activeSelf == true)
            {
                Material0.a = 1;
                Material2.a = 0;
            }
            MT.gameObject.layer = 0;
        }
    }

    IEnumerator RightRotate()
    {
        T.transform.Rotate((x + 0.1f), y, z, Space.World);

        if (CS.gameObject.activeSelf == true)
        {
            Material3.a -= 0.0011111111111111f;
            Material1.a += 0.0011111111111111f;
        }

        if (Cameratransform != null)
        {
            Cameratransform.transform.Rotate((x - 0.1f), y, z, Space.World);
        }

        loopcount++;
        yield return new WaitForSeconds(0.001f);
        if (loopcount != 900)
        {
            StartCoroutine(RightRotate());
        }
        else
        {
            MT.MyRigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
            MT.MoveAllow = 2;

            if (CS.gameObject.activeSelf == true)
            {
                Material1.a = 1;
                Material3.a = 0;
            }
            MT.gameObject.layer = 0;
        }
    }

    public void MoveArrayup()
    {
        for (int ArrayNumber = 0; ArrayNumber < 4; ArrayNumber++)
        {
            Temp[ArrayNumber] = CS.Walls[ArrayNumber];
            WallTemp[ArrayNumber] = CS.WallMaterials[ArrayNumber];
        }

        for (int ArrayNumber = 0; ArrayNumber < 4; ArrayNumber++)
        {
            CS.Walls[ArrayNumber + 1] = Temp[ArrayNumber];
            CS.WallMaterials[ArrayNumber + 1] = WallTemp[ArrayNumber];
            if(ArrayNumber == 3)
            {
                CS.Walls[0] = Temp[3];
                CS.Walls[4] = null;
                CS.WallMaterials[0] = WallTemp[3];
                CS.WallMaterials[4] = null;
            }
        }
        Material0 = CS.WallMaterials[0].color;
        Material1 = CS.WallMaterials[1].color;
        Material2 = CS.WallMaterials[2].color;
        Material3 = CS.WallMaterials[3].color;

    }


    public void MoveArrayDown()
    {
        for (int ArrayNumber = 3; ArrayNumber >= 0; ArrayNumber--)
        {
            Temp[ArrayNumber] = CS.Walls[ArrayNumber];
            WallTemp[ArrayNumber] = CS.WallMaterials[ArrayNumber];
        }

        for (int ArrayNumber = 3; ArrayNumber >= 0; ArrayNumber--)
        {
            switch(ArrayNumber)
            {
                case 0:
                    {
                        CS.Walls[3] = Temp[0];
                        CS.Walls[4] = null;
                        CS.WallMaterials[3] = WallTemp[0];
                        CS.WallMaterials[4] = null;
                    }
                    break;
                default:
                    {
                        CS.WallMaterials[ArrayNumber - 1] = WallTemp[ArrayNumber];
                        CS.Walls[ArrayNumber - 1] = Temp[ArrayNumber];
                    }
                    break;
            }
            Debug.Log(ArrayNumber);
        }
        Material0 = CS.WallMaterials[0].color;
        Material1 = CS.WallMaterials[1].color;
        Material2 = CS.WallMaterials[2].color;
        Material3 = CS.WallMaterials[3].color;        
        
    }
}
