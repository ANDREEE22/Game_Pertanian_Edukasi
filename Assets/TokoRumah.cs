using UnityEngine;
using UnityEngine.InputSystem; // WAJIB ditambah di paling atas!

public class TokoRumah : MonoBehaviour
{
    [Header("Pengaturan UI Toko")]
    public GameObject panelTokoUI; 

    private bool playerDiDekatPintu = false;

    // Fungsi baru khusus untuk membaca tombol E dari Input System Baru
    void Update()
    {
        // Di Input System baru, kita bisa cek langsung apakah tombol E di keyboard sedang ditekan
        if (playerDiDekatPintu && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("Tombol E BERHASIL DITEKAN (Input System Baru)!");
            ToggleToko();
        }
    }

    public void ToggleToko()
    {
        if (panelTokoUI != null)
        {
            bool statusSekarang = panelTokoUI.activeSelf;
            panelTokoUI.SetActive(!statusSekarang);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDiDekatPintu = true;
            Debug.Log("Tekan E untuk Belanja Bibit");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDiDekatPintu = false;
            if (panelTokoUI != null) panelTokoUI.SetActive(false); 
        }
    }
}