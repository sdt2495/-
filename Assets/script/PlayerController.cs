using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField, Tooltip("移動速度")]
    private float moveSpeed = 6f;

    [SerializeField, Tooltip("移動制限範囲（X, Y）")]
    private Vector2 moveLimit = new Vector2(8f, 4f);

    [Header("攻撃設定")]
    [SerializeField, Tooltip("プレイヤー弾のプレハブ")]
    private GameObject playerBulletPrefab;

    [SerializeField, Tooltip("弾の発射位置")]
    private Transform firePoint;

    [SerializeField, Tooltip("連射間隔（秒）")]
    private float fireInterval = 0.25f;

    private Rigidbody2D rb;
    private float fireTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        rb.linearVelocity = direction * moveSpeed;

        // 範囲制限
        float clampedX = Mathf.Clamp(transform.position.x, -moveLimit.x, moveLimit.x);
        float clampedY = Mathf.Clamp(transform.position.y, -moveLimit.y, moveLimit.y);
        transform.position = new Vector2(clampedX, clampedY);
    }

    private void Shoot()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && fireTimer >= fireInterval)
        {
            fireTimer = 0f;
            Instantiate(playerBulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}
