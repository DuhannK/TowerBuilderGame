using UnityEngine;

public class BlockController : MonoBehaviour
{
    [Header("Blok Ayarlarý")]
    // [SerializeField] komutu, deðiþkenin Unity arayüzünde (Inspector) görünmesini saðlar.
    [SerializeField] private float gridSize = 1f; // Bloðun saða/sola ne kadar kayacaðý (ýzgara boyutu)
    [SerializeField] private float fallSpeed = 2f; // Bloðun aþaðý düþme hýzý

    // Rigidbody2D'ye kod içinden ulaþmak için bir deðiþken oluþturuyoruz.
    private Rigidbody2D rb;

    void Start()
    {
        // Oyun (veya blok) baþladýðýnda, bloðun üzerindeki Rigidbody2D bileþenini bul ve 'rb' içine kaydet.
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // --- 1. SABÝT HIZLA AÞAÐI DÜÞME ---
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // --- 2. SAÐA VE SOLA KAYMA ---
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-gridSize, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(gridSize, 0, 0);
        }
    }

    // --- 3. ÇARPIÞMA (COLLISION) ALGILAMA ---
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Eðer zaten çarptýysa (kod kapalýysa) alt satýrlarý tekrar çalýþtýrma (Güvenlik önlemi)
        if (!this.enabled) return;

        this.enabled = false;

        if (rb != null)
        {
            rb.gravityScale = 1f;
        }

        // --- YENÝ EKLENEN KISIM ---
        // Sahnede 'BlockSpawner' kodunu taþýyan objeyi bul ve içindeki 'SpawnBlock' fonksiyonunu çalýþtýr.
        FindObjectOfType<BlockSpawner>().SpawnBlock();
    }
}