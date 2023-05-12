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

    float playerx;

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

    [SerializeField] FirstRoomStairs FRS;

    [SerializeField] float RotateSpeed;

    [SerializeField] float LoopCountAmount;

    [SerializeField] float RotateAmount;

    [SerializeField] float ChangeTrasnparent;

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

        RotateAmount = 90 / LoopCountAmount;

        if(portalRoom == false)
        {
            ChangeTrasnparent = 15 / LoopCountAmount;
        }
        else
        {
            ChangeTrasnparent = 14 / LoopCountAmount;
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
                if(FRS != null)
                {
                    FRS.MoveMaterialUp();
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
                if (FRS != null)
                {
                    FRS.MoveMaterialDown();
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

        Down -= ChangeTrasnparent;
        Up += ChangeTrasnparent;

        if (portalRoom == false)
        {
            CS.WallMaterials[0].SetFloat("_Visbility", Up);
            CS.WallMaterials[1].SetFloat("_Visbility", 15f);
            CS.WallMaterials[2].SetFloat("_Visbility", Down);
            CS.WallMaterials[3].SetFloat("_Visbility", 0f);

            if (FRS != null)
            {
                FRS.StairMaterials[0].SetFloat("_Visbility", Up);
                FRS.StairMaterials[1].SetFloat("_Visbility", 15f);
                FRS.StairMaterials[2].SetFloat("_Visbility", Down);
                FRS.StairMaterials[3].SetFloat("_Visbility", 1f);

            }
        }
        else
        {
            CS.WallMaterials[0].SetFloat("_Visbility", Up);
            CS.WallMaterials[1].SetFloat("_Visbility", 15f);
            CS.WallMaterials[2].SetFloat("_Visbility", Down);
            CS.WallMaterials[3].SetFloat("_Visbility", 1f);
        }


            T.transform.Rotate((x - RotateAmount), y, z, Space.World);
            Player.transform.Rotate((playerx + RotateAmount), y, z, Space.World);
            //T.transform.Rotate((x - 1f), y, z, Space.World);

        if(Cameratransform != null)
        {
            Cameratransform.transform.Rotate((x + RotateAmount), y, z, Space.World);
            //Cameratransform.transform.Rotate((x + 1f), y, z, Space.World);
        }

        loopcount++;
        yield return new WaitForSeconds(RotateSpeed);
        if(loopcount != LoopCountAmount)
        {
            StartCoroutine(LeftRotate());
        }
        else
        {
            MT.MyRigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
            MT.MoveAllow = 2;
            MT.XRotation += 90;
            if (FRS != null)
            {
                FRS.ChangeStairsLeft();
            }
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

            T.transform.Rotate((x + RotateAmount), y, z, Space.World);
            Player.transform.Rotate((playerx - RotateAmount), y, z, Space.World);
            //T.transform.Rotate((x + 1f), y, z, Space.World);
        

        Down -= ChangeTrasnparent;
        Up += ChangeTrasnparent;

        if (portalRoom == false)
        {
            CS.WallMaterials[0].SetFloat("_Visbility", 15f);
            CS.WallMaterials[1].SetFloat("_Visbility", Up);
            CS.WallMaterials[2].SetFloat("_Visbility", 0f);
            CS.WallMaterials[3].SetFloat("_Visbility", Down);


            if (FRS != null)
            {
                FRS.StairMaterials[0].SetFloat("_Visbility", Up);
                FRS.StairMaterials[1].SetFloat("_Visbility", 15f);
                FRS.StairMaterials[2].SetFloat("_Visbility", Down);
                FRS.StairMaterials[3].SetFloat("_Visbility", 1f);

            }
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
            Cameratransform.transform.Rotate((x - RotateAmount), y, z, Space.World);
            //Cameratransform.transform.Rotate((x - 1f), y, z, Space.World);
        }

        loopcount++;
        yield return new WaitForSeconds(RotateSpeed);
        if (loopcount != LoopCountAmount)
        {
            StartCoroutine(RightRotate());
        }
        else
        {
            MT.MyRigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
            MT.MoveAllow = 2;
            MT.XRotation -= 90;
            Player.transform.parent = null;
            Player.transform.rotation = new Quaternion(0, 0, 0, 0);
            Player.transform.SetParent(T);
            if (FRS != null)
            {
                FRS.ChangeStairsLeft();
            }
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
