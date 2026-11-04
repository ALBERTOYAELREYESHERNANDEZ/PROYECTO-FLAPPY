using UnityEngine;

public class obstaculo : MonoBehaviour
{
    [Header("CONFIGURACION DE MOVIMIENTO")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float resetPositionX = -10f; // POSICION X DONDE SE DESTRUYE EL OBSTACULO

    [Header("REFERENCIA DE ZONA SEGURA")]
    [SerializeField] private BoxCollider2D zonaPuntosCollider; // ARRASTRA AQUI EL OBJETO DE LA ZONA SEGURA DESDE EL INSPECTOR

    private bool puntoRegistrado = false; // EVITA QUE SE SUME MAS DE UNA VEZ POR CADA OBSTACULO

    private void Update()
    {
        // SI EL JUEGO TERMINO NO MOVER EL OBSTACULO
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;

        // MOVER EL OBSTACULO HACIA LA IZQUIERDA
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // DESTRUIR EL OBSTACULO CUANDO SALE DE LA PANTALLA
        if (transform.position.x < resetPositionX)
        {
            Destroy(gameObject);
        }

        // VERIFICAR SI EL PERSONAJE YA SUPERO LA X DE LA ZONA SEGURA AUTOMATICAMENTE
        VerificarPuntoPorPosicion();
    }

    private void VerificarPuntoPorPosicion()
    {
        if (puntoRegistrado || zonaPuntosCollider == null) return;

        // BUSCAMOS AL PERSONAJE EN LA ESCENA POR SU TAG O REFERENCIA
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // SI LA POSICION X DEL PERSONAJE SUPERA LA POSICION X DE LA ZONA SEGURA, SE SUMA EL PUNTO
            if (player.transform.position.x > zonaPuntosCollider.transform.position.x)
            {
                puntoRegistrado = true;
                Debug.Log("¡PUNTO REGISTRADO POR POSICION DE X!");

                if (GameManager.Instance != null)
                {
                    GameManager.Instance.AddScore(1);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ESTO SIGUE FUNCIONANDO PARA LAS TUBERIAS O SI QUIERES MANTENER EL TRIGGER TRADICIONAL
        if (other.CompareTag("Player") && zonaPuntosCollider != null)
        {
            Debug.Log("COLISION DETECTADA EN EL OBJETO");
        }
    }
}