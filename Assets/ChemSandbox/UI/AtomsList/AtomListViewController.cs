using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AtomListViewController
{
    private ListView atomListView;
    private Label elementNameLabel;

    private AtomDetailViewController atomDetailViewController;

    private VisualTreeAsset atomListEntryTemplate;

    private List<Atom> atomList;
    
    public void InitializeCharacterList(VisualElement root, VisualTreeAsset listElementTemplate)
    {
        // EnumerateAllCharacters();

        atomListView = root.Q<ListView>("atomListView");

        atomListEntryTemplate = listElementTemplate;

        elementNameLabel = root.Q<Label>("elementName");

        CreateListOfAtoms();

        InitializeAtomListView();

        InitializeAtomDetailView(root);

        // MUST have both of these handlers or selectedIndicesChanged does not fire reliably.
        atomListView.itemsChosen += OnSelectedAtomChanged;
        atomListView.selectedIndicesChanged += OnSelectedIndicesChanged;
    }

    private void CreateListOfAtoms()
    {
        atomList = new List<Atom>();
        
        AddAtom("Hydrogen");
        AddAtom("Helium");
        AddAtom("Lithium");
        AddAtom("Beryllium");
    }

    private void AddAtom(string elementName)
    {
        var atom = new Atom();
        atom.elementName = elementName;
        atomList.Add(atom);
    }

    private void InitializeAtomListView()
    {
        atomListView.makeItem = () =>
        {
            var newListEntry = atomListEntryTemplate.Instantiate();
            var newEntryController = new AtomListEntryViewController();
            newListEntry.userData = newEntryController;
            newEntryController.SetVisualElement(newListEntry);

            return newListEntry;
        };

        atomListView.bindItem = (item, index) =>
        {
            (item.userData as AtomListEntryViewController).SetAtom(atomList[index]);
        };

        atomListView.fixedItemHeight = 22;
        
        atomListView.itemsSource = atomList;
    }

    private void OnSelectedAtomChanged(IEnumerable<object> obj)
    {

    }
    
    private void OnSelectedIndicesChanged(IEnumerable<int> obj)
    {

        // Set selectedAtom into AtomDetailViewController.
        var selectedAtom = atomListView.selectedItem as Atom;
        atomDetailViewController.SetAtom(selectedAtom);
    }
    
    
    private void InitializeAtomDetailView(VisualElement root)
    {
        atomDetailViewController = new AtomDetailViewController(root);
    }
    

    // private void OnSelectedAtomChanged(IEnumerable<object> obj)
    // {
    //     var selectedAtom = atomListView.selectedItem as Atom;
    //     Debug.Log(selectedAtom.elementName);
    // }
}