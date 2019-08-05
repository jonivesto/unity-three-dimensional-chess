using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Board board;
    Collider clickEnter;

    void Start()
    {
        board = GameObject.Find("/Board").GetComponent<Board>();
    }

    void Update()
    {
        // EXPAND (pinch)
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            board.expanded = true;
            board.selectedLevel = board.levels[Mathf.FloorToInt(board.halfBoardSize)];
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            board.expanded = false;
            transform.parent.position = new Vector3(0, 0, 0);
        }

        // CLICK (tap)
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                clickEnter = hit.collider;               
            }
            else
            {
                clickEnter = null;               
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (clickEnter == hit.collider) board.Click(clickEnter);
            }
            else
            {
                if (clickEnter == hit.collider) board.Click(clickEnter);
            }

            clickEnter = null;
            
        }
    }


}
