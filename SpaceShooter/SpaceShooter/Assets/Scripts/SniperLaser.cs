using UnityEngine;
using System.Collections;

public class SniperLaser : MonoBehaviour
{
    [Tooltip("distance where gun can fire")]
    public float range;
    public GameObject laserPoint;

    private Ray shootRay;
    private LineRenderer gunLine;
    private RaycastHit shootHit;



    void Start()
    {
        gunLine = GetComponent<LineRenderer>();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);


    }

    void Update()
    {
        gunLine.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range))
        {
            gunLine.SetPosition(1, shootHit.point);                               // set the second position of the line renderer to the point the raycast hit
            Instantiate(laserPoint, shootHit.point, transform.rotation);
        }
        else
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);  // set the  second position of the line renderer to the fullest extent of the gun's range
    }
}
