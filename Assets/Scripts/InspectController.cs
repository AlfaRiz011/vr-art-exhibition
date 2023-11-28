using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectController : MonoBehaviour
{
    [SerializeField] private GameObject objectNameBg;
    [SerializeField] private Text objectNameUI;
     
    [SerializeField] private float onScreenTimer;
    [SerializeField] private Text extraInfoUI;
    [SerializeField] private GameObject extraInfoBg;
    [SerializeField] private bool startTimer;
    private float timer;

    private void Start()
    {
        objectNameBg.SetActive(false);
        extraInfoBg.SetActive(false);
    }

    private void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                timer = 0;
                ClearAdditionalInfo();
                startTimer = false;
            }
        }
    }

    public void ShowName(string objName)
    {
        objectNameBg.SetActive(true);
        objectNameUI.text = objName;
    }

    public void HideName()
    {
        objectNameBg.SetActive(false);
        objectNameUI.text = "";
    }
     
    public void ShowAdditionalInfo(string newInfo)
    {
        timer = onScreenTimer;
        startTimer = true;
        extraInfoBg.SetActive(true);
        extraInfoUI.text = newInfo;
    }

    void ClearAdditionalInfo()
    {
        extraInfoBg.SetActive(false);
        extraInfoUI.text = "";
    }
}


