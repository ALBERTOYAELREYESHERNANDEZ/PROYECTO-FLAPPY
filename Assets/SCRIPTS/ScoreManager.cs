using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantiene el manager vivo entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // INTENTA GUARDAR UN NUEVO PUNTAJE Y DEVUELVE TRUE SI ENTRO EN EL TOP 5
    public bool CheckAndSaveScore(int nuevoPuntaje)
    {
        if (nuevoPuntaje <= 0) return false; // Opcional: no guardar puntajes de 0

        for (int i = 0; i < 5; i++)
        {
            string key = "HighScore_" + i;
            int scoreActual = PlayerPrefs.GetInt(key, 0);

            if (nuevoPuntaje > scoreActual)
            {
                // DESPLAZAR LOS PUNTAJES INFERIORES HACIA ABAJO
                ShiftScores(i);

                // GUARDAR EL NUEVO PUNTAJE EN SU NUEVA POSICION
                PlayerPrefs.SetInt(key, nuevoPuntaje);
                PlayerPrefs.Save();
                return true;
            }
        }
        return false;
    }

    private void ShiftScores(int index)
    {
        for (int i = 4; i > index; i--)
        {
            string keyPrev = "HighScore_" + (i - 1);
            string keyCurr = "HighScore_" + i;
            
            int scoreToMove = PlayerPrefs.GetInt(keyPrev, 0);
            PlayerPrefs.SetInt(keyCurr, scoreToMove);
        }
    }

    // OBTENER UN PUNTAJE ESPECIFICO DEL TOP 5 (DEL 0 AL 4)
    public int GetHighScore(int index)
    {
        return PlayerPrefs.GetInt("HighScore_" + index, 0);
    }
}