using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public LayerMask ownerLayer;             // owner - could be Enemy or Player
    public int damage;
    public GameObject shootEffect;           // particle
    public GameObject destroyEffect;         // particle



    void Start()
    {
        GameObject effect = Instantiate(shootEffect, transform.position, transform.rotation) as GameObject;           // Create weapon shoot effect
        effect.transform.SetParent(GameMaster.instance.player);                                                       // parent effect to player's ship
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(ownerLayer)) return;                      // if I hit object that create me with the same layer return void;

        Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}   // Karol Sobanski
