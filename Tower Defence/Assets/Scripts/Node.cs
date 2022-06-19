
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("Node color settings")]
    Renderer rend;
    Color startColor;
    public Color hoverColor;
    public Color NotEnoughMoneyColor;

    public Vector3 turretOffset;

    
    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;

    BuildManager buildManagerScript;

   


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManagerScript = BuildManager.instance;
    }

  


    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManagerScript.SelectNode(this);

            return;
        }

        if (!buildManagerScript.CanBuild)
            return;

        BuildTurret(buildManagerScript.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Not enough money");
            return;
        }
        PlayerStats.money -= blueprint.cost;
        turretBlueprint = blueprint;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject buildParticleEffect = (GameObject)Instantiate(buildManagerScript.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildParticleEffect, 2);

        Debug.Log("Turret built! Money left - " + PlayerStats.money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to Upgrade");
            return;
        }
        PlayerStats.money -= turretBlueprint.upgradeCost;

        //removing the old one
        Destroy(turret);
         
        //building a new one
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject buildParticleEffect = (GameObject)Instantiate(buildManagerScript.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildParticleEffect, 2);

        isUpgraded = true;

        Debug.Log("Turret built! Money left - " + PlayerStats.money);
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount();
        Destroy(turret);

        GameObject buildParticleEffect = (GameObject)Instantiate(buildManagerScript.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildParticleEffect, 2);

        turretBlueprint = null;

        isUpgraded = false;
    }

    private void OnMouseEnter()
    {
        if (!buildManagerScript.CanBuild)
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if(buildManagerScript.HasMoney)
        {
            rend.material.color = hoverColor;
        } 
        else
        {
            rend.material.color = NotEnoughMoneyColor;
        }
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + turretOffset;
    }

}
