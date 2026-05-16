using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Panel UI")]
    public GameObject panelBeranda;
    public GameObject panelHUD_AR;

    [Header("Kamera AR")]
    public GameObject arCamera;

    [Header("Komponen Teks HUD")]
    public TMP_Text teskTujuan;

    void Start()
    {
        if (panelBeranda != null) panelBeranda.SetActive(true);
        if (panelHUD_AR != null) panelHUD_AR.SetActive(false);

        if (arCamera != null) arCamera.SetActive(false);
    }

    public void PilihTujuan(string namaRuangan)
    {
        // Saat masuk mode navigasi AR:
        if (panelBeranda != null) panelBeranda.SetActive(false);
        if (panelHUD_AR != null) panelHUD_AR.SetActive(true);
        if (arCamera != null) arCamera.SetActive(true);

        if (teskTujuan != null)
        {
            teskTujuan.text = "Tujuan" + namaRuangan;
        }
    }

    public void KembaliKeBeranda()
    {
        // Saat kembali ke menu utama:
        if (panelBeranda != null) panelBeranda.SetActive(true);
        if (panelHUD_AR != null) panelHUD_AR.SetActive(false);

        // Matikan kembali kamera AR
        if (arCamera != null) arCamera.SetActive(false);
    }

    public void SampaiTujuan()
    {
        if (teskTujuan != null)
        {
            teskTujuan.text = "Telah sampai ke tujuan";
        }
    }
}