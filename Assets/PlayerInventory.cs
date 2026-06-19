using UnityEngine;
using TMPro; // Wajib untuk TextMesh Pro

public class PlayerInventory : MonoBehaviour
{
    [Header("Ekonomi Player")]
    public int koin = 100;

    [Header("Stok Bibit")]
    public int jumlahBibitTomat = 0;
    public int jumlahBibitWortel = 0;
    public int jumlahBibitJagung = 0; 
    public int jumlahBibitGandum = 0; 

    [Header("Tampilan UI Ekonomi")]
    public TextMeshProUGUI UI_TeksKoin; 

    [Header("Tampilan UI Stok Bibit")]
    public TextMeshProUGUI UI_TeksTomat;   // Tarik objek TeksStokTomat ke sini nanti
    public TextMeshProUGUI UI_TeksWortel;  // Tarik objek TeksStokWortel ke sini nanti
    public TextMeshProUGUI UI_TeksJagung;  // Tarik objek TeksStokJagung ke sini nanti
    public TextMeshProUGUI UI_TeksGandum;  // Tarik objek TeksStokGandum ke sini nanti

    void Awake()
    {
        UpdateTampilanKoin();
        UpdateTampilanStokBibit();
    }

    void Start()
    {
        UpdateTampilanKoin(); 
        UpdateTampilanStokBibit();
    }

    public void UpdateTampilanKoin()
    {
        if (UI_TeksKoin != null)
        {
            UI_TeksKoin.text = "Koin: " + koin;
        }
    }

    // FUNGSI BARU: Untuk memperbarui angka stok bibit di layar game
    public void UpdateTampilanStokBibit()
    {
        if (UI_TeksTomat != null) UI_TeksTomat.text = "x" + jumlahBibitTomat;
        if (UI_TeksWortel != null) UI_TeksWortel.text = "x" + jumlahBibitWortel;
        if (UI_TeksJagung != null) UI_TeksJagung.text = "x" + jumlahBibitJagung;
        if (UI_TeksGandum != null) UI_TeksGandum.text = "x" + jumlahBibitGandum;
    }

    public void TambahKoin(int jumlah)
    {
        koin += jumlah;
        UpdateTampilanKoin(); 
        Debug.Log("Koin bertambah! Total koin sekarang: " + koin);
    }

    public bool KurangiKoin(int jumlah)
    {
        if (koin >= jumlah)
        {
            koin -= jumlah;
            UpdateTampilanKoin(); 
            Debug.Log("Koin berkurang! Sisa koin: " + koin);
            return true;
        }
        else
        {
            Debug.LogWarning("Koin tidak cukup!");
            return false;
        }
    }
}