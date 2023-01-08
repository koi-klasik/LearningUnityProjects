using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Button upgradeCostBtn;
    public Text upgradeCostText;

    public Button sellCostBtn;
    public Text sellCostText;

    Node target;

    public void SetTarget(Node _node)
    {
        target = _node;

        transform.position = target.GetBuildPosition();

        sellCostText.text = "<b>SELL</b>\n$" + target.turretBlueprint.GetSellAmount();
        sellCostBtn.interactable = true;

        if (!_node.isUpgraded)
        {
            upgradeCostText.text = "<b>UPGRADE</b>\n$" + target.turretBlueprint.upgradeCost.ToString();
            upgradeCostBtn.interactable = true;
        }
        else
        {
            upgradeCostText.text = "<b>MAXED\nOUT</b>";
            upgradeCostBtn.interactable = false;
        }

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
