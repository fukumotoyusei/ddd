using UnityEngine;
using System.Collections;

public class DoorAnimation2 : MonoBehaviour
{
    public Sprite[] doorSprites;   // ドアのアニメーションフレーム（24枚）
    public float animationSpeed = 0.1f; // アニメーションのスピード（秒）

    private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float timer;
    private bool isPlayerNear = false; // プレイヤーが近くにいるかどうか
    private bool isAnimating = false;  // アニメーションが進行中かどうか
    private bool hasAnimated = false; // アニメーションが一度再生されたかどうか

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (doorSprites.Length == 0)
        {
            Debug.LogError("ドアのスプライトが設定されていません！");
            return;
        }

        currentFrame = 0;
        timer = 0f;

        spriteRenderer.sprite = doorSprites[0];
    }

    void Update()
    {
        // プレイヤーが近づき、まだアニメーションが再生されていない場合のみアニメーションを開始
        if (isPlayerNear && !isAnimating && !hasAnimated)
        {
            isAnimating = true;
            currentFrame = 0;
        }

        // アニメーションが進行中であれば、アニメーションを進める
        if (isAnimating)
        {
            AnimateDoor();
        }
    }

    void AnimateDoor()
    {
        timer += Time.deltaTime;

        if (timer >= animationSpeed)
        {
            timer = 0f;

            currentFrame++;
            if (currentFrame >= doorSprites.Length)
            {
                currentFrame = doorSprites.Length - 1; // 最後のフレームで停止
                isAnimating = false;
                hasAnimated = true; // アニメーション再生済みフラグを立てる
            }

            spriteRenderer.sprite = doorSprites[currentFrame];
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}