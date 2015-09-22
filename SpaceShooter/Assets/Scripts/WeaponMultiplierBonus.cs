using UnityEngine;
using System.Collections;

public class WeaponMultiplierBonus : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Weapon>().damageMultiplier++;
			Destroy(gameObject);
		}
	}


}
