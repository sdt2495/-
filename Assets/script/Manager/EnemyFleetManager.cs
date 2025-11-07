using UnityEngine;

public class EnemyFleetManager : MonoBehaviour
{
    [Header("“Gİ’è")]
    [SerializeField, Tooltip("“G‚ÌƒvƒŒƒnƒu")]
    private GameObject enemyPrefab;

    [SerializeField, Tooltip("oŒ»”")]
    private int enemyCount = 5;

    [SerializeField, Tooltip("”z’uŠÔŠuiX•ûŒüj")]
    private float spacing = 2f;

    [SerializeField, Tooltip("‰ŠúYÀ•W")]
    private float startY = 4f;

    [SerializeField, Tooltip("ˆÚ“®U•")]
    private float moveAmplitude = 2f;

    [SerializeField, Tooltip("ˆÚ“®‘¬“x")]
    private float moveSpeed = 2f;

    [Header("UŒ‚İ’è")]
    [SerializeField, Tooltip("“G’e‚ÌƒvƒŒƒnƒu")]
    private GameObject enemyBulletPrefab;

    [SerializeField, Tooltip("’e”­ËŠÔŠui•bj")]
    private float shootInterval = 2f;

    [SerializeField, Tooltip("’e‚Ì‘¬“x")]
    private float bulletSpeed = 3f;

    private float shootTimer = 0f;
    private GameObject[] enemies;

    private void Start()
    {
        SpawnFleet();
    }

    private void Update()
    {
        MoveFleet();
        Shoot();
    }

    private void SpawnFleet()
    {
        enemies = new GameObject[enemyCount];
        float startX = -(enemyCount - 1) * spacing / 2f;

        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = new Vector2(startX + i * spacing, startY);
            enemies[i] = Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }

    private void MoveFleet()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveAmplitude;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                Vector3 pos = enemies[i].transform.position;
                pos.x += Mathf.Sin(Time.time * moveSpeed + i) * 0.01f;
                pos.y = startY + offset * 0.1f;
                enemies[i].transform.position = pos;
            }
        }
    }

    private void Shoot()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            shootTimer = 0f;

            foreach (var enemy in enemies)
            {
                if (enemy != null)
                {
                    GameObject bullet = Instantiate(enemyBulletPrefab, enemy.transform.position, Quaternion.identity);
                    Bullet b = bullet.GetComponent<Bullet>();
                    b.GetType().GetField("speed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        ?.SetValue(b, -bulletSpeed);
                    b.GetType().GetField("isPlayerBullet", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        ?.SetValue(b, false);
                }
            }
        }
    }

    public void ModifyDifficulty(float speedUp, float fireRateUp)
    {
        bulletSpeed += speedUp;
        const float MIN_INTERVAL = 0.5f;
        shootInterval = Mathf.Max(shootInterval - fireRateUp, MIN_INTERVAL);
    }
}
