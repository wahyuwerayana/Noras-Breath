using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int playerHP = 100;
    public GameObject gameoverPanel;
    public TMP_Text healthText;

    private void Start() {
        healthText.text = playerHP.ToString();
    }

    public void PlayerTakeDamage(int damage){
        playerHP -= damage;
        playerHP = Mathf.Clamp(playerHP, 0, 100);
        healthText.text = playerHP.ToString();
        if(playerHP <= 0){
            GameOver();
        }
    }
    public void GameOver(){
        gameoverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Retry(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
