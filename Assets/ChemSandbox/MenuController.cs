using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddProton()
    {
        var prefab = Resources.Load("ProtonPrefab");
        var newProton = GameObject.Instantiate(prefab) as GameObject;
        newProton.transform.parent = App.Instance.currentAtomGO.transform;
        // App.Instance.currentAtom.protons.Add(newProton.GetComponent<Proton>());
    }
}
