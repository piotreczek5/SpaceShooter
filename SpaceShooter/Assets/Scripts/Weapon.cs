using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
    public float timeBetweenBullets = 0.15f;                        // time between each shot
    public Transform bulletSpawn;
    public AudioClip[] gunAudios;
    
    protected float timeToShot;
    protected ParticleSystem gunParticle;
    protected Light gunLight;

    public int damageMultiplier = 1;
    
    private AudioSource audioSource;



    protected virtual void Update()
    {
        timeToShot += Time.deltaTime;
    }


    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gunParticle = bulletSpawn.GetComponent<ParticleSystem>();
        gunLight = bulletSpawn.GetComponent<Light>();
    }


    protected void ShotEffects()
    {
        SoundManager.instance.RandomizeSfx(ref gunAudios, ref audioSource);
        audioSource.Play();

        gunLight.enabled = true;
        gunParticle.Stop();
        gunParticle.Play();
    }



    public abstract void Shot();
}   // Karol Sobanski
