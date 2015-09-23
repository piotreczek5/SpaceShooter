using UnityEngine;
using System.Collections;

public class SlowWeapon : Weapon
{
    public GameObject bullet;                // bullet takes damage enemy

    public override void Shot()
    {
        if (timeToShot > timeBetweenBullets && Time.timeScale != 0)    // if player press button, time to next shot left, pause is off)
        {
            timeToShot = 0f;                                                                               // reset time
            Instantiate(bullet, transform.position, transform.rotation);
            ShotEffects();
        }
    }


}   // Karol Sobanski
