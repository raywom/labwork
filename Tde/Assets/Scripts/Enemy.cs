using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private int Feast;

    private Transform targetPoint;

    private int pointIndex = 0;

    [SerializeField]
    private float hitPoints;

    private float hitPointsMax;

    private float hitPointsScaleMax;

    [SerializeField]
    private int killGold;

    [SerializeField]
    private Canvas hp;

    public void HitToEnemy(float damageDone)
    {
        hitPoints -= damageDone;

        var hpT = hp.GetComponentInChildren<Image>().GetComponentInChildren<Image>();

        var proc =  100 * hitPoints / hitPointsMax;

        hpT.gameObject.transform.localScale = new Vector3((hitPointsScaleMax * proc) / 100, hpT.gameObject.transform.localScale.y, hpT.gameObject.transform.localScale.z);
        
        Debug.Log(hitPoints);
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            PlayerStat.money += killGold;
        }
    }

    void Start()
    {
        hitPointsMax = hitPoints;

        hitPointsScaleMax = hp.GetComponentInChildren<Image>().GetComponentInChildren<Image>().transform.localScale.x;

        targetPoint = Points.points[0];
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        transform.LookAt(targetPoint);

        hp.transform.LookAt(CameraPoint.transformPoint);

        var distance = Vector3.Distance(transform.position, targetPoint.position);
        if (distance <= 0.4f)
        {
            GetNextPoint();
        }
    }

    private void GetNextPoint()
    {
        if (pointIndex >= Points.points.Length - 1)
        {
            Destroy(gameObject);
            PlayerStat.life -= Feast;
            return;
        }
        pointIndex++;
        targetPoint = Points.points[pointIndex];
    }
}