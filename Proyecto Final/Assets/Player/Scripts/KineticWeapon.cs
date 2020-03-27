using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticWeapon : MonoBehaviour
{
    [Tooltip("Number of bullets per second")]
    public float baseAttackSpeed;
    public float attackSpeed;
    private float attackTime;
    public GameObject bulletGO;
    public Transform spawnTransform;
    public PlayerMovement player;

    void Start()
    {
        attackSpeed = baseAttackSpeed;
        attackTime = 0;
    }
    
    void Update()
    {
        UpdateAttackSpeed();

        Fire();
    }

    private void Fire()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time >= attackTime)
            {
                Quaternion rot = spawnTransform.rotation;
                Instantiate(bulletGO, spawnTransform.position, rot);
                attackTime = Time.time + 1 / attackSpeed;
            }
        }
    }

    void UpdateAttackSpeed()
    {
        attackSpeed = baseAttackSpeed + player.currentSpeed / 2;
    }
}
