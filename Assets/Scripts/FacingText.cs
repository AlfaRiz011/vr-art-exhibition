using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingText : MonoBehaviour
{
    [SerializeField] private Camera mainCam;

    void Update()
    {
        // Pastikan kamera utama telah diatur
        if (mainCam != null)
        {
            Vector3 lookAtPosition = new Vector3(mainCam.transform.position.x, transform.position.y, mainCam.transform.position.z);
            transform.LookAt(2 * transform.position - lookAtPosition);
        }
        else
        {
            // Jika kamera utama tidak ditemukan, menggunakan rotasi default
            transform.rotation = Quaternion.identity;
        }
    }
}