using UnityEngine;
using UnityEngine.UIElements;

public class MainCharacterListView : MonoBehaviour
{
    [SerializeField]
    VisualTreeAsset ListEntryTemplate;
    
    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();

        var characterListController = new CharacterListController();
        characterListController.InitializeCharacterList(uiDocument.rootVisualElement, ListEntryTemplate);
    }
}
