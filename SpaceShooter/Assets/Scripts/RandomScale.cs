using UnityEngine;    
using System.Collections;

public class RandomScale : MonoBehaviour
{
    [Header("The same scale for Axis")]
    public float minScale = 0.5f, maxScale = 3.5f;


    void Start()
    {
        float newScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}  // Karol Sobanski
