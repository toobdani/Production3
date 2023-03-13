using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [SerializeField] bool portalRoom;

    [SerializeField] float Material3;
    [SerializeField] float Material2;
    [SerializeField] float Material1;
    [SerializeField] float Material0;    

    [SerializeField] float alphacount;

    [SerializeField] Transform Cameratransform;

    [SerializeField] float Down;

    [SerializeField] float Up;

    [SerializeField] GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        Player.transform.rotation = new Quaternion(0, 0, 0, 0);

        R = gameObject.GetComponent<Rigidbody>();
        x = T.transform.rotation.x;

        if (CS.gameObject.activeSelf == true)
        {
            if(portalRoom == false)
            {
                CS.WallMaterials[0].SetFloat("_Visbility", 15);
                CS.WallMaterials[1].SetFloat("_Visbility", 15);
                CS.WallMaterials[2].SetFloat("_Visbility", 0);
                CS.WallMaterials[3].SetFloat("_Visbility", 0);
            }
            else
            {
                CS.WallMaterials[0].SetFloat("_Visbility", 15);
                CS.WallMaterials[1].SetFloat("_Visbility", 15);
                CS.WallMaterials[2].SetFloat("_Visbility", 1f);
                CS.WallMaterials[3].SetFloat("_Visbility", 1f);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        /*if (CS.gameObject.activeSelf == true)
        {
            CS.WallMaterials[0].color = Material0;
            CS.WallMaterials[1].color = Material1;
            CS.WallMaterials[2].color = Material2;
            CS.WallMaterials[3].color = Material3;
        }*/

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
            if (Input.GetMouseButtonDown(0))
            {
                MT.MoveAllow = 1;
                MT.MyRigidbody.velocity = new Vector3(0, 0, 0);
                MT.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                MT.gameObject.layer = 7;
                loopcount = 0;

                if (portalRoom == false)
                {
                    Down = 15f;
                    Up = 0f;
                }
                else
                {
                    Down = 15f;
                    Up = 1f;
                }
                StartCoroutine(LeftRotate());
                if (CS.gameObject.activeSelf == true)
                {
                    MoveArrayup();
                }
                //Physics.gravity = new Vector3(0, 0, -5f);
            }
            if (Input.GetMouseButtonDown(1))
            {
                MT.MoveAllow = 1;
                MT.MyRigidbody.velocity = new Vector3(0, 0, 0);
                MT.MyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                MT.gameObject.layer = 7;
                loopcount = 0;

                if (portalRoom == false)
                {
                    Down = 15f;
                    Up = 0f;
                }
                else
                {
                    Down = 15f;
                    Up = 1f;
                }
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
            if(portalRoom == false)
            {
                Down -= 0.0166666666666667f;
                Up += 0.0166666666666667f;
            }
            else
            {
                Down -= 0.0155555555555556f;
                Up += 0.0155555555555556f;
            }
        }

        if(portalRoom == false)
        {
            CS.WallMaterials[0].SetFloat("_Visbility", Up);
            CS.WallMaterials[1].SetFloat("_Visbility", 15f);
            CS.WallMaterials[2].SetFloat("_Visbility", Down);
            CS.WallMaterials[3].SetFloat("_Visbility", 0f);
        }
        else
        {
            CS.WallMaterials[0].SetFloat("_Visbility", Up);
            CS.WallMaterials[1].SetFloat("_Visbility", 15f);
            CS.WallMaterials[2].SetFloat("_Visbility", Down);
            CS.WallMaterials[3].SetFloat("_Visbility", 1f);
        }

        if(portalRoom == false)
        {
            T.transform.Rotate((x - 0.1f), y, z, Space.World);
        }
        else
        {
            T.transform.Rotate((x + 0.1f), y, z, Space.World);
        }

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
                Down = 15f;
                Up = 0f;
                Player.transform.parent = null;
                Player.transform.rotation = new Quaternion(0, 0, 0, 0);
                Player.transform.SetParent(T);
                if (portalRoom == false)
                {
                    CS.WallMaterials[0].SetFloat("_Visbility", 15f);
                    CS.WallMaterials[1].SetFloat("_Visbility", 15f);
                    CS.WallMaterials[2].SetFloat("_Visbility", 0f);
                    CS.WallMaterials[3].SetFloat("_Visbility", 0f);
                }
                else
                {
                    CS.WallMaterials[0].SetFloat("_Visbility", 15f);
                    CS.WallMaterials[1].SetFloat("_Visbility", 15f);
                    CS.WallMaterials[2].SetFloat("_Visbility", 1f);
                    CS.WallMaterials[3].SetFloat("_Visbility", 1f);
                }
            }
            MT.gameObject.layer = 0;
        }
    }

    IEnumerator RightRotate()
    {
        if(portalRoom == false)
        {
            T.transform.Rotate((x + 0.1f), y, z, Space.World);
        }
        else
        {
            T.transform.Rotate((x - 0.1f), y, z, Space.World);
        }

        if (CS.gameObject.activeSelf == true)
        {
            if(portalRoom == false)
            {
                Down -= 0.0166666666666667f;
                Up += 0.0166666666666667f;
            }
            else
            {
                Down -= 0.0155555555555556f;
                Up += 0.0155555555555556f;
            }
        }

        if(portalRoom == false)
        {
            CS.WallMaterials[0].SetFloat("_Visbility", 15f);
            CS.WallMaterials[1].SetFloat("_Visbility", Up);
            CS.WallMaterials[2].SetFloat("_Visbility", 0f);
            CS.WallMaterials[3].SetFloat("_Visbility", Down);
        }
        else
        {
            CS.WallMaterials[0].SetFloat("_Visbility", 15f);
            CS.WallMaterials[1].SetFloat("_Visbility", Up);
            CS.WallMaterials[2].SetFloat("_Visbility", 1f);
            CS.WallMaterials[3].SetFloat("_Visbility", Down);
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
            Player.transform.parent = null;
            Player.transform.rotation = new Quaternion(0, 0, 0, 0);
            Player.transform.SetParent(T);
            if (CS.gameObject.activeSelf == true)
            {
                Down = 15f;
                Up = 0f;
                if (portalRoom == false)
                {
                    CS.WallMaterials[0].SetFloat("_Visbility", 15f);
                    CS.WallMaterials[1].SetFloat("_Visbility", 15f);
                    CS.WallMaterials[2].SetFloat("_Visbility", 0f);
                    CS.WallMaterials[3].SetFloat("_Visbility", 0f);
                }
                else
                {
                    CS.WallMaterials[0].SetFloat("_Visbility", 15f);
                    CS.WallMaterials[1].SetFloat("_Visbility", 15f);
                    CS.WallMaterials[2].SetFloat("_Visbility", 1f);
                    CS.WallMaterials[3].SetFloat("_Visbility", 1f);
                }
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
        /*Material0 = CS.WallMaterials[0].color;
        Material1 = CS.WallMaterials[1].color;
        Material2 = CS.WallMaterials[2].color;
        Material3 = CS.WallMaterials[3].color;*/

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
        /*Material0 = CS.WallMaterials[0].color;
        Material1 = CS.WallMaterials[1].color;
        Material2 = CS.WallMaterials[2].color;
        Material3 = CS.WallMaterials[3].color;   */     
        
    }
}
