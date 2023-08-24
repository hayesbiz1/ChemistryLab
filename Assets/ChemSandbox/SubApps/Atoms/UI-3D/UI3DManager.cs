using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI3DManager : MonoBehaviour
{
    AtomManager atomManager => AtomManager.instance;

    private Dictionary<Atom, AtomGOController> atomDictionary;
    
    // Start is called before the first frame update
    void Start()
    {
        atomDictionary = new Dictionary<Atom, AtomGOController>();
        
        atomManager.onAtomAdded += OnAtomAdded;
        atomManager.onAtomRemoved += OnAtomRemoved;

    }

    private void OnAtomAdded(Atom atom)
    {
        atom.onChanged += OnAtomPropertiesChanged;
        AddAtomGO(atom);
    }

    private void AddAtomGO(Atom atom)
    {
        var prefab = Resources.Load("AtomComposite");
        var atomGO = Instantiate(prefab);
        var ctrl = atomGO.GetComponent<AtomGOController>();
        ctrl.SetAtom(atom);
        
        // Add atomGO to atom->atomGO dictionary.
        atomDictionary[atom] = ctrl;
    }

    private void OnAtomRemoved(Atom atom)
    {
        atom.onChanged -= OnAtomPropertiesChanged;
        
        // Tell AtomGOController to destroy itself.
        var ctrl = atomDictionary[atom];
        ctrl.RemoveFromScene();
        
        atomDictionary.Remove(atom);
    }
    
    
    private void OnAtomPropertiesChanged(Atom atom)
    {
        
    }

    
}
