using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public TextMeshProUGUI currentCoinsText;
    public TextMeshProUGUI highestCoinsText;
    public int currentCoins = 0;
    public int highestCoins;
    public int currentLives = 3;
    public TextMeshProUGUI currentLivesText;
    public GameObject levelFailedPanel;
    public static UIManager Instance;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLivesText.text = "Current Lives Remaining : " + currentLives;
        highestCoins = PlayerPrefs.GetInt("HighestCoin", 0);
        highestCoinsText.text = "Top Coins : " + PlayerPrefs.GetInt("HighestCoin", 0).ToString();
        
    }

    public void OnCoinCollected()
    {
        currentCoins += 10;
        currentCoinsText.text ="Current Coins : " + currentCoins.ToString();
        if(currentCoins >highestCoins)
        {
            highestCoins = currentCoins;
            PlayerPrefs.SetInt("HighestCoin", highestCoins);
        }
    }
    public void OnBombHit()
    {
        currentLives--;
        currentLivesText.text = "Current Lives Remaining : " + currentLives;
        {
            if(currentLives <=0)
            {
                OnLevelFailed();
            }
        }
    }
    public void OnLifeHit()
    {
        if(currentLives<3)
        {
            currentLives++;
            currentLivesText.text = "Current Lives Remaining : " + currentLives;
        }
    }
    public void OnLevelFailed()
    {
        Time.timeScale = 0;
        levelFailedPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
