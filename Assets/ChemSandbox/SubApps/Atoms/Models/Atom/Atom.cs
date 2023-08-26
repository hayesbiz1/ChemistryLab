using System;
using System.Collections.Generic;
using UnityEngine;

public class Atom
{
    public ElectronManager electronManager { get; }

    public Action<Atom> onChanged;
    
    public Action<Atom> onPositionChanged;

    public Action<Atom> onElectronCountChanged;

    private int _protonCount;
    public int protonCount
    {
        get { return _protonCount; }
        set
        {
            _protonCount = value; 
            
            // Automatically change electron count to match proton count.
            electronCount = protonCount;
            
            onChanged?.Invoke(this);
        }
    }
    
    private int _electronCount = 0;
    public int electronCount
    {
        get { return _electronCount; }
        set
        {
            _electronCount = value; 
            electronManager.SetElectronCount(electronCount);
            onChanged?.Invoke(this);
            onElectronCountChanged?.Invoke(this);
        }
    }
    
    public int neutronCount = 1;
    
    public List<Electron> electrons;

    private Vector3 _position;

    public Vector3 position
    {
        get { return _position;}
        set
        {
            _position = value;
            onPositionChanged?.Invoke(this);
        }
    }

    public Atom()
    {
        electrons = new List<Electron>();
        electrons.Add(new Electron());

        electronManager = new ElectronManager(this);

        protonCount = 1; // Default is hydrogen

    }

    public string elementName => App.Instance.elementList.elements[protonCount - 1].name;
}
