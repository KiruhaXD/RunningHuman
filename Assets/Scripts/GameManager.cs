using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private TMP_Text textForLevel;
    [SerializeField] private GameObject finishWindow;
    [SerializeField] private GameObject loseWindow;

    [SerializeField] private CoinManager coinManager;

    private void Start()
    {
        finishWindow.SetActive(false);
        loseWindow.SetActive(false);
        textForLevel.text = SceneManager.GetActiveScene().name;
    }

    public void Play() 
    {
        startMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviour>().StartPlay();
    }

    public void ShowFinishWindow() 
    {
        finishWindow.SetActive(true);
    }

    public void LoseWindow() 
    {
        loseWindow.SetActive(true);
    }

    public void NextLevel() 
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;

        // если номер след.сцены меньше чем общее число сцен, то можем эту сцену прогрузить
        if (next < SceneManager.sceneCountInBuildSettings) 
        {
            coinManager.SaveToProgress();
            SceneManager.LoadScene(next);
        }
        
    }

    public void Restart() 
    {
        int restartScene = SceneManager.GetActiveScene().buildIndex;
        coinManager.SaveToProgress();
        SceneManager.LoadScene(restartScene);
    }
}
