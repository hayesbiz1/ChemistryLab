using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public static App Instance;
    
    public GameObject currentAtomGO;
    public Atom currentAtom;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        // var prefab = Resources.Load("AtomPrefab");
        // currentAtomGO = GameObject.Instantiate(prefab) as GameObject;
        // currentAtom = currentAtomGO.GetComponent<Atom>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
