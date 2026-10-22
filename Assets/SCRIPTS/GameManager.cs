using UnityEngine;    //ESTA ES UNA LIBRERIA DE UNITY PARA LEER COMPONENTES DE LA ESCENA
using TMPro;          //LIBRERIA NECESARIA PARA TRABAJAR CON TEXTMESHPRO

public class GameManager : MonoBehaviour // ES UNA CLASE DE POO
{
    //ESTA INSTANCIA PERMITE QUE PUEDA ACCEDER A LOS DEMAS CODIGOS
    public static GameManager Instance { get; private set; }

    //SE SERIALIZA PARA OBSERVAR EN EL INSPECTOR EN UNITY
    //ESTE ES PARA EL NIVEL DE VICTORIAS EN TEXTO 
    [SerializeField] private TextMeshProUGUI scoreText;
    //ES EL PANEL DE FIN DE PARTIDA AL MORIR 
    [SerializeField] private GameObject gameOverPanel;

    private int score = 0; //VARIABLE PARA LA PUNTUACION
    private bool isGameOver = false; //VARIABLE PARA EL PANEL DE FIN DE JUEGO

    //COMPROBACION PARA LA VARIABLE Y PODER ACCEDER DESDE OTROS SCRIPTS (AHORA PUBLIC)
    public bool IsGameOver => isGameOver;

    private void Awake()
    {
        //CONFIGURACION DEL PATRON SINGLETON
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            //SI YA EXISTE UNA INSTANCIA SE DESTRUYE EL DUPLICADO
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //INICIALIZAR LA INTERFAZ DE USUARIO
        UpdateScoreUI();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    //METODO PARA INCREMENTAR LA PUNTUACION DESDE OTROS SCRIPTS
    public void AddScore(int points = 1)
    {
        if (isGameOver) return;

        score += points;
        UpdateScoreUI();
    }

    //ACTUALIZA EL TEXTO EN PANTALLA
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    //METODO QUE INVOCA EL PERSONAJE AL COLISIONAR
    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        //PAUSAR EL TIEMPO DEL JUEGO
        Time.timeScale = 0f;
    }
}