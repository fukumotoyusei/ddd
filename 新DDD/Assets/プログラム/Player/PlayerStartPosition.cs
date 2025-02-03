// 例: シーン遷移後にプレイヤーを特定の位置に移動
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    public Transform spawnPoint;  // スポーン地点を指定する変数

    void Start()
    {
        // プレイヤーをスポーン地点に移動
        transform.position = spawnPoint.position;
    }
}
