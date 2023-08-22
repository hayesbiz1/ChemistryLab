using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OverlayController : MonoBehaviour
{
    public Canvas canvas;
    private GameObject panel;
    
    public GameObject testCube;

    public GameObject textGO;

    private GameObject textGO1;
    
    // Start is called before the first frame update
    void Start()
    {
        panel = canvas.transform.GetChild(0).gameObject;
        AddTextObjectToCanvas();
    }

    private void AddTextObjectToCanvas()
    {
        textGO1 = new GameObject();
        var textMeshPro = textGO1.AddComponent<TextMeshProUGUI>();
        textMeshPro.alignment = TextAlignmentOptions.BottomLeft;
        textMeshPro.text = "Hello";
        textGO1.transform.SetParent(panel.transform);

        textMeshPro.color = Color.green;
        var rectTranform = textGO1.GetComponent<RectTransform>();
        rectTranform.pivot = new Vector2(0, 0);

    }


    // Update is called once per frame
    void Update()
    {
        var screenPoint = Camera.main.WorldToScreenPoint(testCube.transform.position);
        // UpdateTextGO(textGO, screenPoint);
        UpdateTextGO(textGO1, screenPoint);
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
