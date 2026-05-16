using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (arCamera != null)
        {
            // Arahkan PIVOT mendatar ke kamera, kunci sumbu Y agar tidak mendongak/menunduk
            Vector3 arahKamera = arCamera.transform.position - transform.position;
            arahKamera.y = 0;

            if (arahKamera != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(arahKamera);
            }
        }
    }
}