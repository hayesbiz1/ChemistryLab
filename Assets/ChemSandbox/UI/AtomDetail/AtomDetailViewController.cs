using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AtomDetailViewController
{
    private readonly Label elementNameLabel;
    
    public AtomDetailViewController(VisualElement root)
    {
        elementNameLabel = root.Q<Label>("elementName");
    }
    
    public void SetAtom(Atom atom)
    {
        elementNameLabel.text = atom.elementName;
    }
}
