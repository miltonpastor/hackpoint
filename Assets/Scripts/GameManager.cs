using UnityEngine;
using UnityEngine.InputSystem.XR;

 public enum GameState
{
    //menu,
    inGame,
    gameOver,
    levelComplete
}


public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.inGame;
    public static GameManager sharedInstance; // Debido a que GameManager es un singleton


    void State()
    {
        if (currentGameState == GameState.gameOver)
        {
            GameOver();
        }
        else if (currentGameState == GameState.levelComplete)
        {
            LevelComplete();
        }
        else if (currentGameState == GameState.inGame)
        {
            StartGame();
        }
    }

    void Awake()
    {
        if (sharedInstance == null) { sharedInstance = this; } //Para que solo exista un GameManager
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        State();
    }


    public void GameOver()//Metodo encargado de acabar la partida
    {
        SetGameState(GameState.gameOver);
    }

    public void StartGame() //Metodo encargado de iniciar la partida
    {
        SetGameState(GameState.inGame); //Funcion cambia de estado del juego, que tiene como parametro "inGame"
        //GetComponent<AudioSource>().Play();
    }

    public void LevelComplete() //Metodo encargado de completar el nivel
    {
        SetGameState(GameState.levelComplete);
    }


    private void SetGameState(GameState newGameSate) //El manager es el unico que puedo cambiar el estado del videojuego //Metodo que sirve para cambiar el estado del videojuego 
    {
        if (newGameSate == GameState.inGame)
        {
            //LevelManager.sharedInstance.RemoveAllLevelBlock();
            //LevelManager.sharedInstance.GenerateInnitialBlocks();
            //controller.StartGame();  //Llammos a la funcion StartGame del PlayerControl (Reniniciar al personaje) 
            //MenuManager.sharedInstance.ShowMainGame();
            MenuManager.sharedInstance.HideGameOverPanel();
            MenuManager.sharedInstance.HideLevelCompletePanel();
            //controller.GetComponent<BoxCollider2D>().offset = new Vector2(0.02675509f, -1.246225f);

        }
        else if (newGameSate == GameState.gameOver)
        {
            MenuManager.sharedInstance.ShowGameOverPanel();
            MenuManager.sharedInstance.HideLevelCompletePanel();
            //MenuManager.sharedInstance.HideMainGame();
        }

        //This -> para enfatizar que es una variable de esta propia clase 
        this.currentGameState = newGameSate;
    }
}
