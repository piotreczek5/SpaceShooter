using UnityEngine;
using System.Collections;

public class PlayerController : ObjectController {

	void fire()
	{
		Instantiate (this.weapon);
	}

	// Update is called once per frame
	public override void Update () {
		move ();
	}

	public void move()
	{

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
