using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton
    public static BuildManager instance;
    void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    public GameObject buildFx;
    public float fxLifetime = 5f;

    TurretBlueprint turretToBuild;
    Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode(Node _node)
    {
        DeselectNode();

        selectedNode = _node;

        turretToBuild = null;
        nodeUI.SetTarget(_node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint _turret)
    {
        turretToBuild = _turret;

        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
