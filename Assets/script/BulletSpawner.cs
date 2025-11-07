using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("弾設定")]
    [SerializeField, Tooltip("弾のプレハブ")]
    private GameObject bulletPrefab;

    [SerializeField, Tooltip("弾の生成間隔（秒）")]
    private float spawnInterval = 1f;

    [SerializeField, Tooltip("弾の落下速度")]
    private float bulletSpeed = 3f;

    [SerializeField, Tooltip("弾の生成範囲（X軸）")]
    private float spawnRangeX = 8f;

    [SerializeField, Tooltip("弾の生成Y座標")]
    private float spawnY = 6f;

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), spawnY);
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.linearVelocity = Vector2.down * bulletSpeed;
    }

    // 難易度上昇時に呼ばれる
    public void ModifyDifficulty(float speedIncrease, float intervalDecrease)
    {
        bulletSpeed += speedIncrease;
        const float MIN_SPAWN_INTERVAL = 0.2f;
        spawnInterval = Mathf.Max(spawnInterval - intervalDecrease, MIN_SPAWN_INTERVAL);
    }
}
