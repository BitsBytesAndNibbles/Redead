using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

	public void EndGame()
    {
        Debug.Log("GameOver");
		gameOverPanel.SetActive(true);
    }

	public void OnRestart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OnToMenu()
	{
		SceneManager.LoadScene("Menue");
	}
}
