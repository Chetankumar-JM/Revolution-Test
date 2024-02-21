using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour


{
    public float semiMinorAxis = 0f;
    public float semiMajorAxis = 0f;
    public float rotationSpeed = 5f;
    public float delayDuration = 2f; // Delay duration in seconds

    private float currentDelayTime = 0f;
    private bool isDelayed = true;

    private void Update()
    {
        if (isDelayed)
        {
            // Perform delay before starting the revolution
            currentDelayTime += Time.deltaTime;
            if (currentDelayTime >= delayDuration)
            {
                currentDelayTime = 0f;
                isDelayed = false;
            }
        }
        else
        {
            // Calculate the position in the elliptical path
            float time = Time.time;
            float x = semiMinorAxis * Mathf.Cos(time * rotationSpeed);
            float y = semiMajorAxis * Mathf.Sin(time * rotationSpeed);

            // Set the object's position
            transform.position = new Vector3(x, 0f, y);

            // Rotate the object (optional)
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            // Check for pausing at specific intervals
            CheckPauseAtIntervals();
        }
    }

    private void CheckPauseAtIntervals()
    {
        // You can modify the interval and pause duration as needed
        if (Time.time >= 10f && Time.time < 12f)
        {
            // Pause for 2 seconds after 10 seconds
            PauseRotation(2f);
        }
        else if (Time.time >= 22f && Time.time < 25f)
        {
            // Pause for 3 seconds after 20 seconds
            PauseRotation(3f);
        }
        // Add more conditions for other intervals if needed
    }

    private void PauseRotation(float pauseTime)
    {
        isDelayed = true;
        // Pause the elliptical path revolution
        StartCoroutine(ResumeRotationAfterDelay(pauseTime));
    }

    private IEnumerator ResumeRotationAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Resume the elliptical path revolution
        isDelayed = false;
    }
}


