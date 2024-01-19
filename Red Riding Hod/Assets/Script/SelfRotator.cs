using UnityEngine;

/// <summary>
/// SelfRotator is a class that rotates itself around its own axis.
/// </summary>
public class SelfRotator : MonoBehaviour
{
    public float startAngle = 0;                                    // start angle value
    public float dAngle = 1;                                        // angle derivative value
    public float rotationSpeed = 1.0f;                              // rotation speed

    public bool randDAngle = false;
    public float dStartAngle = 0.5f;                                // start value for creating dAngle value for saw
    public float dEndAngle = 2.0f;                                  // end value for creating dAngle value for saw

    private float curr_angle = 0;                                   // current angle value

    // Start is called before the first frame update
    void Start()
    {
        curr_angle = startAngle;                                    // initialize current angle value

        if (randDAngle) setRandDAngle();                            // set a random value for the angle of rotation
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its forward axis at a defined speed
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        curr_angle += dAngle;

        if (curr_angle >= 360)
            curr_angle -= 360;
        else if (curr_angle <= -360)
            curr_angle += 360;
    }

    /// <summary>
    /// Method to set a random value for dAngle
    /// </summary>
    public void setRandDAngle()
    {
        dAngle = (Random.Range(0, 2) == 0 ? -1 : 1) * Random.Range(dStartAngle, dEndAngle);     // change dAngle value
    }
}
