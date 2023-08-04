using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public List<Proton> protons;
    public List<Neutron> neutrons;
    public List<Electron> electrons;

    private void Awake()
    {
        protons = new List<Proton>();
        neutrons = new List<Neutron>();
        electrons = new List<Electron>();
    }
}
