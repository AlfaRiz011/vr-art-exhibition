using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenFullDesc : MonoBehaviour
{
    [SerializeField] private GameObject objectNameBg;
    [SerializeField] private Text objectNameUI;

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject panelItem;

    [SerializeField] private Text fullInfoUI;
    [SerializeField] private GameObject fullInfoBg;


    [SerializeField] private RawImage imgItem;


    private void Start()
    {
        panel.SetActive(false);
        objectNameBg.SetActive(false);
        fullInfoBg.SetActive(false);
        panelItem.SetActive(false);
    }

    public void Show(string objName, string fullDesc, Texture2D img)
    {
        panel.SetActive(true);
        objectNameBg.SetActive(true);
        fullInfoBg.SetActive(true);
        panelItem.SetActive(true);

        objectNameUI.text = objName;
        fullInfoUI.text = fullDesc;
        imgItem.texture = img;

    }

    public void Hide()
    {

        panel.SetActive(false);
        objectNameBg.SetActive(false);
        fullInfoBg.SetActive(false);
        panelItem.SetActive(false);


        objectNameUI.text = "";
        fullInfoUI.text = "";
        imgItem.texture = null; 
    }


}
