using UnityEngine;
using System.Collections;

public abstract class ObjectController : MonoBehaviour {
	
	public GameObject gameObject;
	public float life;
	public float armour;
	public Weapon weapon;
	public float speed;

	// Use this for initialization
	public abstract void decreaseLife(float amount);
	public abstract void decreaseArmour(float amount);
	public abstract void Update () ; //moving will be implemented in inheriting classes
}
