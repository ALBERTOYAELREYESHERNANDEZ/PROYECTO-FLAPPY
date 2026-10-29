using UnityEngine;

public class obstaculo : MonoBehaviour
{
    [Header("CONFIGURACION DE MOVIMIENTO")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float resetPositionX = -50f; // POSICION X DONDE SE DESTRUYE O REINICIA

    private void Update()
    {
        // SI EL JUEGO TERMINO NO MOVER EL OBSTACULO
       // if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;

        // MOVER EL OBSTACULO HACIA LA IZQUIERDA
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // DESTRUIR EL OBSTACULO CUANDO SALE DE LA PANTALLA
        if (transform.position.x < resetPositionX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // VERIFICAR SI EL OBJETO QUE CRUZO FUE EL PERSONAJE
        if (other.CompareTag("Player"))
        {
            // SUMAR PUNTOS AL GAMEMANAGER
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(1);
            }
        }
    }
}