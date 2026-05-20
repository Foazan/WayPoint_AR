using UnityEngine;
using Vuforia;

public class MarkerNavigation : MonoBehaviour
{
    [Header("Komponen")]
    public ObserverBehaviour observerBehaviour;

    [Header("Status (Hanya Info)")]
    public bool sedangDilihat = false;

    [Header("Objek Rute")]
    // Masukkan objek panah yang sesuai dengan marker ini di Inspector
    public GameObject rutePanah;

    void Start()
    {
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        // Mati di awal
        if (rutePanah != null) rutePanah.SetActive(false);
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        // Hanya nyalakan rute jika target benar-benar sedang dilacak langsung atau menggunakan pose device aktif
        if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            sedangDilihat = true;
            if (rutePanah != null) rutePanah.SetActive(true);
        }
        else // Jika LIMITED atau NO_POSE (hilang dari pandangan dan memori spasial melemah)
        {
            sedangDilihat = false;
            if (rutePanah != null) rutePanah.SetActive(false);
        }
    }
}