using UnityEngine;    //ESTA ES UNA LIBRERIA DE UNITY PARA LEER COMPONENTES DE LA ESCENA

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





    // Update is called once per frame
    void Update()
    {
        
    }
}
