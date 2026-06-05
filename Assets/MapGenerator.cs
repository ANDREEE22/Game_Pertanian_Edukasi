using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [Header("Komponen Tilemap")]
    public Tilemap tilemapKanvas;

    [Header("Pilihan Bahan Ubin")]
    public Tile tileRumput;

    [Header("Ukuran Peta Otomatis")]
    public int lebarMap = 40;
    public int panjangMap = 40;

    void Start()
    {
        GenerasiMapOtomatis();
    }

    void GenerasiMapOtomatis()
    {
        tilemapKanvas.ClearAllTiles();

        for (int x = 0; x < lebarMap; x++)
        {
            for (int y = 0; y < panjangMap; y++)
            {
                tilemapKanvas.SetTile(new Vector3Int(x, y, 0), tileRumput);
            }
        }
    }
}