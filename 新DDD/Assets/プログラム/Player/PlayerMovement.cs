using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // プレイヤーの移動速度
    public float moveSpeed = 5f;

    // プレイヤーのRigidbody2D
    private Rigidbody2D rb;

    // プレイヤーの移動入力
    private float moveInput;

    void Start()
    {
        // Rigidbody2Dコンポーネントの取得
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // プレイヤーの入力に基づく移動
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // 水平移動の処理
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
