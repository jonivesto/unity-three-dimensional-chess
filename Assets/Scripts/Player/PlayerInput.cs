using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Board board;
    Collider clickEnter;

    public Transform t1, t2;

    private Vector3 position;
    private float width, height;
    private float lastDistance = 0f;


    void Start()
    {
        board = GameObject.Find("/Board").GetComponent<Board>();
        width = Screen.width / 2.0f;
        height = Screen.height / 2.0f;
    }

    void Update()
    {
        // EXPAND (pinch)
        /*if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            board.expanded = true;
            board.selectedLevel = board.levels[Mathf.FloorToInt(board.halfBoardSize)];
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            board.expanded = false;
            transform.parent.position = new Vector3(0, 0, 0);
        }*/

        // EXPAND (pinch)        
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 pos = touch1.position;
            pos.x = (pos.x - width) / width;
            pos.y = (pos.y - height) / height;
            position = new Vector3(-pos.x, pos.y, 0.0f);
            t1.position = position;

            pos = touch2.position;
            pos.x = (pos.x - width) / width;
            pos.y = (pos.y - height) / height;
            position = new Vector3(-pos.x, pos.y, 0.0f);
            t2.position = position;

            float d = Vector3.Distance(t1.position, t2.position);
            if(d>lastDistance)
            {
                board.expanded = true;
                board.selectedLevel = board.levels[Mathf.FloorToInt(board.halfBoardSize)];                
            }
            else if (d < lastDistance)
            {
                board.expanded = false;
                transform.parent.position = new Vector3(0, 0, 0);
            }
            lastDistance = d;
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
