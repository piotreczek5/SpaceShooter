using UnityEngine;
using System.Collections;

public abstract class ObjectController : MonoBehaviour {
	
	public Rigidbody gameObject;
	public float life;
	public float armour;
	public Weapon weapon;
	public float speed;

	// Use this for initialization
	public abstract void decreaseLife(float amount);
	public abstract void decreaseArmour(float amount);
	public abstract void FixedUpdate () ; //moving will be implemented in inheriting classes
}
