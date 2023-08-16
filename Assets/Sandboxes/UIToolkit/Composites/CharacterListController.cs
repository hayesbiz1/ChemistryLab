using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class CharacterListController
{
    private VisualTreeAsset ListEntryTemplate;

    private ListView CharacterList;
    private Label CharClassLabel;
    private Label CharNameLabel;
    private VisualElement CharPortrait;

    public void InitializeCharacterList(VisualElement root, VisualTreeAsset listElementTemplate)
    {
        EnumerateAllCharacters();

        ListEntryTemplate = listElementTemplate;
        CharacterList = root.Q<ListView>("character-list");

        CharClassLabel = root.Q<Label>("character-class");
        CharNameLabel = root.Q<Label>("character-name");
        CharPortrait = root.Q<VisualElement>("character-portrait");

        FillCharacterList();
        
        CharacterList.onSelectionChange += OnCharacterSelected;
    }

    private List<CharacterData> AllCharacters;
   
    private void EnumerateAllCharacters()
    {
        AllCharacters = new List<CharacterData>();
        AllCharacters.AddRange(Resources.LoadAll<CharacterData>("Characters"));
    }
    
    private void FillCharacterList()
    {
        CharacterList.makeItem = () =>
        {
            var newListEntry = ListEntryTemplate.Instantiate();
            var newListEntryLogic = new CharacterListEntryController();
            newListEntry.userData = newListEntryLogic;
            newListEntryLogic.SetVisualElement(newListEntry);

            return newListEntry;
        };

        CharacterList.bindItem = (item, index) =>
        {
            (item.userData as CharacterListEntryController).SetCharacterData(AllCharacters[index]);
        };

        CharacterList.fixedItemHeight = 45;

        CharacterList.itemsSource = AllCharacters;
    }

    void OnCharacterSelected(IEnumerable<object> selectedItems)
    {
        var selectedChar = CharacterList.selectedItem as CharacterData;

        if (selectedChar == null)
        {
            CharClassLabel.text = "";
            CharNameLabel.text = "";
            return;
        }

        CharClassLabel.text = selectedChar.Class.ToString();
        CharNameLabel.text = selectedChar.CharacterName;
    }

   
}
