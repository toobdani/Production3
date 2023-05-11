using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReset : MonoBehaviour
{
    [SerializeField] LoadingCount LC;
    [SerializeField] bool CompletedTask;

    [SerializeField] int BoolAmount;
    [SerializeField] int AmountCount;
    // Start is called before the first frame update
    void Start()
    {
        BoolAmount = 0;
        LC.Pieces[0] = false;
        LC.LobbyPieces[0] = false;        
        LC.Pieces[1] = false;
        LC.LobbyPieces[1] = false;        
        LC.Pieces[2] = false;
        LC.LobbyPieces[2] = false;
    }

}
