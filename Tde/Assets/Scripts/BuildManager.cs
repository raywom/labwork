using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField]
    private NodeUi nodeUi;

    public static BuildManager instance;

    private TurretPriceList turretToBuild;

    private Node selectedNode;    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("!3");
            return;
        }
        instance = this;
    }

    public TurretPriceList GetTurretToBuild()
    {
        return turretToBuild;
    }   

    public void SetTurretToBuild(TurretPriceList turret)
    {
        turretToBuild = turret;
        nodeUi.Hide();
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DiselectNode();
            return;
        }

        selectedNode = node;

        turretToBuild = null;

        nodeUi.SetTarget(node);
    }

    public void DiselectNode()
    {
        selectedNode = null;
        nodeUi.Hide();
    }
}
