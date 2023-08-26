using UnityEngine;

public class AtomGOController : MonoBehaviour
{
    private Atom atom;

    private OrbitalGOController orbitalGOController;

    public void SetAtom(Atom atom)
    {
        this.atom = atom;
        this.transform.position = atom.position;
        
        // Observe atom...
        atom.onChanged += OnAtomPropertiesChanged;
        atom.onElectronCountChanged += OnAtomElectronCountChanged;
        
        // Add label.
       OverlayController.instance.SetTextForObject(gameObject, atom.elementName);

       orbitalGOController = new OrbitalGOController(gameObject, atom.electronManager);
       orbitalGOController.RecreateOrbitalGOs();
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
    
    private void OnAtomElectronCountChanged(Atom obj)
    {
        orbitalGOController.RecreateOrbitalGOs();
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
