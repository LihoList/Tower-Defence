
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    [Header("Base prefabs")]
    public GameObject prefab;
    public int cost;

    [Header("Upgraded prefabs")]
    public GameObject upgradedPrefab;
    public int upgradeCost;
    
        

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
