using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectRaycast : MonoBehaviour
{
    [SerializeField] private int raycastLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    private ObjectController raycastedObj;
    [SerializeField] private Image crossHair;
    private bool isCrosshairActive;
    private bool doOnce;

    [SerializeField] private GameObject crossHairObj;
    [SerializeField] private GameObject inspectUI;
    [SerializeField] private PlayerMovement plyrMovement;
    [SerializeField] private CamLook camLook;

    private bool isUI;

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, raycastLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("InteractObject"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowName();

                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetMouseButtonDown(0))
                {
                    raycastedObj.ShowItemInfo();
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    isUI = true;
                    OpenUI();
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                raycastedObj.HideObjectName();
                CrosshairChange(false);
                doOnce = false;
            }
        }

        // Check for user input to close UI
        if (Input.GetMouseButtonDown(1) && isUI)
        {
            isUI = false;
            CloseUI();
        }
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crossHair.color = Color.red;
        }
        else
        {
            crossHair.color = Color.white;
            isCrosshairActive = false;
        }
    }

    void OpenUI()
    {
        raycastedObj.ShowFullDesc();
        crossHairObj.SetActive(false);
        inspectUI.SetActive(false);
        plyrMovement.enabled = false;
        camLook.enabled = false;
    }

    void CloseUI()
    {
        raycastedObj.HideFullDesc();
        crossHairObj.SetActive(true);
        inspectUI.SetActive(true);
        plyrMovement.enabled = true;
        camLook.enabled = true;
    }
}
