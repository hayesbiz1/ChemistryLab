using System.Collections.Generic;
using UnityEngine;

public class OrbitalGOController
{
    private ElectronManager electronManager;
    private GameObject atomGO;

    private List<GameObject> orbitalGOs = new List<GameObject>();
    
    public OrbitalGOController(GameObject atomGO, ElectronManager electronManager)
    {
        this.atomGO = atomGO;
        this.electronManager = electronManager;
    }

    public void RecreateOrbitalGOs()
    {
        foreach (var orbitalGO in orbitalGOs)
        {
            GameObject.Destroy(orbitalGO);
        }

        orbitalGOs = new List<GameObject>();

        foreach (var orbital in electronManager.orbitalSequentialList)
        {
            if (orbital.filledElectronSlotCount > 0)
            {
                var orbitalGO = orbital.CreateGO();
                orbitalGO.transform.SetParent(atomGO.transform);
                orbitalGO.transform.localPosition = Vector3.zero;
                orbitalGO.transform.localScale = Vector3.one * orbital.orbitalGOScale;

                orbitalGOs.Add(orbitalGO);
            }
        }
    }
}