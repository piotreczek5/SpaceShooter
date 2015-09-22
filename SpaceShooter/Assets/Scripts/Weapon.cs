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


    protected virtual void Update()
    {
        timeToShot += Time.deltaTime;
    }


    protected virtual void Start()
    {
        gunParticle = bulletSpawn.GetComponent<ParticleSystem>();
        gunLight = bulletSpawn.GetComponent<Light>();
    }


    protected void ShotEffects()
    {
        CameraShake.instance.Shake(0.02f, 0.1f);

        SoundManager.instance.RandomizeSfx(gunAudios);
        gunLight.enabled = true;
        gunParticle.Stop();
        gunParticle.Play();
    }
}   // Karol Sobanski
