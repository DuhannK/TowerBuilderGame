using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [Header("Üretim Ayarlarý")]
    [SerializeField] private GameObject blockPrefab; // Hangi kalýbý üreteceðiz?
    [SerializeField] private Vector3 spawnPosition;  // Hangi koordinattan üreteceðiz?

    void Start()
    {
        // Oyun baþladýðýnda ilk bloðu hemen sahneye çaðýrýyoruz.
        SpawnBlock();
    }

    public void SpawnBlock()
    {
        // Instantiate fonksiyonu; bir objenin (blockPrefab) kopyasýný (clone) belirlediðimiz noktada yaratýr.
        // Quaternion.identity, objenin kendi varsayýlan dönüþ (rotation) açýsýyla gelmesini saðlar.
        Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
    }
}