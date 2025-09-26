using UnityEngine;

public class InputController : MonoBehaviour
{
    public PlayerMovement playerMovement; // Movimiento del jugador
    public MonoBehaviour cameraInputAxisController; // Asigna el componente Cinemachine Input Axis Controller

    public void StartCinematic()
    {
        playerMovement.enabled = false;
        cameraInputAxisController.enabled = false;
    }

    public void EndCinematic()
    {
        playerMovement.enabled = true;
        cameraInputAxisController.enabled = true;
    }
}
