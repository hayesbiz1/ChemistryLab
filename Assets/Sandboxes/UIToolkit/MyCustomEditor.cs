using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class MyCustomEditor : EditorWindow
{
    [MenuItem("Window/UI Toolkit/MyCustomEditor")]
    public static void ShowExample()
    {
        MyCustomEditor wnd = GetWindow<MyCustomEditor>();
        wnd.titleContent = new GUIContent("MyCustomEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Sandboxes/UIToolkit/MyCustomEditor.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);
    }
}