using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private Vector3 initialPosition;
    private float amplitude = 0.1f;
    private float duration = 0.5f;
    private bool isShaking;


    void Update()
    {
        if (isShaking)
            transform.localPosition = initialPosition + Random.insideUnitSphere * amplitude;
    }


    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        initialPosition = transform.position;
    }


    public void Shake(float amplitude, float duration)
    {
        this.amplitude = amplitude;
        isShaking = true;
        CancelInvoke();
        Invoke("StopShaking", duration);
    }


    public void StopShaking()
    {
        isShaking = false;
    }
}   // Karol Sobanski
