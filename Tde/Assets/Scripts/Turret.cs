using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Shooting settings")]

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private float fireRate;

    private float fireCountdown = 0;

    [SerializeField]
    private float radius;

    [SerializeField]
    private Transform partToRotate;

    [SerializeField]
    private float speed;

    private Transform target;

    private List<Transform> enemise = new List<Transform>();

    private void Start()
    {
        InvokeRepeating("CheckTarget", 0f, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Enemy")
        {
            enemise.Add(other.transform);
            Debug.Log(enemise.Count);

            if (target == null)
            {
                target = enemise[0];
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (enemise.Count > 0)
            {
                enemise.RemoveAt(0);
                Debug.Log(enemise.Count);
            }
        }
    }

    private void CheckTarget()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        for (int i = 0; i < enemies.Length; i++)
        {
            var enemy = enemies[i];
            var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= radius)
        {
            target = nearestEnemy.transform;
        }
        else
            target = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Update()
    {
        if (target == null)
            return;

        Rotate();

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.Seek(target);
    }

    private void Rotate()
    {
        var direction = target.position - transform.position;
        Quaternion lookRotatino = Quaternion.LookRotation(direction);
        var rotation = Quaternion.Lerp(partToRotate.rotation, lookRotatino, Time.deltaTime * speed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}