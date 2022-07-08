
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManagerScript;

    public TurretBlueprint standartTurret;
    public TurretBlueprint rocketTurret;
    public TurretBlueprint laserTurret;

    Animator buttonAnimator;

    private void Start()
    {
        buildManagerScript = BuildManager.instance;
        buttonAnimator = GetComponent<Animator>();

        InvokeRepeating("CheckSelectedTurret", 0.5f, 0.5f);
    }

    public void SelectStandatrTurret() //selecting turret 1
    {
        buildManagerScript.SelectTurretToBuild(standartTurret);

        buttonAnimator.Play("BackGround1");
    }

    public void SelectRocketTurret() //selecting rocket turret
    {
        buildManagerScript.SelectTurretToBuild(rocketTurret);

        buttonAnimator.Play("BackGround2");
    }

    public void SelectLaserTurret() //selecting rocket turret
    {
        buildManagerScript.SelectTurretToBuild(laserTurret);

        buttonAnimator.Play("BackGround3");
    }

    private void CheckSelectedTurret()
    {
        if(buildManagerScript.turretToBuild == null)
        {
            buttonAnimator.Play("Default");
        }
    }

}
