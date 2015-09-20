using UnityEngine;
using System.Collections;

public class DestroyByCollision : MonoBehaviour
{
    // zrobic liste tagow do wyboru
    public GameObject[] destroyEffects;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Background") return;                                          // if it's Background return
        if (gameObject.tag == other.tag) return;                                        // if it's the same tag return

        //print(gameObject.tag + " " + other.name);
        if (destroyEffects.Length > 0)                                                        // if ther is some destroyeffects attached
        {
            int randIndex = Random.Range(0, destroyEffects.Length);                               // choose random index in array

            GameObject randEffect = destroyEffects[Random.Range(0, destroyEffects.Length)];
            Instantiate(randEffect, transform.position, transform.rotation);
        }
        else
            Debug.LogError("There is no destroy effect attached to " +  gameObject.name);

        Destroy(gameObject);
    }
}   // Karol Sobanski
