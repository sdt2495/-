using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [Header("スコア上昇設定")]
    [SerializeField, Tooltip("スコア上昇間隔（秒）")]
    private float addInterval = 1f;

    [SerializeField, Tooltip("1回あたりのスコア増加量")]
    private int addAmount = 10;

    private float timer = 0f;

    private void Update()
    {
        if (GameManager.Instance == null || GameManager.Instance.IsGameOver)
            return;

        timer += Time.deltaTime;
        if (timer >= addInterval)
        {
            timer = 0f;
            GameManager.Instance.AddScore(addAmount);
        }
    }
}
