using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public abstract class ShipController : MonoBehaviour
{
    [Header("Player Statistics")]
    public int maxHealth = 100;
    public float armour = 100f;
    public float moveSpeed = 5f;
    public float fireRate = 0.2f;
    public float tiltSpeed = 5f;
    public GameObject weapon;
    public Transform weaponSpawn;

    protected Rigidbody rigidbody;
	public GameObject gameObject;
    private float nextShoot;                                                                            // time to next shoot


    protected void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    protected void FixedUpdate()
    {
        Shoot();                                                                                        // check if player can shoot
    }


    protected void Move(Vector3 movement)
    {
        rigidbody.velocity = movement * moveSpeed;                                                      // set velocity

        if (rigidbody.velocity.x != 0)                                                                  // if is any move on x axis
            rigidbody.rotation = Quaternion.Euler(0, 0, -rigidbody.velocity.x * tiltSpeed);             // tilt ship's wings
        // TODO: Mobile Wibration
    }


    protected virtual void Shoot()
    {
        if (Time.time > nextShoot)                                                                      // check if time to next shoot is left;
        {
            nextShoot = Time.time + fireRate;                                                           // set new nextShoot time
           GameObject newShoot = Instantiate(weapon, weaponSpawn.position, weaponSpawn.rotation) as GameObject;
           newShoot.transform.SetParent(GameMaster.instance.player);
        }
    }

    protected abstract void AttemptMove();                                                              // move implementation to do
}
