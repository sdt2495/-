using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("íeê›íË")]
    [SerializeField, Tooltip("íeë¨Åiê≥Ç≈è„ÅAïâÇ≈â∫Åj")]
    private float speed = 5f;

    [SerializeField, Tooltip("éıñΩÅiïbÅj")]
    private float lifetime = 5f;

    [SerializeField, Tooltip("ÉvÉåÉCÉÑÅ[íeÇ©ìGíeÇ©")]
    private bool isPlayerBullet = true;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayerBullet && collision.CompareTag("Enemy"))
        {
            GameManager.Instance.AddScore(100);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (!isPlayerBullet && collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>()?.TakeDamage();
            Destroy(gameObject);
        }
    }
}
