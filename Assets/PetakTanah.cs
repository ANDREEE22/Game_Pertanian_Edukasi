using UnityEngine;
using UnityEngine.InputSystem; 

public class PetakTanah : MonoBehaviour
{
    [Header("Status Tanaman")]
    public bool isDitanami = false;
    public int fasePertumbuhan = 0; 
    public string jenisTanamanSaatIni = ""; 

    [Header("Visual Banyak Tanaman (Multi-Sprites Anak)")]
    private SpriteRenderer[] kumpulanVisualAnak; 

    public Sprite[] kumpulanSpriteTomat;  
    public Sprite[] kumpulanSpriteWortel; 
    public Sprite[] kumpulanSpriteJagung;  
    public Sprite[] kumpulanSpriteGandum;  

    private PlayerInventory inventoryPlayer;
    private bool playerSedangDekat = false;

    private void Start()
    {
        inventoryPlayer = Object.FindAnyObjectByType<PlayerInventory>();
        
        // MENGUNCI OBJEK ANAK: Ambil semua SpriteRenderer yang ada di bawah objek ini
        SpriteRenderer komponenInduk = GetComponent<SpriteRenderer>();
        SpriteRenderer[] semuaRenderer = GetComponentsInChildren<SpriteRenderer>();
        
        int jumlahAnak = semuaRenderer.Length;
        if (komponenInduk != null) jumlahAnak--;

        kumpulanVisualAnak = new SpriteRenderer[jumlahAnak];
        int index = 0;

        foreach (SpriteRenderer sr in semuaRenderer)
        {
            // Filter: Jika ini adalah SpriteRenderer milik tanah utama/induk, lewati!
            if (sr == komponenInduk) continue; 

            kumpulanVisualAnak[index] = sr;
            index++;
        }
        
        UpdateVisualGambarTanaman();
    }

    private void Update()
    {
        if (playerSedangDekat && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!isDitanami)
            {
                EksekusiMenanam();
            }
            else if (isDitanami && fasePertumbuhan == 6)
            {
                PanenTanaman();
            }
            else
            {
                TumbuhLanjut(); 
            }
        }
    }

    void EksekusiMenanam()
    {
        if (inventoryPlayer == null) return;

        string bibitDipilih = LahanPertanian.bibitYangDipilih;

        if (string.IsNullOrEmpty(bibitDipilih))
        {
            Debug.LogWarning("Kamu belum memilih bibit dari menu! Masuk area pagar lalu tekan SPACE dulu.");
            return;
        }

        bool punyaBibit = false;

        if (bibitDipilih == "Tomat" && inventoryPlayer.jumlahBibitTomat > 0) punyaBibit = true;
        else if (bibitDipilih == "Wortel" && inventoryPlayer.jumlahBibitWortel > 0) punyaBibit = true;
        else if (bibitDipilih == "Jagung" && inventoryPlayer.jumlahBibitJagung > 0) punyaBibit = true;
        else if (bibitDipilih == "Gandum" && inventoryPlayer.jumlahBibitGandum > 0) punyaBibit = true;

        if (punyaBibit)
        {
            if (bibitDipilih == "Tomat") inventoryPlayer.jumlahBibitTomat--;
            else if (bibitDipilih == "Wortel") inventoryPlayer.jumlahBibitWortel--;
            else if (bibitDipilih == "Jagung") inventoryPlayer.jumlahBibitJagung--;
            else if (bibitDipilih == "Gandum") inventoryPlayer.jumlahBibitGandum--;

            isDitanami = true;
            fasePertumbuhan = 1; 
            jenisTanamanSaatIni = bibitDipilih;

            Debug.Log("Berhasil menanam " + jenisTanamanSaatIni + "!");
            
            UpdateVisualGambarTanaman();
            inventoryPlayer.UpdateTampilanStokBibit();
            LahanPertanian.bibitYangDipilih = ""; 
        }
    }

    void TumbuhLanjut()
    {
        fasePertumbuhan++;
        UpdateVisualGambarTanaman();
    }

    void PanenTanaman()
    {
        if (inventoryPlayer == null) return;

        int hadiahKoin = 0;
        if (jenisTanamanSaatIni == "Tomat") hadiahKoin = 40;
        else if (jenisTanamanSaatIni == "Wortel") hadiahKoin = 60;
        else if (jenisTanamanSaatIni == "Jagung") hadiahKoin = 80;
        else if (jenisTanamanSaatIni == "Gandum") hadiahKoin = 100;

        inventoryPlayer.TambahKoin(hadiahKoin);

        isDitanami = false;
        fasePertumbuhan = 0;
        jenisTanamanSaatIni = "";

        UpdateVisualGambarTanaman();
    }

    // Mengubah sprite pada masing-masing objek anak secara mendetail
    void UpdateVisualGambarTanaman()
    {
        if (kumpulanVisualAnak == null || kumpulanVisualAnak.Length == 0) return;

        Sprite[] spriteDipilih = null;
        if (jenisTanamanSaatIni == "Tomat") spriteDipilih = kumpulanSpriteTomat;
        else if (jenisTanamanSaatIni == "Wortel") spriteDipilih = kumpulanSpriteWortel;
        else if (jenisTanamanSaatIni == "Jagung") spriteDipilih = kumpulanSpriteJagung;
        else if (jenisTanamanSaatIni == "Gandum") spriteDipilih = kumpulanSpriteGandum;

        foreach (SpriteRenderer sr in kumpulanVisualAnak)
        {
            if (sr == null) continue;

            if (!isDitanami || fasePertumbuhan == 0)
            {
                sr.sprite = null;
                continue;
            }

            if (spriteDipilih != null && spriteDipilih.Length >= 6)
            {
                sr.sprite = spriteDipilih[fasePertumbuhan - 1];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerSedangDekat = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerSedangDekat = false;
    }
}