using UnityEngine;
using System.Collections;

public class PlayerController : ObjectController
{
    [Header("Human Statistics")]
    public float maxFuel = 100;
    public float tiltSpeed = 5f;

    [Space(10)]
    private float fuelLeft;
    private bool isFuelOver;
    PlayerHealth playerHealth;
    


    protected override void Start()
    {
        base.Start();

        playerHealth = GetComponent<PlayerHealth>();
        fuelLeft = maxFuel;
    }


    protected void FixedUpdate()
    {
        if (!isFuelOver)                       // if fuel tank isn't empty  
            CheckFuel();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            CameraShake.instance.Shake(0.02f, 0.1f);
            for (int i = 0; i < visualWeapons.Length; i++)      // Shot from all weapons
                visualWeapons[i].weaponScripts.Shot();
        }
    }

    // Shoot z shake camera
    public void Refuel(float newFuel)
    {
        fuelLeft = newFuel;
        isFuelOver = false;
    }


    protected override void Move()
    {
        transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);   // ?????!!

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        base.Move();
        CheckBoundry();
        rigidbody.rotation = Quaternion.Euler(0, 0, -rigidbody.velocity.x * tiltSpeed);
    }


    void CheckFuel()
    {
        fuelLeft -= Time.deltaTime;                                   // decrease fuel
        Move();                                                // move ship

        if (fuelLeft < 0)                                             // if fuel is over 
        {
            rigidbody.velocity = Vector3.zero;                        // set ship's velocity set to zero
            rigidbody.rotation = Quaternion.Euler(Vector3.zero);      // rotation set to zero
            isFuelOver = true;
        }
    }


    protected override void CheckBoundry()
    {
        rigidbody.position = new Vector3(
        Mathf.Clamp(rigidbody.position.x, -boundryPosition.x, boundryPosition.x),
        rigidbody.transform.position.y,
        Mathf.Clamp(rigidbody.position.z, 0, boundryPosition.z));
    }


    public override void TakeDamage(int damage)
    {
        playerHealth.TakeDamage(damage);
    }
}   // Karol Sobański, Piotr Pusz