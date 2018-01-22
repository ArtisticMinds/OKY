using UnityEngine;
//WILEz SmoothCamera v2.3



public class W_SmoothCamera : MonoBehaviour
{

    // The target we are following
   // [HideInInspector]
    public Transform target;
    // The distance in the x-z plane to the target
    //[HideInInspector]
    public float distance = 2f;
    // the height we want the camera to be above the target
  //  [HideInInspector]
    public float height = 2.0f;
    public bool OnlyY = true;
  //  [HideInInspector]
    public float rotationDamping = 2;
  //  [HideInInspector]
    public float heightDamping = 1;

    // Use this for initialization
    void Awake()
    {

      //  target = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (OnlyY)
            FollowY();
        else
        FollowPlayer();
    }

    void FollowY()
    {

        // Early out if we don't have a target
        if (!target)
            return;

        // Calculate the current rotation angles
        var wantedRotationAngle = target.eulerAngles.y;
        var wantedHeight = target.position.y + height;

        var currentRotationAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
     //   currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime * GameManager.TimeMultipler);

        // Convert the angle into a rotation
        //  var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        //transform.position = GameManager.tower.transform.position;
        // transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera
        //     transform.position = new Vector3(target.position.x, target.position.y, target.position.z)+transform.forward*distance;
       // transform.RotateAround(GameManager.tower.transform.position, transform.up, -FindObjectOfType<W_UserControl>().m_Rigidbody.velocity.x / 10 + FindObjectOfType<W_UserControl>().m_Rigidbody.velocity.z / 10);
        // Always look at the target
    //    transform.LookAt(target);

    }
    void FollowPlayer()
    {

        // Early out if we don't have a target
        if (!target)
            return;

        // Calculate the current rotation angles
        var wantedRotationAngle = target.eulerAngles.y;
        var wantedHeight = target.position.y + height;

        var currentRotationAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime * GameManager.TimeMultipler);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime * GameManager.TimeMultipler);

        // Convert the angle into a rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Always look at the target
        transform.LookAt(target);
    }

}
