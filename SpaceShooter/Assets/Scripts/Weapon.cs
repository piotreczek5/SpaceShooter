using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
    public float timeBetweenBullets = 0.15f;                        // time between each shot
    public Transform bulletSpawn;

    protected float timeToShot;
    protected AudioSource gunAudio;
    protected ParticleSystem gunParticle;
    protected Light gunLight;




    protected virtual void Update()
    {
        timeToShot += Time.deltaTime;
    }


    protected virtual void Start()
    {
        gunParticle = bulletSpawn.GetComponent<ParticleSystem>();
        gunAudio = bulletSpawn.GetComponent<AudioSource>();
        gunLight = bulletSpawn.GetComponent<Light>();

        gunParticle.Stop();                                      //  prevents  particle to play on start game
    }


    protected void ShotEffects()
    {
        CameraShake.instance.Shake(0.02f, 0.1f);

        gunAudio.Play();
        gunLight.enabled = true;
        gunParticle.Stop();
        gunParticle.Play();
    }
}   // Karol Sobanski
