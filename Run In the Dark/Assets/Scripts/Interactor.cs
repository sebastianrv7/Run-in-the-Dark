using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public interface IInteractable
{
    void Interact();
}
public class Interactor : MonoBehaviour
{
    public Transform interacterSource; // Asigna la cámara aquí
    public float interactRange = 5f;

    void Update()
    {
        Debug.DrawRay(interacterSource.position, interacterSource.forward * interactRange, Color.red);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(interacterSource.position, interacterSource.forward);

            // Ignora la capa "Player"
            int layerMask = ~LayerMask.GetMask("Player");

            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange, layerMask))
            {
                if (hitInfo.collider.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }

    }


}
