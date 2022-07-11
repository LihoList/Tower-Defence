
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; //making a build manager visible to make references from other scripts

    [HideInInspector] public TurretBlueprint turretToBuild;
    Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild {get { return turretToBuild != null; } }
    public bool HasMoney {get { return PlayerStats.money >= turretToBuild.cost; } }


    public GameObject buildEffect;
    public GameObject sellEffect;
            

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Must have a single build manager in a scene");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        turretToBuild = null;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }


}
