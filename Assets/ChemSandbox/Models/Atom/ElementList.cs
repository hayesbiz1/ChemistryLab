using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElementsListData", menuName = "ScriptableObjects/ElementsList", order = 1)]
public class ElementList : ScriptableObject
{
    [SerializeField]
    public List<Element> elements = new List<Element>();

    public int ID;

}
