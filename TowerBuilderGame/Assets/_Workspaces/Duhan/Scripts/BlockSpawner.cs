using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [Header("Üretim Ayarlarý")]
    // DÝKKAT: Artýk köþeli parantez [] ile bir dizi oluþturduk.
    [SerializeField] private GameObject[] blockPrefabs;
    [SerializeField] private float spawnHeightOffset = 6f;

    void Start()
    {
        SpawnBlock();
    }

    public void SpawnBlock()
    {
        float spawnY = Camera.main.transform.position.y + spawnHeightOffset;
        Vector3 finalSpawnPosition = new Vector3(0, spawnY, 0);

        // 0 ile dizideki eleman sayýsý arasýnda rastgele bir sayý seç
        int randomIndex = Random.Range(0, blockPrefabs.Length);

        // Seçilen rastgele þekli üret
        Instantiate(blockPrefabs[randomIndex], finalSpawnPosition, Quaternion.identity);
    }
}