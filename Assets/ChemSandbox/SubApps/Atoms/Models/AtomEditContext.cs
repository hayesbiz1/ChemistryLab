using UnityEngine;

public class AtomEditContext
{
    public static AtomEditContext instance = new AtomEditContext();
    
    private static Vector3 defaultAtomOffset = new Vector3(3, 0, 0);
    private Vector3 positionForAddedAtom;

    public Vector3 GetPositionForAddedAtom()
    {
        var newPosition = positionForAddedAtom;
        positionForAddedAtom += defaultAtomOffset;
        return newPosition;
    }
}
