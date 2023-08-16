using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AtomListEntryViewController 
{
    private Label nameLabel;

    public void SetVisualElement(VisualElement visualElement)
    {
        nameLabel = visualElement.Q<Label>("elementName");
    }

    public void SetAtom(Atom atom)
    {
        nameLabel.text = atom.elementName;
    }
}
