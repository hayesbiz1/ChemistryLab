using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomManager
{
    public Action onListChanged;
    public Action<Atom> onAtomAdded;
    public Action<Atom> onAtomRemoved;
    
    // Might put this elsewhere, like in a viewCtrl.
    private Atom _currentAtom;
    public Atom currentAtom
    {
        get => _currentAtom;
        set
        {
            _currentAtom = value;
            onCurrentAtomChanged.Invoke();
        }
    }

    public int currentAtomIndex => atoms.IndexOf(currentAtom);

    public bool hasCurrentAtom => currentAtom != null;
    
    public Action onCurrentAtomChanged; 
    
    public static AtomManager instance = new ();

    public List<Atom> atoms = new ();

    public void AddAtom(Atom atom)
    {
        atoms.Add(atom);
        onListChanged.Invoke();
        onAtomAdded.Invoke(atom);
        currentAtom = atom;
    }

    public void RemoveAtom(Atom atom)
    {
        var currentAtomIndex = atoms.IndexOf(atom);
        atoms.Remove(atom);
        
        onListChanged.Invoke();
        onAtomRemoved.Invoke(atom);
        
        
        if (atoms.Count > 0)
        {
            int indexToMakeCurrent = currentAtomIndex;
            
            if (atoms.Count <= currentAtomIndex)
            {
                indexToMakeCurrent = atoms.Count - 1; // Last atom in list
            }
            
            currentAtom = atoms[indexToMakeCurrent];
        }
    }
}
