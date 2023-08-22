using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset atomListEntryTemplate;

    private VisualElement rootVisualElement;

    private Button buttonAddProton;
    private Button buttonRemoveProton;
    private Button buttonAddNeutron;
    private Button buttonRemoveNeutron;

    private void OnEnable()
    {
        rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        var atomListViewController = new AtomListViewController();
        atomListViewController.InitializeCharacterList(rootVisualElement, atomListEntryTemplate);

        // BindButton("AddProton", out buttonAddProton, OnAddProtonClicked);
        // BindButton("AddNeutron", out buttonAddNeutron, OnAddNeutronClicked);
    }

    private void BindButton(string buttonName, out Button buttonToAssign, Action buttonClickedAction)
    {
        buttonToAssign = rootVisualElement.Q<Button>(buttonName);
        buttonToAssign.clicked += buttonClickedAction;
    }

    private void OnAddProtonClicked()
    {
        buttonAddNeutron.SetEnabled(false);
    }

    private void OnAddNeutronClicked()
    {
        // buttonAddNeutron.SetEnabled(false);
    }
}