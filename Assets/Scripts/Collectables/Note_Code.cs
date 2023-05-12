using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Code : MonoBehaviour
{

    [SerializeField] GameObject NoteUI;

    [SerializeField] movementTest MT;

    // Start is called before the first frame update
    void Start()
    {
        NoteUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(NoteUI.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                NoteUI.SetActive(false);
                StartCoroutine(WaittoMove());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        NoteUI.SetActive(true);
        MT.MoveAllow = 1;
    }

    IEnumerator WaittoMove()
    {
        yield return new WaitForSeconds(0.1f);
        MT.MoveAllow = 0;
        Destroy(gameObject);
    }
}
