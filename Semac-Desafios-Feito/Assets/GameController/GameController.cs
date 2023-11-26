using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    public bool IsGamePaused { get; set; }
    private float TimeAudioPaused { get; set; } = 0;
    private AudioSource audioManiac;
    [SerializeField] private TextMeshProUGUI pauseResume;
    private void Awake()
    {
        LoadScore();
        audioManiac = GetComponent<AudioSource>();
    }
    public void GamePause()
    {
        if (!IsGamePaused)
        {
            Time.timeScale = 0f;
            IsGamePaused = true;
            TimeAudioPaused = audioManiac.time;
            audioManiac.Stop();
            pauseResume.text = "Resume";
        }
        else
        {
            Time.timeScale = 1f;
            IsGamePaused = false;
            audioManiac.time = TimeAudioPaused;
            audioManiac.Play();
            pauseResume.text = "Pause";
        }
    }
    public void SaveItemCollection(int n)
    {
        score.text = (int.Parse(score.text) + n).ToString();
        SaveScore();
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("score", int.Parse(score.text));
        PlayerPrefs.Save();
    }

    private void LoadScore()
    {
        score.text = PlayerPrefs.GetInt("score", 0).ToString();
    }

    public void Quit() => Application.Quit();

    public void NextStage(string stage) => SceneManager.LoadScene(stage);
}
