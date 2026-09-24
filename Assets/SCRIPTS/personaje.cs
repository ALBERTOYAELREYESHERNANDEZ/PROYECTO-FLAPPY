using UnityEngine;

public class personaje  : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Rigidbody2D rb;
    // Estado del personaje
    private bool isDead = false;

    private void Awake()
    {
        // Asigna el Rigidbody2D automaticamente si no se asigno en el Inspector
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (isDead) return;

        // Detecta el espacio, clic izquierdo o toque en pantalla tactil
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Resetea la velocidad en Y antes de impulsar para mantener el salto consistente.
        // Si usas Unity 2023.1 o superior, usa "rb.linearVelocity".
        // Para versiones anteriores, conserva "rb.velocity".
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return; // Evita llamadas redundantes si ya murio

        isDead = true;
        Debug.Log("Game Over");
    }
}
