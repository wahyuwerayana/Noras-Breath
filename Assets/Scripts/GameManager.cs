using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int playerHP = 100;
    public GameObject gameoverPanel;
    public TMP_Text healthText;
    public static int spiritShard;
    public TMP_Text spiritShardText;
    public TMP_Text warningText;

    private void Start() {
        spiritShard = 150;
        healthText.text = playerHP.ToString();
        spiritShardText.text = spiritShard.ToString();
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
        AudioManager.instance.Play("Game Over Sound");
        Time.timeScale = 0;
    }

    public void Retry(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReduceSpiritShard(int price){
        spiritShard -= price;
    }

    public IEnumerator DisplayWarningText(string text){
        warningText.text = text;
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        warningText.gameObject.SetActive(false);
    }

    private void Update() {
        spiritShardText.text = spiritShard.ToString();
    }
}
