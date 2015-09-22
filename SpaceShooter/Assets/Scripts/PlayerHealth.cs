using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health")]
    public float flashSpeed;
    public Color flashColor = new Color(1, 0, 0, 0.1f);        // red  color

    [Header("Camera shake")]
    public float damageShakeAmplitude = 0.2f;
    public float damageShakeDuration = 0.15f;

    [Header("Reset")]
    public float changeSceneDelay = 0f;

    private Image damageImage;
    private Slider healthSlider;
    private int maxHealth;
    private int currentHealth;
    private bool isDead;
    private bool isDamage;


    void Awake()
    {
        damageImage = GameObject.Find("DamageImage").GetComponent<Image>();              // it's necessary because player does't exist yet
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();           // it's necessary because player does't exist yet
        maxHealth = GetComponent<PlayerController>().maxHealth;                          // Get max health from PlayerController
        currentHealth = maxHealth;
    }


    void Update()
    {
        if (isDamage)
        {
            isDamage = false;                        // reset damage flag
            damageImage.color = flashColor;          // set color to flashColor
        }
        else
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);   // transition the color back to clear;
    }


    public void TakeDamage(int damage)
    {
        // TODO: audio

        isDamage = true;
        CameraShake.instance.Shake(damageShakeAmplitude, damageShakeAmplitude);
        currentHealth -= damage;
        healthSlider.value = currentHealth;         // set the health bar's value to the current health

        if (currentHealth <= 0)
            Death();
    }


    void Death()
    {
        //TODO: Animation or Particle
        StartCoroutine(ResetScene());
    }


    IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(changeSceneDelay);
        Application.LoadLevel(2);
    }
}   // Karol Sobanski
