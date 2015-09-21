using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public abstract class ShipController : MonoBehaviour
{
    [Header("Player Statistics")]
    public int maxHealth = 100;
    public float armour = 100f;
    public float moveSpeed = 5f;
    public float tiltSpeed = 5f;
    public GameObject weapon;
    public Transform weaponSpawn;

    protected Rigidbody rigidbody;
	public GameObject explosionObject;

    private Weapon weaponScript;

	public GameObject gameObject;
    private float nextShoot;                                                                            // time to next shoot



    protected void Start()
    {
        CreateWeapon();
        weaponScript = weapon.GetComponent<Weapon>();                                                  // Get Reference to Weapon in gameobject weapon
        rigidbody = GetComponent<Rigidbody>();
    }


    protected void FixedUpdate()
    {
     //   Shot();                                                                                        // check if player can shoot
    }


    protected void Move(Vector3 movement)
    {
        rigidbody.velocity = movement * moveSpeed;                                                      // set velocity

        if (rigidbody.velocity.x != 0)                                                                  // if is any move on x axis
            rigidbody.rotation = Quaternion.Euler(0, 0, -rigidbody.velocity.x * tiltSpeed);             // tilt ship's wings
        // TODO: Mobile Wibration
    }


    //protected virtual void Shot()
    // {
    //     weaponScript.WeaponShot(transform.position);
    // }


    void CreateWeapon()
    {
        GameObject newWeapon = Instantiate(weapon, weaponSpawn.transform.position, weapon.transform.rotation) as GameObject;         // Create Weapon in weapon spown pint
        newWeapon.transform.SetParent(weaponSpawn);                                                                                  // parentto spawn weapon point
    }


    protected abstract void AttemptMove();                                                                                           // move implementation to do
}   // Karol Sobanski, Piotr Pusz
