using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretPriceList {
    public GameObject prefab;

    public GameObject upgradedPrefab;

    public int cost;

    public int upgradeCost;
}


public class Shop : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField]
    private Button standartTurretBtn;

    [SerializeField]
    private Button missileLauncherBtn;

    [SerializeField]
    private Button laserBtn;

    [Header("Turrets")]

    [SerializeField]
    private TurretPriceList standartTurret;

    [SerializeField]
    private TurretPriceList missileLauncher;

    [SerializeField]
    private TurretPriceList laser;

    void Start()
    {
        standartTurretBtn.onClick.AddListener(SetStandatrTurret);
        standartTurretBtn.onClick.AddListener(SetMissileLauncher);
        standartTurretBtn.onClick.AddListener(SetLaser);
    }
    
    void Update()
    {
        
    }

    private void SetMissileLauncher()
    {
        BuildManager.instance.SetTurretToBuild(missileLauncher);
    }

    private void SetStandatrTurret()
    {
        BuildManager.instance.SetTurretToBuild(standartTurret);
    }

    private void SetLaser()
    {
        BuildManager.instance.SetTurretToBuild(laser);
    }

    private void OnDestroy()
    {
        standartTurretBtn.onClick.RemoveAllListeners();
        standartTurretBtn.onClick.RemoveAllListeners();
        standartTurretBtn.onClick.RemoveAllListeners();
    }

}

