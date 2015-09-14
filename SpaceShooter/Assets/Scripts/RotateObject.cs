using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    public bool rotateOnXAxis;
    public float rotateSpeed = 2;
    [Tooltip("Interval rotate values in deegres")]
    public float minXRotate = 0, maxXRotate = 360;

    private float x;
    private float y;



    void Start()
    {
        if (rotateOnXAxis)
            x = Random.Range(minXRotate, maxXRotate);        // random rotation X
        else
            x = transform.rotation.eulerAngles.x;


        y = Random.Range(0, 360);                // random rotation Y
    }

    void Update()
    {
        Vector3 newRotation = new Vector3(x, y, rotateSpeed * Time.time);
        transform.rotation = Quaternion.Euler(newRotation);
    }
}  // Karol Sobanski
