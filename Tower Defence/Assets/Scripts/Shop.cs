
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManagerScript;
    public TurretBlueprint standartTurret;
    public TurretBlueprint rocketTurret;
    public TurretBlueprint laserTurret;


    private void Start()
    {
        buildManagerScript = BuildManager.instance;
    }

    public void SelectStandatrTurret() //selecting turret 1
    {
        buildManagerScript.SelectTurretToBuild(standartTurret);
    }

    public void SelectRocketTurret() //selecting rocket turret
    {
        buildManagerScript.SelectTurretToBuild(rocketTurret);
    }

    public void SelectLaserTurret() //selecting rocket turret
    {
        buildManagerScript.SelectTurretToBuild(laserTurret);
    }


}
