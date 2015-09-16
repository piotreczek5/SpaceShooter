using UnityEngine;
using System.Collections;

public class PlayerController : ObjectController {



	void fire()
	{
		Instantiate (this.weapon);
	}

	// Update is called once per frame
	public override void FixedUpdate () {
		move ();
	}

	void OnTriggerEnter(Collider other) {

		if(other.tag == "Enemy")
		{
			Destroy(other.gameObject);
		Destroy (this);
		StartCoroutine(Example());
		Application.LoadLevel (2);
		}
	}

	IEnumerator Example() {

		yield return new WaitForSeconds(2);
	}

	public void move()
	{
		float moveHor = Input.GetAxis ("Horizontal");
		float moveVer = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHor, 0.0f, moveVer);
		this.gameObject.velocity = movement * speed;
	}

	public override void decreaseLife(float amount)
	{
		this.life -= amount;
	}
	public override void decreaseArmour(float amount)
	{
		this.armour -= amount;
	}
}
