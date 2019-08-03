using UnityEngine;

public class DragMouseOrbit : MonoBehaviour
{
    Transform target;

    public float distance = 15.0f;
    public float xSpeed = 55f;
    public float ySpeed = 55f;
    public float yMinLimit = 0f;
    public float yMaxLimit = 90f;

    public float smoothTime = 20f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;
    Board board;

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
        distance = Mathf.Lerp(distance, board.camDistance, Time.deltaTime * (smoothTime/2));

        if (Input.GetMouseButton(0) && !board.expanded) // Orbit
        {
            velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
            velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
        }
        else if (Input.GetMouseButton(0)) // Levels navigation
        {
            float y = target.position.y + -Input.GetAxis("Mouse Y");
            target.position = new Vector3(0, y, 0);
        }
        else // Go to nearest level
        {
            Transform nearest = board.levels[0];
            foreach (Transform t in board.levels)
            {
                if (Vector3.Distance(target.position, t.position) < Vector3.Distance(target.position, nearest.position))
                    nearest = t;
            }
            target.position = new Vector3(0, nearest.position.y, 0);
        }

        rotationYAxis += velocityX;
        rotationXAxis -= velocityY;
        rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);

        Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
        Quaternion rotation = toRotation;

            
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;

        transform.rotation = rotation;
        transform.position = position;
        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}