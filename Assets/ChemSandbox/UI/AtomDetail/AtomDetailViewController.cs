using UnityEngine.UIElements;

public class AtomDetailViewController
{
    private readonly Label elementNameLabel;
    private readonly VisualElement container;

    private Atom selectedAtom; // Used within this UI.

    private Atom currentAtom => AtomManager.instance.currentAtom;
    
    public AtomDetailViewController(VisualElement root)
    {
        container = root.Q<VisualElement>("atomDetailContainer");
        elementNameLabel = root.Q<Label>("elementName");

        var addProtonButton = root.Q<Button>("AddProton");
        addProtonButton.clicked += OnAddProtonClicked;
        
        var removeProtonButton = root.Q<Button>("RemoveProton");
        removeProtonButton.clicked += OnRemoveProtonClicked;

        container.visible = false;

        AtomManager.instance.onCurrentAtomChanged += OnDifferentAtomSelected;
    }

    private void OnAddProtonClicked()
    {
        currentAtom.protonCount += 1;
    }

    private void OnRemoveProtonClicked()
    {
        currentAtom.protonCount -= 1;
    }

    private void OnDifferentAtomSelected()
    {
        SetSelectedAtom(AtomManager.instance.currentAtom);
    }

    public void SetSelectedAtom(Atom atom)
    {
        if (selectedAtom != null)
        {
            selectedAtom.onChanged -= OnAtomPropertiesChanged;
        }

        selectedAtom = atom;
        selectedAtom.onChanged += OnAtomPropertiesChanged;

        container.visible = true;
        
        RefreshAtomUIFields();
    }

    void RefreshAtomUIFields()
    {
        elementNameLabel.text = selectedAtom.elementName;
    } 

    private void OnAtomPropertiesChanged(Atom atom)
    {
        RefreshAtomUIFields();
    }
}
