using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float damage;

    public void Seek(Transform target)
    {
        this.target = target;
    }
    
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        var distance = Vector3.Distance(transform.position, target.position);
        if (distance <= 1f)
        {
            HitTarget();
            return;
        }
    }

    private void HitTarget()
    {
        Destroy(gameObject);
        target.gameObject.GetComponent<Enemy>().HitToEnemy(damage);  
    }
}
