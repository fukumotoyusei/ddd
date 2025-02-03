using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    public Vector2 startPosition;

    void Start()
    {
        // プレイヤーのスタート位置をPlayerPrefsから取得
        float x = PlayerPrefs.GetFloat("StartPosX", 0f);
        float y = PlayerPrefs.GetFloat("StartPosY", 0f);
        startPosition = new Vector2(x, y);
        transform.position = startPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            // 次のステージのスタート位置を保存
            SaveStartPosition();
            LoadNextStage();
        }
    }

    void LoadNextStage()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    void SaveStartPosition()
    {
        // 次のステージのスタート位置を保存
        PlayerPrefs.SetFloat("StartPosX", transform.position.x);
        PlayerPrefs.SetFloat("StartPosY", transform.position.y);
    }
}
