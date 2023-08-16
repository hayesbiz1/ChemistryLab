using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

public class InventorySlot : VisualElement
{
    public Image Icon;
    public string ItemGuid = "";

    public InventorySlot()
    {
        Icon = new Image();
        Add(Icon);
        
        Icon.AddToClassList("slotIcon");
        
        AddToClassList("slotContainer");
    }
    
    #region UXML

    [Preserve]
    public new class UxmlFactory : UxmlFactory<InventorySlot, UxmlTraits>
    {
    }

    [Preserve]
    public new class UxmlTraits : VisualElement.UxmlTraits
    {
    }

    #endregion
}
