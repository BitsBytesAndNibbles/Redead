
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
   public void EndGame()
    {
        Debug.Log("GameOver");
        gameOverText.SetActive(true);
    }
}
