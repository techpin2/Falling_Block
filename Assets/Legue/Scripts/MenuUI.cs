using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject buttonScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

    public static MenuUI menuUI;

    public static bool isGameRunning;

    private void Awake()
    {
        menuUI = this;
        isGameRunning = true;
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetHighScore(int score)
    {
        highScoreText.text = score.ToString();
    }
    public void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
       // Destroy(this.gameObject);
    }
}
