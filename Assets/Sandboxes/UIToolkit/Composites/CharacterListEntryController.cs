using UnityEngine.UIElements;

public class CharacterListEntryController
{
    private Label NameLabel;

    public void SetVisualElement(VisualElement visualElement)
    {
        NameLabel = visualElement.Q<Label>("character-name");
    }

    public void SetCharacterData(CharacterData characterData)
    {
        NameLabel.text = characterData.CharacterName;
    }
    
}
