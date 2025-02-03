using UnityEngine;

public class Ground : MonoBehaviour
{
    // プレイヤーが地面に接しているかどうかを示すフラグ
    public bool isPlayerOnGround = false;

    // プレイヤーのリファレンス（インスペクタから設定）
    public GameObject player;

    // プレイヤーが地面に接触したとき
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            // プレイヤーが地面に接触した
            isPlayerOnGround = true;
        }
    }

    // プレイヤーが地面から離れたとき
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            // プレイヤーが地面から離れた
            isPlayerOnGround = false;
        }
    }
}
