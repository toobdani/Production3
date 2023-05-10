using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby_Code : MonoBehaviour
{
    [SerializeField] LoadingCount LC;

    [SerializeField] GameObject[] Doorways;

    [SerializeField] GameObject[] Pieces;
    // Start is called before the first frame update
    void Start()
    {
        Doorways[2].SetActive(true);
        Doorways[1].SetActive(false);
        Doorways[0].SetActive(false);
        Doorways[3].SetActive(true);
        Doorways[4].SetActive(false);
        Doorways[5].SetActive(false);

        Pieces[0].SetActive(false);
        Pieces[1].SetActive(false);

        if(LC.LobbyPieces[0] == true)
        {
            Pieces[0].SetActive(true);
        }
        else
        {
            Pieces[0].SetActive(false);
        }

        if(LC.LobbyPieces[1] == true)
        {
            Pieces[1].SetActive(true);
        }
        else
        {
            Pieces[1].SetActive(false);
        }

        if (LC.LobbyPieces[2] == true)
        {
            Pieces[2].SetActive(true);
        }
        else
        {
            Pieces[2].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(LC.Pieces[1] == true)
        {
            Doorways[2].SetActive(false);
            Doorways[1].SetActive(true);
            Doorways[0].SetActive(false);
        }
        if(LC.Pieces[2] == true)
        {
            Doorways[3].SetActive(false);
            Doorways[5].SetActive(true);
            Doorways[4].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(LC.Pieces[0] == true)
        {
            Pieces[0].SetActive(true);
            Doorways[2].SetActive(false);
            Doorways[1].SetActive(false);
            Doorways[0].SetActive(true);

            LC.LobbyPieces[0] = true;
        }
        if(LC.Pieces[1] == true)
        {
            Pieces[1].SetActive(true);
            Doorways[3].SetActive(false);
            Doorways[5].SetActive(false);
            Doorways[4].SetActive(true);

            LC.LobbyPieces[1] = true;
        }
        if(LC.Pieces[2] == true)
        {
            Pieces[2].SetActive(true);
            LC.LobbyPieces[2] = true;
        }
    }
}
