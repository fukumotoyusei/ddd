using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Sprite[] rightWalkSprites; // 右向きのスプライト配列
    public Sprite[] leftWalkSprites;  // 左向きのスプライト配列
    public Sprite idleSprite;         // 静止状態のスプライト
    public float animationSpeed = 0.1f; // アニメーションのスピード（秒）

    private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float timer;
    private bool isMovingRight = true; // 現在の移動方向
    private bool isMoving = false;    // 現在移動中かどうか

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (rightWalkSprites.Length == 0 || leftWalkSprites.Length == 0 || idleSprite == null)
        {
            Debug.LogError("スプライトが設定されていません！");
            return;
        }

        // 初期設定
        currentFrame = 0;
        timer = 0f;
    }

    void Update()
    {
        HandleMovement();
        Animate();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // 左右移動

        if (horizontal > 0)
        {
            isMovingRight = true;
            isMoving = true;
            transform.Translate(Vector2.right * Time.deltaTime * 2f); // 右に移動
        }
        else if (horizontal < 0)
        {
            isMovingRight = false;
            isMoving = true;
            transform.Translate(Vector2.left * Time.deltaTime * 2f); // 左に移動
        }
        else
        {
            isMoving = false;
        }
    }

    void Animate()
    {
        // 移動中の場合は歩行アニメーションを再生
        if (isMoving)
        {
            timer += Time.deltaTime;

            // 一定時間ごとにフレームを進める
            if (timer >= animationSpeed)
            {
                timer = 0f; // タイマーをリセット
                currentFrame = (currentFrame + 1) % rightWalkSprites.Length;

                // 移動方向に応じてスプライトを変更
                if (isMovingRight)
                {
                    spriteRenderer.sprite = rightWalkSprites[currentFrame];
                }
                else
                {
                    spriteRenderer.sprite = leftWalkSprites[currentFrame];
                }
            }
        }
        else
        {
            // 静止状態のスプライトを表示
            spriteRenderer.sprite = idleSprite;
            currentFrame = 0; // フレームをリセット（次の移動時にアニメーションが正常に開始するように）
        }
    }
}
