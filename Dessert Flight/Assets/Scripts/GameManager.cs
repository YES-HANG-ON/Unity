using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private GameObject gameOverPanel;

    private bool isGameOver = false;

    [SerializeField]
    private TextMeshProUGUI text;

    public GameObject startCoverPanel;
    public GameObject spawnDessertOBJ;
    public GameObject playerOBJ;

    private int playerScore = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        gameOverPanel.SetActive(false);
        spawnDessertOBJ.SetActive(false);
        playerOBJ.SetActive(false);
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown("r"))
        {
            restartGame();
        }
    }

    public void IncreaseScore()
    {
        playerScore++;
        text.SetText(playerScore.ToString());
    }

    public void SetGameOver()
    {
        DessertSpawner dessertSpawner = FindObjectOfType<DessertSpawner>();
        if (dessertSpawner != null)
        {
            dessertSpawner.StopDessertRoutine();
        }
        gameOverPanel.SetActive((true));
        isGameOver = true;
    }

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickStartButton()
    {
        startCoverPanel.SetActive(false);
        spawnDessertOBJ.SetActive(true);
        playerOBJ.SetActive(true);
    }
}
