using System;
using System.Collections.Generic;
using UnityEngine;

public class Atom
{
    public Action<Atom> onChanged; 
    
    private int _protonCount = 1;
    public int protonCount
    {
        get { return _protonCount; }
        set
        {
            _protonCount = value; 
            onChanged.Invoke(this);
        }
    }
    public int neutronCount = 1;
    
    public List<Electron> electrons;

    public Atom()
    {
        electrons = new List<Electron>();
        electrons.Add(new Electron());
    }


    public string elementName => App.Instance.elementList.elements[protonCount - 1].name;


}
