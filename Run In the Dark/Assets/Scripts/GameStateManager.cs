using UnityEngine;
using System.Collections;

public enum GameState
{
    CinematicaInicialParte1,
    GameplayFase1,
    CinematicaIntermedia1,
    GameplayFase2,
    CinematicaIntermedia2,
    GameplayFase3,
    CinematicaFinalParte1, // También es CinematicaInicialParte2
    GameOverParte1
}


public class GameStateManager : MonoBehaviour
{

    public InputController inputController; // Asigna desde el inspector
    public TimedInteractionController timedController;


    public GameState currentState;

    // Flags de progreso
    private bool cinematicaFinalParte1Vista = false;
    private bool[] cinematicasParte1Vistas = new bool[3]; // Para fases 1, 2, 3

    public GameObject cinematicaPanel;

    void Start()
    {
        StartCoroutine(HandleState(currentState));
    }

    public void ChangeState(GameState newState)
    {
        StopAllCoroutines();
        currentState = newState;
        StartCoroutine(HandleState(currentState));
    }

    IEnumerator HandleState(GameState state)
    {
        switch (state)
        {
            case GameState.CinematicaInicialParte1:
                if (!cinematicasParte1Vistas[0])
                {
                    cinematicasParte1Vistas[0] = true;
                    yield return StartCoroutine(ReproducirCinematica("CinematicaInicioParte1"));
                }
                ChangeState(GameState.GameplayFase1);
                break;

            case GameState.GameplayFase1:
                ActivarGameplay(1);
                break;

            case GameState.CinematicaIntermedia1:
                if (!cinematicasParte1Vistas[1])
                {
                    cinematicasParte1Vistas[1] = true;
                    yield return StartCoroutine(ReproducirCinematica("CinematicaIntermedia1"));
                }
                ChangeState(GameState.GameplayFase2);
                break;

            case GameState.GameplayFase2:
                ActivarGameplay(2);
                break;

            case GameState.CinematicaIntermedia2:
                if (!cinematicasParte1Vistas[2])
                {
                    cinematicasParte1Vistas[2] = true;
                    yield return StartCoroutine(ReproducirCinematica("CinematicaIntermedia2"));
                }
                ChangeState(GameState.GameplayFase3);
                break;

            case GameState.GameplayFase3:
                ActivarGameplay(3);
                break;

            case GameState.CinematicaFinalParte1:
                if (!cinematicaFinalParte1Vista)
                {
                    cinematicaFinalParte1Vista = true;
                    yield return StartCoroutine(ReproducirCinematica("CinematicaFinalParte1_TransicionParte2"));
                }
                // Aquí podrías cargar la escena de Parte 2 o cambiar de estado
                Debug.Log("Transición a Parte 2");
                break;

            case GameState.GameOverParte1:
                yield return StartCoroutine(ReproducirCinematica("CinematicaDerrotaParte1"));
                MostrarGameOver();
                break;
        }
    }

    IEnumerator ReproducirCinematica(string nombre)
    {
        Debug.Log("Reproduciendo: " + nombre);

        //se pausa el temporizador
        timedController.isPaused = true;

        // Desactiva el input
        inputController.StartCinematic();


        if (cinematicaPanel != null)
            cinematicaPanel.SetActive(true);

        yield return new WaitForSeconds(5f); // Simula duración

        //Inicia el termporizador
        timedController.isPaused = false;

        if (cinematicaPanel != null)
            cinematicaPanel.SetActive(false);
        // Reactiva el input
        inputController.EndCinematic();


    }

    void ActivarGameplay(int fase)
    {
        Debug.Log("Activando gameplay de fase " + fase);
        // Aquí puedes activar el controlador de tiempo y objetos de esa fase
    }

    void MostrarGameOver()
    {
        Debug.Log("Mostrar menú de Game Over");
        // Activar UI de derrota, opciones de reinicio, etc.
    }


}
