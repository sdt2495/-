using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // シングルトンインスタンス
    public static GameManager Instance { get; private set; }

    [Header("スコアUI")]
    [SerializeField, Tooltip("スコア表示用テキスト")]
    private TMP_Text scoreText;

    [Header("ゲームオーバーUI")]
    [SerializeField, Tooltip("ゲームオーバー画面（ボタン付きパネルなど）")]
    private GameObject gameOverUI;

    private int score = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        // シングルトン初期化
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UpdateScoreUI();
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    private void Update()
    {
        // スペースキーでも再スタート可能
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score : {score}";
    }

    public void GameOver()
    {
        isGameOver = true;
        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGameOver => isGameOver;
}
