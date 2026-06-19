using UnityEngine;

public class TransaksiToko : MonoBehaviour
{
    private PlayerInventory inventoryPlayer;

    private void Start()
    {
        inventoryPlayer = Object.FindAnyObjectByType<PlayerInventory>();
    }

    // 1. Fungsi Beli Tomat
    public void BeliBibitTomat()
    {
        if (inventoryPlayer != null)
        {
            if (inventoryPlayer.koin >= 20)
            {
                inventoryPlayer.koin -= 20;
                inventoryPlayer.jumlahBibitTomat += 1;
                
                inventoryPlayer.UpdateTampilanKoin();
                inventoryPlayer.UpdateTampilanStokBibit();
                
                Debug.Log("Berhasil membeli 1 Bibit Tomat! Sisa Koin: " + inventoryPlayer.koin);
            }
            else
            {
                Debug.LogWarning("Koin tidak cukup untuk membeli bibit tomat!");
            }
        }
    }

    // 2. Fungsi Beli Wortel
    public void BeliBibitWortel()
    {
        if (inventoryPlayer != null)
        {
            if (inventoryPlayer.koin >= 30)
            {
                inventoryPlayer.koin -= 30;
                inventoryPlayer.jumlahBibitWortel += 1;
                
                inventoryPlayer.UpdateTampilanKoin();
                inventoryPlayer.UpdateTampilanStokBibit();
                
                Debug.Log("Berhasil membeli 1 Bibit Wortel! Sisa Koin: " + inventoryPlayer.koin);
            }
            else
            {
                Debug.LogWarning("Koin tidak cukup untuk membeli bibit wortel!");
            }
        }
    }

    // 3. Fungsi Beli Jagung
    public void BeliBibitJagung()
    {
        if (inventoryPlayer != null)
        {
            if (inventoryPlayer.koin >= 45)
            {
                inventoryPlayer.koin -= 45;
                inventoryPlayer.jumlahBibitJagung += 1;
                
                inventoryPlayer.UpdateTampilanKoin();
                inventoryPlayer.UpdateTampilanStokBibit();
                
                Debug.Log("Berhasil membeli 1 Bibit Jagung! Sisa Koin: " + inventoryPlayer.koin);
            }
            else
            {
                Debug.LogWarning("Koin tidak cukup untuk membeli bibit jagung!");
            }
        }
    }

    // 4. Fungsi Beli Gandum
    public void BeliBibitGandum()
    {
        if (inventoryPlayer != null)
        {
            if (inventoryPlayer.koin >= 60)
            {
                inventoryPlayer.koin -= 60;
                inventoryPlayer.jumlahBibitGandum += 1;
                
                inventoryPlayer.UpdateTampilanKoin();
                inventoryPlayer.UpdateTampilanStokBibit();
                
                Debug.Log("Berhasil membeli 1 Bibit Gandum! Sisa Koin: " + inventoryPlayer.koin);
            }
            else
            {
                Debug.LogWarning("Koin tidak cukup untuk membeli bibit gandum!");
            }
        }
    }
}