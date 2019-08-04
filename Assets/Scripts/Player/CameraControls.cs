using UnityEngine;

public class CameraControls : MonoBehaviour
{
    Transform target;
    Board board;

    float distance = 15.0f;
    float xSpeed = 19f;
    float ySpeed = 66f;
    float yMinLimit = 0f;
    float yMaxLimit = 90f;
    float smoothTime = 20f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;
    float scrollY = 0f;
    

    // Use this for initialization
    void Start()
    {
        target = transform.parent;
        board = GameObject.Find("/Board").GetComponent<Board>();
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
    }

    void LateUpdate()
    {
        distance = Mathf.Lerp(distance, board.camDistance, Time.deltaTime * 10f);
        board.Expand(board.expanded);

        if (!board.expanded) // Orbit control
        {
            if (Input.GetMouseButton(0)) // Get input
            {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
            }

            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
        }
        else // Expanded control
        {
            if (Input.GetMouseButton(0)) // Get input
            {
                scrollY = -Input.GetAxis("Mouse Y");
                target.Translate(Vector3.up * scrollY);
            }

            rotationXAxis = 35f;
            rotationYAxis = 0f; // TODO: 0 or 180 depends of player turn
        }

        Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
        Quaternion rotation = toRotation;
 
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;

        transform.rotation = rotation;
        transform.position = position;
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 15f);
        //transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 15f);
        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        
    }

    // Limit rotation
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
        {
            angle += 360F;
        }

        if (angle > 360F)
        {
            angle -= 360F;
        }

        return Mathf.Clamp(angle, min, max);
    }
}