using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [Header("ìÔà’ìxê›íË")]
    [SerializeField] private float interval = 10f;
    [SerializeField] private float bulletSpeedUp = 0.5f;
    [SerializeField] private float fireRateUp = 0.2f;
    [SerializeField] private int maxLevel = 0;

    private float timer = 0f;
    private int currentLevel = 0;
    private EnemyFleetManager fleet;

    private void Start()
    {
        fleet = FindAnyObjectByType<EnemyFleetManager>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            currentLevel++;
            if (maxLevel == 0 || currentLevel <= maxLevel)
                fleet.ModifyDifficulty(bulletSpeedUp, fireRateUp);
        }
    }
}
