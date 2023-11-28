using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{

    [SerializeField] private string itemName;
    [SerializeField] private Texture2D imageItem;
    [TextArea][SerializeField] private string itemDesc;
    [TextArea][SerializeField] private string fullDesc;
    [SerializeField] private InspectController inspectorController;
    [SerializeField] private OpenFullDesc OpenFullDesc;

    public void ShowName()
    {
        inspectorController.ShowName(itemName);
    }
    public void HideObjectName()
    {
        inspectorController.HideName();
    }
    public void ShowItemInfo()
    {
        inspectorController.ShowAdditionalInfo(itemDesc);
    }
    public void ShowFullDesc()
    {
        OpenFullDesc.Show(itemName,fullDesc,imageItem);
    }

    public void HideFullDesc()
    {
        OpenFullDesc.Hide();
    }
}
