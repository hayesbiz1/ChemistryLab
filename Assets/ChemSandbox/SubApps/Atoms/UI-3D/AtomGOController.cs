using UnityEngine;

public class AtomGOController : MonoBehaviour
{
    private Atom atom;

    public void SetAtom(Atom atom)
    {
        this.atom = atom;
        // Observe atom...
        atom.onChanged += OnAtomPropertiesChanged;
        
        // Add label.
       OverlayController.instance.SetTextForObject(gameObject, atom.elementName);
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
