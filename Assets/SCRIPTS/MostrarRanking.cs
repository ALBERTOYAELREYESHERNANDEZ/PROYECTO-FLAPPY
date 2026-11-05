using UnityEngine;
using TMPro;

public class MostrarRanking : MonoBehaviour
{
    [Header("TEXTOS DE LOS PUESTOS (DEL 1 AL 5)")]
    [SerializeField] private TextMeshProUGUI[] textoPuestos; // Arrastra los 5 textos de UI en orden

    private void Start()
    {
        CargarYMostrarPuntajes();
    }

    private void CargarYMostrarPuntajes()
    {
        for (int i = 0; i < textoPuestos.Length; i++)
        {
            if (textoPuestos[i] != null)
            {
                int score = 0;
                if (ScoreManager.Instance != null)
                {
                    score = ScoreManager.Instance.GetHighScore(i);
                }
                else
                {
                    // Respaldo por si se abre la escena directamente
                    score = PlayerPrefs.GetInt("HighScore_" + i, 0);
                }

                // MOSTRAR FORMATO EN PANTALLA (Ej: 1. 150 pts)
                textoPuestos[i].text = (i + 1) + ".  " + score + " pts";
            }
        }
    }
}