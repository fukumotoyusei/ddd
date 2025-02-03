using UnityEngine;
using UnityEngine.SceneManagement;  // シーンの管理を行うために必要

public class GoalTrigger : MonoBehaviour
{
    // ゴールに触れたときに呼ばれる
    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーがゴールに触れた場合
        if (other.CompareTag("Player"))
        {
            // 2ステージ目（Scene2）に遷移
            SceneManager.LoadScene("Scene2");
        }
    }
}
