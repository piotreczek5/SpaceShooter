using UnityEngine;
using System.Collections;

public class EnemyController : ShipController {

	//public 
	public float minOffsetZ = -0.4f, maxOffsetZ = -0.6f;
	private Vector3 offset;

	public int priceForKilling;
	public int damage;

	// Use this for initialization
	void Start () {
		offset = new Vector3(0, 0, Random.Range(minOffsetZ, maxOffsetZ));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		DeathCheck ();
		AttemptMove ();

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Weapon") {
			maxHealth -= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().weapon.GetComponent<Weapon>().damage;
		}

	}
	protected override void AttemptMove()
	{
		transform.position += offset * Time.deltaTime;
	}

	void DeathCheck()
	{
		if(maxHealth < 0){
			GameMaster.instance.IncreaseScore(this.priceForKilling);
			Destroy(base.gameObject);
		}
	}

}
