using UnityEngine;
using System.Collections;

[System.Serializable]
public class VisualWeapon
{
    public GameObject weapon;
    public Transform weaponSpawn;

    [HideInInspector]
    public Weapon weaponScripts;
}


[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public abstract class ObjectController : MonoBehaviour
{
    [Header("Main Statistics")]
    public int maxHealth = 100;
    public float horizontalMove = 5f;
    public float verticalMove = 0f;
    public float moveSpeed = 10;
    public GameObject destroyExplosion;
    public AudioClip destroySound;
    public Vector3 boundryPosition;
    public VisualWeapon[] visualWeapons;
    protected Rigidbody rigidbody;



    protected virtual void Start()
    {
        boundryPosition = GameMaster.instance.boundry;                // set boundry form GameMaster
        rigidbody = GetComponent<Rigidbody>();

        if (visualWeapons.Length > 0)                                   // Get Reference to all Weapons
            for (int i = 0; i < visualWeapons.Length; i++)
                visualWeapons[i].weaponScripts = WeaponCreator(ref visualWeapons[i].weapon, ref visualWeapons[i].weaponSpawn);
    }


    protected void DestroyEffect()
    {
        if (destroySound != null)
            AudioSource.PlayClipAtPoint(destroySound, transform.position);                 // Create AudioSource for while, because gameObject'll be destroy

        if (destroyExplosion != null)
        {
          GameObject newExplosion =  Instantiate(destroyExplosion, transform.position, transform.rotation) as GameObject;         // Create explosion
          newExplosion.transform.SetParent(GameMaster.instance.hierarchyGuard);
        }
    }


    protected virtual void Move()
    {
        Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);
        rigidbody.velocity = movement * moveSpeed;
    }


    public Weapon WeaponCreator(ref GameObject  weapon, ref Transform weaponSpawn)
    {
        GameObject newWeapon = Instantiate(weapon, weaponSpawn.position, weapon.transform.rotation) as GameObject;         // Create Weapon in weapon spown pint
        newWeapon.transform.SetParent(weaponSpawn);                                                                        // parentto spawn weapon point
        return newWeapon.GetComponent<Weapon>();                                                                           // return Weapon script
    }


    public abstract void TakeDamage(int damage);
    protected abstract void CheckBoundry();                                                // enemy and player have  your own boundry
}   //Karol Sobanski