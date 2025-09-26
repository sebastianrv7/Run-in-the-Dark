using UnityEngine;

public class PillarInteractable : MonoBehaviour, IInteractable
{
    public TimedInteractionController timeController; // Referencia al controlador de tiempo / Reference to the time controller

    public bool HasBeenInteracted { get; set; } = false;

    public void Interact()
    {
        Debug.Log($"Interacted with {gameObject.name}");
        timeController.RegisterInteraction(this);


    }

}
