using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{

    public bool randomStartRotateOnXAxis;
    public bool randomStartRotateOnYAxis;
    public float rotateSpeed = 2;
    [Tooltip("Interval rotate values in deegres")]
    public float minXRotate = 0, maxXRotate = 360;


    private float x;
    private float y;



    void Start()
    {
        if (randomStartRotateOnXAxis)
            x = Random.Range(minXRotate, maxXRotate);        // random rotation X
        else
            x = transform.rotation.eulerAngles.x;


        if (randomStartRotateOnYAxis)
            y = Random.Range(0, 360);                        // random rotation Y
        else
            y = transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        Vector3 newRotation = new Vector3(x, y, rotateSpeed * Time.time);
        transform.rotation = Quaternion.Euler(newRotation);
    }
}  // Karol Sobanski
