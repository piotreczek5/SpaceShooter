using UnityEngine;    
using System.Collections;

public class RandomScale : MonoBehaviour
{
    public float minScale = 0.5f, maxScale = 3.5f;


    void Start()
    {
        float newScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}  // Karol Sobanski
