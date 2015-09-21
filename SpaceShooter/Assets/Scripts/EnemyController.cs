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
		if (other.tag == "PlayerBullet") {
			int damage = other.GetComponent<DestroyByCollision>().damage*
				GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Weapon>().damageMultiplier;
			Debug.Log(FindObjectOfType<Weapon>().damageMultiplier);
			maxHealth -= damage;	
		}

	}
	protected override void AttemptMove()
	{
		transform.position += offset * Time.deltaTime;
	}

	void DeathCheck()
	{
		if(maxHealth < 1){
			GameMaster.instance.IncreaseScore(this.priceForKilling);
			Destroy(gameObject);
		}
	}

}
