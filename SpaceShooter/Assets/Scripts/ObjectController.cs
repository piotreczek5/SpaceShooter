using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public abstract class ObjectController : MonoBehaviour
{
    [Header("Main Statistics")]
    public int maxHealth = 100;
    public float moveSpeed = 5f;
    public GameObject destroyExplosion;
    public AudioClip destroySound;

    protected Rigidbody rigidbody;
    

    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    public virtual void TakeDamage(int damage)
    {
        print(gameObject.name + " pozostalo " + maxHealth + "zycia");
        maxHealth -= damage;
        if (maxHealth <= 0)
        {
            DestroyEffect();
            Destroy(gameObject);
        }
    }


    protected void DestroyEffect()
    {
        if (destroySound != null)
            AudioSource.PlayClipAtPoint(destroySound, transform.position);                 // Create AudioSource for while, because gameObject'll be destroy

        if (destroyExplosion != null)
            Instantiate(destroyExplosion, transform.position, transform.rotation);         // Create explosion
    }


    protected abstract void AttemptMove();                                                                                           // move implementation to do

}   //Karol Sobanski