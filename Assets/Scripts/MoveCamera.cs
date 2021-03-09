using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform marker1;
    public Transform marker2;

    Transform startMarker;
    Transform endMarker;

    //The look at target
    public Transform lookAtTarget; 

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    //
    bool moving = false; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            // Distance moved equals elapsed time times speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);

            //Keep looking at a target
            transform.LookAt(lookAtTarget, Vector3.up);

            Debug.Log (Vector3.Distance(transform.position, endMarker.position));

            if (Vector3.Distance(transform.position, endMarker.position) < 0.01f) {
                moving = false; 
            }
        }
        else {

            startMarker = marker1;
            endMarker = marker2;

            // Keep a note of the time the movement started.
            startTime = Time.time;

            // Calculate the journey length.
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

            if (Input.GetKeyUp(KeyCode.Alpha1)) {
                startMarker = marker2;
                endMarker = marker1;
                moving = true; 
            }

            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                startMarker = marker1;
                endMarker = marker2;
                moving = true;
            }
        }
    }
}
