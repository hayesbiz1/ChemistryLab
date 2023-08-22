using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AtomListViewController
{
    private ListView atomListView;
    
    private AtomDetailViewController atomDetailViewController;

    private VisualTreeAsset atomListEntryTemplate;
    
    AtomManager atomManager => AtomManager.instance;
    
    public void InitializeCharacterList(VisualElement root, VisualTreeAsset listElementTemplate)
    {
        // atomManager.onListChanged += OnAtomListChanged;
        atomManager.onCurrentAtomChanged += OnCurrentAtomChanged;

        atomManager.onAtomAdded += OnAtomAdded;
        atomManager.onAtomRemoved += OnAtomRemoved;
        
        atomListView = root.Q<ListView>("atomListView");

        var addAtomButton = root.Q<Button>("addAtomButton");
        addAtomButton.clicked += OnAddAtomButtonClicked;
        
        var removeAtomButton = root.Q<Button>("removeAtomButton");
        removeAtomButton.clicked += OnRemoveAtomButtonClicked;

        atomListEntryTemplate = listElementTemplate;

        // elementNameLabel = root.Q<Label>("elementName");

        InitializeAtomListView();

        InitializeAtomDetailView(root);

        // MUST have both of these handlers or selectedIndicesChanged does not fire reliably.
        atomListView.itemsChosen += OnItemInListChangedByUser;
        atomListView.selectedIndicesChanged += OnSelectedIndicesChangedByUser;
    }

    private void OnAtomAdded(Atom atom)
    {
        StartObservingAtom(atom);
        atomListView.RefreshItems();
    }

    private void OnAtomRemoved(Atom atom)
    {
        StopObservingAtom(atom);
        atomListView.RefreshItems();
    }
    
    void StartObservingAtom(Atom atom)
    {
        atom.onChanged += OnAtomPropertiesChanged;
    }
    
    void StopObservingAtom(Atom atom)
    {
        atom.onChanged -= OnAtomPropertiesChanged;
    }
    
    private void OnAtomPropertiesChanged(Atom changedAtom)
    {
        // Update associated UI entry in list.
        Debug.Log("atom list detected change in atom");
        var index = atomManager.atoms.IndexOf(changedAtom);
        atomListView.RefreshItem(index);

    }
  
    private void OnAddAtomButtonClicked()
    {
        var newAtom = new Atom();
        atomManager.AddAtom(newAtom);
    }
    
    private void OnRemoveAtomButtonClicked()
    {
        atomManager.RemoveAtom(atomManager.currentAtom);
    }

    private void OnAtomListChanged()
    {
        atomListView.RefreshItems();
    }

    List<Atom> atomList => AtomManager.instance.atoms;
    
    private void InitializeAtomListView()
    {
        // Do the following when the selected Item changes.
        // atomListView.RefreshItem()
        
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
        
        atomListView.itemsSource = atomManager.atoms;

        foreach (var atom in atomManager.atoms)
        {
            StartObservingAtom(atom);
        }
    }

    private void OnItemInListChangedByUser(IEnumerable<object> obj)
    {
        // DO nothing.
    }
    
    // Whenever list is set, we want to observe property changes for every item in the list
    // so that corresponding entry can be updated. Whenever an item is added or removed from the list,
    // Register/unregister interest.
    // Will need model to have an event for item added and removed, INSTEAD of list changed.
    
    
    private void OnSelectedIndicesChangedByUser(IEnumerable<int> obj)
    {
        // Set current item into AtomManager.
        var selectedAtom = atomListView.selectedItem as Atom;
        atomManager.currentAtom = selectedAtom;
    }
    
    private void OnCurrentAtomChanged()
    {
        // Follows immediately after user selects an item (OnSelectedIndicesChangedByUser)
        if (atomManager.hasCurrentAtom)
        {
            var selectedList = new List<int>() {atomManager.currentAtomIndex};
            atomListView.SetSelectionWithoutNotify(selectedList);
        }
    }
    
    
    private void InitializeAtomDetailView(VisualElement root)
    {
        atomDetailViewController = new AtomDetailViewController(root);
    }
   
}