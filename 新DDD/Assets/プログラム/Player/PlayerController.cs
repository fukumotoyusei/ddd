using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Vector2 startPosition; // スタート位置（次のステージに遷移するために使用）

    void Start()
    {
        // プレイヤーをスタート位置に配置
        transform.position = startPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            // ゴールに到達したら次のステージへ進む
            LoadNextStage();
        }
    }

    void LoadNextStage()
    {
        // 次のステージのシーンをロードする
        // SceneManager.LoadScene("NextStageName");

        // 現在のシーンの次の番号をロード
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); // 次のシーン
    }
}
