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
            board.Expand(1);
        }

        if (Input.GetKey("down"))
        {
            board.Expand(-1);
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

        if(Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float delta = Input.GetAxis("Mouse ScrollWheel");

            float min = board.levels[0].position.y+3;
            float max = board.levels[board.levels.Length-1].position.y+3;

            float pos = Mathf.Clamp(transform.parent.position.y + delta * 8f,min,max);

            transform.parent.position = new Vector3(0, pos, 0);
        }

    }

    // Orbit
    void LateUpdate()
    {
        OrbitCamera();
    }

    public void OrbitCamera()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 target = Vector3.zero; //this is the center of the scene, you can use any point here
            float y_rotate = Input.GetAxis("Mouse X") * 10f;
            float x_rotate = Input.GetAxis("Mouse Y") * -10f;
            OrbitCamera(target, y_rotate, x_rotate);
        }
    }

    public void OrbitCamera(Vector3 target, float y_rotate, float x_rotate)
    {
        Vector3 angles = transform.eulerAngles;
        angles.z = 0;
        transform.eulerAngles = angles;
        transform.RotateAround(target, Vector3.up, y_rotate);
        transform.RotateAround(target, Vector3.left, x_rotate);

        transform.LookAt(target);
    }


}
