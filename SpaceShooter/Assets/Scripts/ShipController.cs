using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{

    public float tiltSpeed = 5f;

    [Header("Weapon")]
    public GameObject weaponToInstatiate;
    public Transform weaponSpawn;

    private Rigidbody rigidbody;


    protected void Start()
    {
        CreateWeapon();
        rigidbody = GetComponent<Rigidbody>();
    }


   public Weapon CreateWeapon()
    {
        GameObject newWeapon = Instantiate(weaponToInstatiate, weaponSpawn.transform.position, weaponToInstatiate.transform.rotation) as GameObject;         // Create Weapon in weapon spown pint
        newWeapon.transform.SetParent(weaponSpawn);                                                                                  // parentto spawn weapon point
        Weapon weaponScript = newWeapon.GetComponent<Weapon>();                                                                                // Get Reference to Weapon in gameobject weapon   
        return weaponScript;
    }


    public void TiltWings()
    {
        rigidbody.rotation = Quaternion.Euler(0, 0, -rigidbody.velocity.x * tiltSpeed);
    }
}   // Karol Sobanski, Piotr Pusz
