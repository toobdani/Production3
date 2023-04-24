using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "LoadingObject", order = 3, fileName = "Loading Count")]
public class LoadingCount : ScriptableObject
{
    [SerializeField] int Lobby;

    public int Going;

    public int PieceNumber;

    public bool[] Pieces;

    public bool[] LobbyPieces;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(int Location)
    {
        Going = Location;
        SceneManager.LoadScene(4);
    }
}
