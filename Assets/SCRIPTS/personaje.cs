using UnityEngine;

public class personaje : MonoBehaviour
{
    [Header("CONFIGURACION DE VUELO")]
    [SerializeField] private float jumpForce = 5f;

    [Header("REFERENCIAS")]
    [SerializeField] private Rigidbody2D rb;

    private bool isDead = false;

    private void Awake()
    {
        // SI NO SE ASIGNO EN EL INSPECTOR OBTENEMOS EL COMPONENTE AUTOMATICAMENTE
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        // SI EL PERSONAJE ESTA MUERTO O EL GAME MANAGER MARCA GAME OVER IGNORAR ENTRADA
        if (isDead || (GameManager.Instance != null && GameManager.Instance.IsGameOver)) return;

        // DETECTAR BARRA ESPACIADORA O CLIC IZQUIERDO Y TOCAR PANTALLA
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (rb != null)
        {
            // APLICAR FUERZA DE SALTO EN EL EJE Y
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // EVITAR EJECUTAR LA LOGICA DE MUERTE MAS DE UNA VEZ
        if (isDead) return;

        isDead = true;

        // COMUNICACION SEGURA CON EL SINGLETON GAMEMANAGER
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            Debug.LogWarning("GAMEMANAGER INSTANCE NO FUE ENCONTRADO EN LA ESCENA");
        }
    }
}