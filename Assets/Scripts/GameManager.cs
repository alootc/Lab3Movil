using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonPersistent<GameManager>
{
    public NaveData.NaveDTO nave_dto;

    public ScoreManager score;
    public void SetNaveDTO(NaveData.NaveDTO nave_dto)
    {
        this.nave_dto = nave_dto;
    }

    public void SetScore()
    {
        score.score += nave_dto.speed;
    }

    public int GetLastScore()
    {
        return score.GetScore();
    }

    public void GameOver()
    {
        Invoke("LoadScene", 0.5f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}

