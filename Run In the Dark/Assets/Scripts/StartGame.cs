using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    // Nombre de la escena que quieres cargar
    public string sceneToLoad = "Escene1";

    // M�todo que se llama al presionar el bot�n
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
