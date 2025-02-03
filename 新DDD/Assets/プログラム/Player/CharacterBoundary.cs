using UnityEngine;

public class CharacterBoundary : MonoBehaviour
{
    public float speed = 2f; // キャラクターの移動速度

    private float minX, maxX, minY, maxY;

    void Start()
    {
        // カメラのビューポート端を取得（0,0が左下、1,1が右上）
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // 取得したワールド座標を制限値として使用
        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;
    }

    void Update()
    {
        // 入力による移動
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 newPosition = transform.position + new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;

        // 移動範囲を制限
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // キャラクターの位置を更新
        transform.position = newPosition;
    }
}
