using UnityEngine;

public class AtomGOController : MonoBehaviour
{
    private Atom atom;

    public void SetAtom(Atom atom)
    {
        this.atom = atom;
        this.transform.position = atom.position;
        
        // Observe atom...
        atom.onChanged += OnAtomPropertiesChanged;
        
        // Add label.
       OverlayController.instance.SetTextForObject(gameObject, atom.elementName);
    }
    
    public void RemoveFromScene()
    {
        OverlayController.instance.RemoveTextForObject(gameObject);
        Destroy(gameObject);
    }

    private void OnAtomPropertiesChanged(Atom obj)
    {
        // Update label
        OverlayController.instance.SetTextForObject(gameObject, atom.elementName);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
