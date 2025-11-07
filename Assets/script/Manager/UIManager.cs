using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void OnRestartButton()
    {
        GameManager.Instance.Restart();
    }
}
