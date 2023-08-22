using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI3DManager : MonoBehaviour
{
    AtomManager atomManager => AtomManager.instance;
    
    // Start is called before the first frame update
    void Start()
    {
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
        atomGO.GetComponent<AtomGOController>().SetAtom(atom);
    }

    private void OnAtomRemoved(Atom atom)
    {
        atom.onChanged -= OnAtomPropertiesChanged;
    }
    
    
    private void OnAtomPropertiesChanged(Atom atom)
    {
        
    }

    
}
