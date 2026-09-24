using UnityEngine;    //ESTA ES UNA LIBRERIA DE UNITY PARA LEER COMPONENTES DE LA ESCENA
using TMPro; //Libreria para controlar textos de TextMeshPro
public class GameManager : MonoBehaviour // ES UNA CLASE DE POO
{
    //ESTA INSTANCIA PERMITE QUE PUEDA ACCEDER A LOS DEMAS CODIGOS
    public static GameManager Instance {get; private set;}

    //SE SERIALIZA PARA OBSERVAR EN EL INSPECTOR EN UNITY
    //ESTE ES PARA EL NIVEL DE VICTORIAS EN TEXTO 
    [SerializeField] private TextMeshProUGUI scoreText;
    //ES EL PANEL DE FIN DE PARTIDA AL MORIR 
    [SerializeField] private GameObject gameOverPanel;

    private int score = 0; //VARIABLE PARA LA PUNTUACION
    private bool isGameOver = false; //VARIABLE PARA EL PANEL DE FIN DE JUEGO

    //COMPROBACION PARA LA VARIBALE Y PODER ACCEDER DESDE OTROS SCRIPTS
    private bool IsGameOver => isGameOver;

     private void Awake()
    {
        //CONFIGURACION DE UN SINGLETON 
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

      private void Start()
    {
        //INICIALIZANDO LAS VARIABLES DEL ESTADO DEL JUEGO
        score = 0;
        isGameOver = false;

        UpdateScoreText(); /*ES UNA FUNCION PARA ACTULIZAR EL
        PUNTAJE */ 
        //ESTA CONDICIONAL HACE QUE AL INCIAR EL JUEGO ESTE OCULTO 
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }


    public void AddScore(int points = 1)
    {
        if (isGameOver) return;
        score += points; //SUMA DE PUNTAJE Y ACTUALIZACION
        UpdateScoreText();
    }

    public void GameOver() //PANTALLA DE GAME OVER 
    {
         if (isGameOver) return;
         isGameOver = true;
         if (gameOverPanel != null)
         {
            gameOverPanel.SetActive(true); //ACTIVA PANTALLA DE MUERTE
         }
    }
     //STRING SON PARA LEER NUMEROS EN TEXTO EN UNTIY 
     private void UpdateScoreText()
     {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
     }








    
}
