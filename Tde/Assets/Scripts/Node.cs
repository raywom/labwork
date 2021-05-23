using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    [SerializeField]
    private Color hoverColor;

    private GameObject turretObject;

    private TurretPriceList turret;

    public TurretPriceList Turret { get { return turret; } }

    public bool IsUpgraded { get { return isUpgraded; } }

    private bool isUpgraded = false;

    private Color startColor;

    private Renderer render;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
        startColor = render.material.color;
    }

    public void UpgradeTurret()
    {
        if(PlayerStat.money < turret.upgradeCost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStat.money -= turret.upgradeCost;

        Destroy(turretObject);

        turretObject = Instantiate(turret.upgradedPrefab, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        int money = 0;

        money += turret.cost;

        if (IsUpgraded)
            money += turret.upgradeCost;

        PlayerStat.money += money / 2;

        Destroy(turretObject);

        turret = null;

        isUpgraded = false;
    }

    private void OnMouseEnter()
    {
        render.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        render.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            BuildManager.instance.SelectNode(this);
            return;
        }

        turret = BuildManager.instance.GetTurretToBuild();

        if (turret ==null)
        {
            return;
        }

        if (PlayerStat.money < turret.cost)
        {
            Debug.Log("Not enough money");
            return;
        }
        
            turretObject = Instantiate(turret.prefab, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
            PlayerStat.money -= turret.cost;
        
    }
}