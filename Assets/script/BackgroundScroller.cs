using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BackgroundScroller : MonoBehaviour
{
    [Header("スクロール設定")]
    [SerializeField, Tooltip("スクロール速度（Y方向）")]
    private float scrollSpeed = 0.1f;

    private Renderer backgroundRenderer;
    private Vector2 offset = Vector2.zero;

    private void Awake()
    {
        // 背景のマテリアルを取得
        backgroundRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        // スクロール速度に基づいてUV座標を変更
        offset.y += scrollSpeed * Time.deltaTime;
        backgroundRenderer.material.mainTextureOffset = offset;
    }
}
