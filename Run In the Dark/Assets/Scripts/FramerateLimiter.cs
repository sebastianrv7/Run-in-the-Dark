using UnityEngine;

public class FramerateLimiter : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0; // Desactiva VSync para que el l�mite se respete
        DontDestroyOnLoad(gameObject);  // Persiste entre escenas
    }

}
