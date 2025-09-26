using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log($"Has interactuado con {gameObject.name}");
    }
}
