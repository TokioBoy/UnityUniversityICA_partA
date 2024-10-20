using UnityEngine;

public class SpiningItem : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the Y-axis (up) every frame
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
