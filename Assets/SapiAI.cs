using UnityEngine;
using System.Collections;

public class SapiAI : MonoBehaviour
{
    public float kecepatanJalan = 1f;
    public float radiusKandang = 2.5f; 
    public float waktuTungguMin = 3f;  
    public float waktuTungguMax = 6f;  

    private Vector2 posisiAwal;
    private Vector2 posisiTujuan;
    private bool sedangJalan = false;
    
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        posisiAwal = transform.position; 
        StartCoroutine(RutinitasSapi());
    }

    IEnumerator RutinitasSapi()
    {
        while (true)
        {
            // 1. KONDISI DIAM (FIX: Menghentikan gerak kaki saat delay)
            float waktuTunggu = Random.Range(waktuTungguMin, waktuTungguMax);
            sedangJalan = false;
            
            anim.SetBool("isWalking", false);
            // Tetap set posisi hadap depan (0, -1) agar saat membeku posisinya natural
            anim.SetFloat("X", 0f); 
            anim.SetFloat("Y", -1f); 
            anim.speed = 0f; // << Membekukan timeline animasi (Pause)

            yield return new WaitForSeconds(waktuTunggu);

            // 2. MENCARI TUJUAN BARU
            Vector2 arahAcak = Random.insideUnitCircle * radiusKandang;
            posisiTujuan = posisiAwal + arahAcak;
            sedangJalan = true;
            
            anim.SetBool("isWalking", true);
            anim.speed = 1f; // << Menjalankan kembali animasi (Play)

            // 3. BERJALAN MENUJU TUJUAN
            while (sedangJalan && Vector2.Distance(transform.position, posisiTujuan) > 0.1f)
            {
                Vector2 posisiBaru = Vector2.MoveTowards(transform.position, posisiTujuan, kecepatanJalan * Time.deltaTime);
                Vector2 arahJalan = (posisiTujuan - (Vector2)transform.position).normalized;
                
                // Atur arah animasi & FIX BUG MOONWALK (Aset asli menghadap kiri)
                if (Mathf.Abs(arahJalan.x) > Mathf.Abs(arahJalan.y))
                {
                    anim.SetFloat("X", 1f);
                    anim.SetFloat("Y", 0f);
                    
                    // Jika jalan ke kanan (arahJalan.x > 0), maka gambar di-flip agar menghadap kanan
                    spriteRenderer.flipX = (arahJalan.x > 0); 
                }
                else
                {
                    spriteRenderer.flipX = false; 
                    anim.SetFloat("X", 0f);
                    anim.SetFloat("Y", arahJalan.y > 0 ? 1f : -1f);
                }

                rb.MovePosition(posisiBaru);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}