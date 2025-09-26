using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    // Nombre de la escena que quieres cargar
    public string sceneToLoad = "Escene1";

    // Método que se llama al presionar el botón
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
