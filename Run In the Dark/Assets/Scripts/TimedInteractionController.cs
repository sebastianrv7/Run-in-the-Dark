using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedInteractionController : MonoBehaviour
{
    public float timeLimit = 10f;
    private float remainingTime;
    private int interactionsCompleted = 0;

    public bool isPaused = false;


    public List<PillarInteractable> interactables; // Lista de pilares
    public Image timeBar; // Barra de tiempo
    public Image checkIcon; // Cuadro único debajo de la barra
    public Sprite checkmarkSprite; // Sprite del chulito verde

    private bool resultShown = false;

    void Start()
    {
        remainingTime = timeLimit;
    }

    void Update()
    {
        if (resultShown || isPaused) return;

        remainingTime -= Time.deltaTime;
        UpdateTimeBar();

        if (remainingTime <= 0f)
        {
            EvaluateResult();
        }
    }

    public void RegisterInteraction(PillarInteractable pillar)
    {
        if (!pillar.HasBeenInteracted)
        {
            interactionsCompleted++;
            pillar.HasBeenInteracted = true;

            if (interactionsCompleted >= interactables.Count)
            {
                // Mostrar el chulito, pero no evaluar aún
                checkIcon.sprite = checkmarkSprite;
                Debug.Log("Todas las interacciones completadas, esperando evaluación final...");
            }


        }
    }

    void EvaluateResult()
    {
        resultShown = true;

        if (interactionsCompleted >= interactables.Count)
        {
            Debug.Log("¡Lo lograste! / You did it!");
            checkIcon.sprite = checkmarkSprite;
        }
        else
        {
            Debug.Log("Perdiste / You lost");
        }
    }

    void UpdateTimeBar()
    {
        float progress = Mathf.Clamp01(remainingTime / timeLimit);
        timeBar.fillAmount = progress;
    }


}
