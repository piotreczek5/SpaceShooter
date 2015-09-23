using UnityEngine;
using System.Collections;

public class DestroyByCollision : MonoBehaviour
{
    public int damage = 30;
    public GameObject[] destroyEffects;
    public AudioClip[] destroySounds;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Background") return;                                          // if it's Background return
        if (gameObject.tag == other.tag) return;                                        // if it's the same tag return


        if (destroyEffects.Length > 0)                                                        // if ther is some destroyeffects attached
        {
            int randIndex = Random.Range(0, destroyEffects.Length);                               // choose random index in array

            GameObject randEffect = destroyEffects[Random.Range(0, destroyEffects.Length)];
            Instantiate(randEffect, transform.position, transform.rotation);
        }
        else
            Debug.LogError("There is no destroy effect attached to " + gameObject.name);


        if (other.GetComponent<ObjectController>())            // if it exist
            other.GetComponent<ObjectController>().TakeDamage(damage);

        if (destroySounds.Length > 0)
        {
            SoundManager.instance.RandomizeSfx(ref destroySounds, ref audioSource);
            audioSource.Play();
        }
        else
            Debug.Log(other.name + " hasn't ObjectController script!");


        Destroy(gameObject);
    }
}   // Karol Sobanski