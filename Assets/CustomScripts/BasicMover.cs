using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMover : MonoBehaviour
{
    public enum motionDirections { Spin, Horizontal, Vertical };
    public motionDirections motionDirection = motionDirections.Vertical;

    public float spinSpeed = 180.0f;
    public float motionMagnitude = 0.1f;
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        switch (motionDirection)
        {
        // rotate the object around y-axis at the defined spinspeed (a/c to frame update speed of the computer)
            case motionDirections.Spin:
                gameObject.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
                break;
        // levitate the object vertically
            case motionDirections.Vertical:
                gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;
        // levitate the object horizontally
            case motionDirections.Horizontal:
                gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;
        }
    }
}
