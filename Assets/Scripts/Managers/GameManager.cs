using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    public GameObject gameOverCanvas;
    public GameObject gameClearCanvas;

    private readonly List<int> _stageList = new List<int>();
    private const int TotalStageCount = 1;
    
    private void Start()
    {
        InitStageList();
    }

    void InitStageList()
    {
        _stageList.Clear();
        for (int i = 1; i <= TotalStageCount; i++)
        {
            _stageList.Add(i);
        }
    }

    public void LoadNextRandomStage()
    {
        Time.timeScale = 1f;

        if (_stageList.Count > 0)
        {
            int randomIndex = Random.Range(0, _stageList.Count);
            int stageNum = _stageList[randomIndex];
            _stageList.RemoveAt(randomIndex);

            SceneManager.LoadScene("Stage_" + stageNum);
        }
        else
        {
            ShowGameClear();
        }
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        gameOverCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        gameOverCanvas.SetActive(false);
        InitStageList(); 
        LoadNextRandomStage();
    }

    void ShowGameClear()
    {
        Time.timeScale = 0f;
        gameClearCanvas.SetActive(true);
    }
}