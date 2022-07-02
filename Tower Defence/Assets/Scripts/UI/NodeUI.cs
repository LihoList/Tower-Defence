
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject canvas;

    public TextMeshProUGUI upgradeText;
    public Button upgradeButton;

    public TextMeshProUGUI sellAmount;


    private void Start()
    {
        canvas.SetActive(false);
    }

    public void SetTarget(Node _target)
    {
        target = _target;

        

        if(!target.isUpgraded)
        {
            upgradeText.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeText.text = "Done";
            upgradeButton.interactable = false;
        }

        transform.position = target.GetBuildPosition();
        canvas.SetActive(true);

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
    }

    public void Hide()
    {
        canvas.SetActive(false);
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
