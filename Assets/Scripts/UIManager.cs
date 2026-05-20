using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [Header("Panel UI")]
    public GameObject panelBeranda;
    public GameObject panelHUD_AR;

    [Header("Kamera AR")]
    public GameObject arCamera;

    [Header("Komponen Teks HUD")]
    public TMP_Text teskTujuan;

    [Header("Sistem Pencarian")]
    public TMP_InputField inputPencarian;
    public TMP_Text teksPeringatan;

    public List<string> daftarRuanganValid = new List<string>();
    void Start()
    {
        if (panelBeranda != null) panelBeranda.SetActive(true);
        if (panelHUD_AR != null) panelHUD_AR.SetActive(false);
        if (arCamera != null) arCamera.SetActive(false);
        if (teksPeringatan != null) teksPeringatan.gameObject.SetActive(false);
    }

    public void PilihTujuan(string namaRuangan)
    {
        // Saat masuk mode navigasi AR:
        if (panelBeranda != null) panelBeranda.SetActive(false);
        if (panelHUD_AR != null) panelHUD_AR.SetActive(true);
        if (arCamera != null) arCamera.SetActive(true);
        if (teksPeringatan != null) teksPeringatan.gameObject.SetActive(false);

        if (teskTujuan != null)
        {
            teskTujuan.text = "Tujuan " + namaRuangan;
        }
    }

    public void CariRuangan()
    {
        if (inputPencarian != null && !string.IsNullOrWhiteSpace(inputPencarian.text))
        {
            string tujuanCari = inputPencarian.text.Trim();
            bool ruanganDitemukan = false;

            foreach (string ruang in daftarRuanganValid)
            {
                if (ruang.Equals(tujuanCari, System.StringComparison.OrdinalIgnoreCase))
                {
                    ruanganDitemukan = true;
                    tujuanCari = ruang;
                    break;
                }
            }

            if (ruanganDitemukan)
            {
                PilihTujuan(tujuanCari);
                inputPencarian.text = "";
            }
            else
            {
                if (teksPeringatan != null)
                {
                    teksPeringatan.text = "Ruangan tidak ditemukan";
                    teksPeringatan.gameObject.SetActive(true);
                }
            }

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