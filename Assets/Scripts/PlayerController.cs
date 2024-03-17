using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private Vector2 moveInput;

    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verificar si el jugador está en el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f, groundMask);
    }

    void FixedUpdate()
    {
        // Obtener la dirección de la cámara
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Eliminar la componente vertical para el movimiento horizontal relativo a la cámara
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calcular la dirección de movimiento basada en la dirección de la cámara
        Vector3 moveDirection = cameraForward * moveInput.y + cameraRight * moveInput.x;

        // Normalizar para evitar movimientos diagonales más rápidos
        moveDirection.Normalize();

        // Aplicar el movimiento al Rigidbody del personaje
        if (UIManager.Instance.canMove) rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Obtener la entrada de movimiento del jugador
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // Manejar el salto
        //transform.parent = null;
        if (isGrounded)
        {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
