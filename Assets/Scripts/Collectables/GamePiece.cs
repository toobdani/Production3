using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    [SerializeField] int PieceNumber;

    [SerializeField] LoadingCount LC;

    [SerializeField] GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LC.Pieces[PieceNumber] == true)
        {
            Parent.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        LC.Pieces[PieceNumber] = true;

        if(PieceNumber != 0)
        {
            LC.ChangeScene(0);
        }

    }
}
