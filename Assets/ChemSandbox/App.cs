using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public static App Instance;

    public ElementList elementList; 
    
    public GameObject currentAtomGO;
    public Atom currentAtom;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        foreach (Element element in elementList.elements)
        {
            Debug.Log(element.name);
        }
        
        // var prefab = Resources.Load("AtomPrefab");
        // currentAtomGO = GameObject.Instantiate(prefab) as GameObject;
        // currentAtom = currentAtomGO.GetComponent<Atom>();

        AtomManager.instance.onListChanged += OnAtomListChanged;

    }

    private void OnAtomListChanged()
    {
        Debug.Log("Atom list changed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
