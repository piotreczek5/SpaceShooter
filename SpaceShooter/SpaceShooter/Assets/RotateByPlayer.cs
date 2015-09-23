using UnityEngine;
using System.Collections;

public class RotateByPlayer : MonoBehaviour
{
    public float rotateSpeed;
    Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        Quaternion lookRotation = Quaternion.LookRotation(transform.position, player.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotateSpeed);
    }
}
