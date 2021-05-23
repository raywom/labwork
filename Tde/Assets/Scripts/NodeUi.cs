using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUi : MonoBehaviour
{
    private Node target;

    [SerializeField]
    private Transform root;

    [SerializeField]
    private Button upgradeButton, sellButton;

    [SerializeField]
    private Text upgradedeButtonText;

    private void Start()
    {
        root.gameObject.SetActive(false);
        upgradeButton.onClick.AddListener(Upgrade);
        sellButton.onClick.AddListener(Sell);
    }

    private void Upgrade()
    {
        if (target == null)
            return;

        target.UpgradeTurret();
        BuildManager.instance.DiselectNode();
    }

    private void Sell()
    {
        if (target == null)
            return;

        target.SellTurret();
        BuildManager.instance.DiselectNode();         
    }

    public void SetTarget(Node target)
    {
        this.target = target;

        transform.position = target.transform.position + new Vector3(2, 6, 0);

        if (target.IsUpgraded == false)
        {
            upgradedeButtonText.text = "UPGRADED \n " + target.Turret.upgradeCost + "$";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false; 
            upgradedeButtonText.text = "UPGRADED";
        }

        if(target.Turret != null)
        root.gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        root.gameObject.SetActive(false);
    }
}
