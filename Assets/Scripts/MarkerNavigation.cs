using UnityEngine;
using Vuforia;

public class MarkerNavigation : MonoBehaviour
{
    [Header("Komponen Vuforia")]
    public ObserverBehaviour observerBehaviour;

    [Header("Variabel State (Tujuan Saat Ini)")]
    // Di aplikasi utuh, variabel ini diubah dari tombol UI Beranda.
    // Untuk tes ini, kita bisa ubah manual dari Inspector.
    public string tujuanSaatIni = "Ruang 3.7";

    [Header("Objek Rute (Child Marker)")]
    public GameObject ruteKeRuang37;
    public GameObject ruteKeLobi;

    void Start()
    {
        // Hubungkan fungsi pendeteksi saat target ditemukan/hilang
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        // Jika kamera berhasil mendeteksi dan mengunci marker
        if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            TampilkanRuteSesuaiTujuan();
        }
        else
        {
            // Jika marker keluar dari jangkauan kamera, sembunyikan semua
            SembunyikanSemuaRute();
        }
    }

    private void TampilkanRuteSesuaiTujuan()
    {
        SembunyikanSemuaRute(); // Pastikan bersih dulu

        if (tujuanSaatIni == "Ruang 3.7" && ruteKeRuang37 != null)
        {
            ruteKeRuang37.SetActive(true);
        }
        else if (tujuanSaatIni == "Lobi" && ruteKeLobi != null)
        {
            ruteKeLobi.SetActive(true);
        }
    }

    private void SembunyikanSemuaRute()
    {
        if (ruteKeRuang37 != null) ruteKeRuang37.SetActive(false);
        if (ruteKeLobi != null) ruteKeLobi.SetActive(false);
    }
}