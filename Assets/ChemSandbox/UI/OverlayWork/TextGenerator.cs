using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextGenerator : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = gameObject.AddComponent<TextMeshPro>();

        textMeshPro.text = "Hello";
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
