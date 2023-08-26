using UnityEngine;

public abstract class AbstractOrbital
{
    public abstract string name { get; }
    
    private static int maximumelectronSlotCount = 2;

    public int filledElectronSlotCount = 0;

    private int availableElectronSlots => maximumelectronSlotCount - filledElectronSlotCount; 
    
    // public int ConsumeElectrons(int unassignedElectronCount)
    // {
    //     int remainingUnassignedElectronCount = unassignedElectronCount;
    //     
    //     while (availableElectronSlots > 0 && remainingUnassignedElectronCount > 0)
    //     {
    //         filledElectronSlotCount += 1;
    //         remainingUnassignedElectronCount -= 1;
    //     }
    //
    //     return remainingUnassignedElectronCount;
    // }

    public GameObject CreateGO()
    {
        var prefab = Resources.Load(orbitalGOPrefabName);
        var go = GameObject.Instantiate(prefab) as GameObject;

        return go;
    }
    
    public abstract string orbitalGOPrefabName { get; }

    public virtual float orbitalGOScale => 1;
    
}