using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;



public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public TextMeshProUGUI countdownText;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame(); // Opcional: si quieres que ESC/P también reanude
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausa la lógica del juego
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        StartCoroutine(CountdownAndResume());
    }

    IEnumerator CountdownAndResume()
    {
        countdownText.gameObject.SetActive(true);
        int count = 3;
        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f); // Usa Realtime porque Time.timeScale = 0
            count--;
        }

        countdownText.gameObject.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Asegúrate de reanudar antes de cambiar de escena
        SceneManager.LoadScene("MainMenu"); // Cambia por el nombre real de tu escena
    }

}
