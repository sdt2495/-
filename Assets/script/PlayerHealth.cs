using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("”í’e‰‰oİ’è")]
    [SerializeField, Tooltip("”í’eŒã‚Ì“_–Å‰ñ”")]
    private int blinkCount = 5;

    [SerializeField, Tooltip("“_–ÅŠÔŠui•bj")]
    private float blinkInterval = 0.1f;

    private SpriteRenderer spriteRenderer;
    private bool isDead = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        if (isDead) return;
        isDead = true;
        StartCoroutine(BlinkAndDie());
    }

    private System.Collections.IEnumerator BlinkAndDie()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }

        spriteRenderer.enabled = false;
        GameManager.Instance.GameOver();
    }
}
