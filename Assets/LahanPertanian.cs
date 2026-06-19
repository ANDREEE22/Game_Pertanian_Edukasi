using UnityEngine;
using UnityEngine.InputSystem; // WAJIB: Menggunakan Input System baru

public class LahanPertanian : MonoBehaviour
{
    [Header("UI Menu Pilihan")]
    public GameObject menuPilihBibit; 

    private bool playerDiAreaLahan = false;
    public static string bibitYangDipilih = ""; 

    void Start()
    {
        if (menuPilihBibit != null)
        {
            menuPilihBibit.SetActive(false);
        }
    }

    void Update()
    {
        // Cek input tombol Space menggunakan New Input System
        if (playerDiAreaLahan && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (menuPilihBibit != null)
            {
                bool statusSaatIni = menuPilihBibit.activeSelf;
                menuPilihBibit.SetActive(!statusSaatIni);
                Cursor.visible = true; 
            }
        }
    }

    public void PilihTomat()
    {
        bibitYangDipilih = "Tomat";
        Debug.Log("Player memilih menanam: Tomat");
        TutupMenu();
    }

    public void PilihWortel()
    {
        bibitYangDipilih = "Wortel";
        Debug.Log("Player memilih menanam: Wortel");
        TutupMenu();
    }

    public void PilihJagung()
    {
        bibitYangDipilih = "Jagung";
        Debug.Log("Player memilih menanam: Jagung");
        TutupMenu();
    }

    public void PilihGandum()
    {
        bibitYangDipilih = "Gandum";
        Debug.Log("Player memilih menanam: Gandum");
        TutupMenu();
    }

    public void TutupMenu()
    {
        if (menuPilihBibit != null)
        {
            menuPilihBibit.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDiAreaLahan = true;
            Debug.Log("Player masuk area lahan. Tekan SPACE untuk memilih bibit.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDiAreaLahan = false;
            TutupMenu(); 
        }
    }
}