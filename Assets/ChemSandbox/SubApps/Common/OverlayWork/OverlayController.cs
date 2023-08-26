using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class OverlayController : MonoBehaviour
{
    public static OverlayController instance;

    public GameObject textBackgroundPrefab;
    
    public Canvas canvas;
    private GameObject panel;
    
    public GameObject testCube;

    public GameObject textGO;

    private GameObject textGO1;

    private Dictionary<GameObject, GameObject> textGODictionary = new Dictionary<GameObject, GameObject>();


    private void Awake()
    {
        instance = this;
    }

    public void SetTextForObject(GameObject targetObject, string text)
    {
        if (textGODictionary.ContainsKey(targetObject))
        {
            // Update existing object.
            var textObject = textGODictionary[targetObject];
            var textMeshPro = textObject.GetComponentInChildren<TextMeshProUGUI>();
            textMeshPro.text = text;
        }
        else
        {
            // Add object.
            AddTextForObject(targetObject, text);
        }
    }
    

    private void AddTextForObject(GameObject targetObject, string text)
    {
        var backgroundGO = Instantiate(textBackgroundPrefab);
        backgroundGO.transform.SetParent(panel.transform);
        
        textGO1 = new GameObject();
        textGO1.transform.parent = backgroundGO.transform;
        
        var textMeshPro = textGO1.AddComponent<TextMeshProUGUI>();
        textMeshPro.alignment = TextAlignmentOptions.TopLeft;
        textMeshPro.text = text;
        textGO1.transform.SetParent(backgroundGO.transform);

        textMeshPro.color = Color.white;
        textMeshPro.outlineColor = Color.green;
        textMeshPro.outlineWidth = 0.1f;
        
        textMeshPro.fontSize = 12;
        
        var rectTransform = textGO1.GetComponent<RectTransform>();
        rectTransform.pivot = new Vector2(0, 0);

        textGODictionary[targetObject] = backgroundGO;
    }
    
    public void RemoveTextForObject(GameObject targetObject)
    {
        Destroy(textGODictionary[targetObject]);

        textGODictionary.Remove(targetObject);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        panel = canvas.transform.GetChild(0).gameObject;
        // AddTestTextObjectToCanvas();
    }

    // private void AddTestTextObjectToCanvas()
    // {
    //     textGO1 = new GameObject();
    //     var textMeshPro = textGO1.AddComponent<TextMeshProUGUI>();
    //     textMeshPro.alignment = TextAlignmentOptions.TopLeft;
    //     textMeshPro.text = "Hello\nGoodbye";
    //     textGO1.transform.SetParent(panel.transform);
    //
    //     textMeshPro.color = Color.green;
    //     var rectTranform = textGO1.GetComponent<RectTransform>();
    //     rectTranform.pivot = new Vector2(0, 0);
    // }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint;
        ; // = Camera.main.WorldToScreenPoint(testCube.transform.position);
        // UpdateTextGO(textGO, screenPoint);
        // UpdateTextGO(textGO1, screenPoint);

        foreach (var entry in textGODictionary)
        {
            screenPoint = Camera.main.WorldToScreenPoint(entry.Key.transform.position);
            // UpdateTextGO(textGO, screenPoint);
            UpdateTextGO(entry.Value, screenPoint);
        }
    }

    private void UpdateTextGO(GameObject txtGO, Vector3 screenPoint)
    {
        var textRectTransform = txtGO.transform as RectTransform;
        Vector2 canvasSize = (canvas.gameObject.transform as RectTransform).rect.size;
        var canvasSize2 = canvasSize / 2.0f; 
        
        //rectTransform.anchoredPosition = new(-200, -100);
        textRectTransform.anchoredPosition = new Vector2(screenPoint.x, screenPoint.y) - canvasSize2;
        
    }

}
