using UnityEngine;
using System.Collections;

public class GunPickUp : MonoBehaviour {

	public GameObject gunReference;
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			other.GetComponent<PlayerController>().setWeapon(gunReference);
			Destroy(gameObject);
		}
	}
}
