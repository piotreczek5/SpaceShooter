using UnityEngine;
using System.Collections;

public class EnemyController : ShipController
{

    //public 
    public float minOffsetZ = -0.4f, maxOffsetZ = -0.6f;  
    private Vector3 offset;

    public int priceForKilling;
    public int damage;


    void Start()
    {
        offset = new Vector3(0, 0, Random.Range(minOffsetZ, maxOffsetZ));
    }


    void FixedUpdate()
    {
        DeathCheck();
        AttemptMove();
    }


    public void TakeDamage(int damage)
    {
        maxHealth -= damage;
    }


    protected override void AttemptMove()
    {
        transform.position += offset * Time.deltaTime;
    }


    void DeathCheck()
    {
        if (maxHealth < 0)
        {
            GameMaster.instance.IncreaseScore(this.priceForKilling);
            Destroy(base.gameObject);
        }
    }
}
