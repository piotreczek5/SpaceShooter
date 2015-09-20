using UnityEngine;
using System.Collections;

public class PlayerController : ShipController
{
    [Header("Human Statistics")]
    public float maxFuel = 100;


    [Space(10)]
    public Vector3 boundryPosition = new Vector3(7, 0, 8);
    private float fuelLeft;
    private bool isFuelOver;


    protected void Start()
    {
        base.Start();
        fuelLeft = maxFuel;
    }


    protected void FixedUpdate()
    {
        base.FixedUpdate();

        if (!isFuelOver)                       // if fuel tank isn't empty  
            CheckFuel();
    }


    public void Refuel(float newFuel)
    {
        fuelLeft = newFuel;
        isFuelOver = false;
    }


    // protected override void Shot()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        CameraShake.instance.Shake(0.02f, 0.1f);
    //        base.Shot();
    //    }
    // }


    protected override void AttemptMove()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);
        rigidbody.velocity = movement * moveSpeed;

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, -boundryPosition.x, boundryPosition.x),
            0,
            Mathf.Clamp(rigidbody.position.z, 0, boundryPosition.z));

        rigidbody.rotation = Quaternion.Euler(0, 0, -rigidbody.velocity.x * tiltSpeed);
    }


    void CheckFuel()
    {
        fuelLeft -= Time.deltaTime;                                   // decrease fuel
        AttemptMove();                                                // move ship

        if (fuelLeft < 0)                                             // if fuel is over 
        {
            rigidbody.velocity = Vector3.zero;                        // set ship's velocity set to zero
            rigidbody.rotation = Quaternion.Euler(Vector3.zero);      // rotation set to zero
            isFuelOver = true;
        }
    }
}   // Karol Sobański, Piotr Pusz