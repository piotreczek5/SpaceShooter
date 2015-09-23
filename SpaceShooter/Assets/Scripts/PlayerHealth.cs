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
	public float deathDelay = 4;

    private Image damageImage;
    private Slider healthSlider;
    private int maxHealth;
    private int currentHealth;
    private bool isDead;
    private bool isDamage;


    void Awake()
    {
        damageImage = GameObject.Find("DamageImage").GetComponent<Image>();              // it's necessary becouse player does't exist yet
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();                 // it's necessary becouse player does't exist yet

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

		if (currentHealth < 0)
			LooseLife();
    }


	void LooseLife()
	{
		//TODO: Animation or Particle
		//Instantiate (gameObject.GetComponent<PlayerController> ().explosionObject, transform.position, transform.rotation);
		StartCoroutine(Death());
	}


	public IEnumerator Death()
	{
        		GameMaster.instance.DescreaseLifes ();
		//yield return new WaitForSeconds(4);
		if (GameMaster.instance.lifes < 1)
			GameMaster.instance.GameOver ();
		else
			GameMaster.instance.Spawn();
		yield return new WaitForSeconds(0);
		Destroy (gameObject);
        	
	}
}   // Karol Sobanski
