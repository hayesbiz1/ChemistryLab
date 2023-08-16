using System.Collections.Generic;
using UnityEngine;

public class Atom 
{
    public string elementName;
    
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
