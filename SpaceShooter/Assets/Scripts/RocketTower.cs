using UnityEngine;
using System.Collections;

public class RocketTower : EnemyController
{

    private Weapon weapon;


    protected override void Start()
    {
        base.Start();
        weapon = GetComponent<Weapon>();
    }


    protected virtual void Update()
    {
        if (isShooting)
            weapon.Shot();
    }

    
    public override void TakeDamage(int damage)
    {
        maxHealth -= damage;

        if (maxHealth <= 0)
        {
            print("Zniszczony: " + gameObject.name);
            DestroyEffect();
            Destroy(gameObject.transform.parent.gameObject);                         // We need destroy all object in this case
        }
    }
}   // Karol Sobanski
