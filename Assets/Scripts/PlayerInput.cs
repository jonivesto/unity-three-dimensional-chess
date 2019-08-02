using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Board board;


    void Start()
    {
        board = GameObject.Find("/Board").GetComponent<Board>();
    }

    void Update()
    {
        if (Input.GetKey("up"))
        {
            board.expanded = true;
        }

        if (Input.GetKey("down"))
        {
            board.expanded = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                board.Click(hit.collider);
            }
            else
            {
                board.Click(null);
            }
        }

        

    }

    


}
