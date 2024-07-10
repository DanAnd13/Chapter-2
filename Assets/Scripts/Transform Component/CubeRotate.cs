using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeRotate : MonoBehaviour
{
    public Vector3 initialEulerAngles = new Vector3(0, 0, 0);

    private float rotationSpeed = 360.0f;

    void QuaternionsRotation(float angle)
    {
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = rotation;
    }
    void EulerAngleRotation(float angle)
    {
        Vector3 rotation = new Vector3(0, angle, 0);
        transform.eulerAngles += rotation;
    }

    void Start()
    {
        transform.rotation = Quaternion.Euler(initialEulerAngles);
    }

    void Update()
    {
        float angle = rotationSpeed * Time.deltaTime;

        QuaternionsRotation (angle);
        //EulerAngleRotation (angle);
    }
}