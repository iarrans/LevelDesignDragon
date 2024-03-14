using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class CameraMovementScript : MonoBehaviour
{
    public Transform target; // Referencia al transform del personaje
    public float rotationSpeed = 1f; // Velocidad de rotación de la cámara

    private Vector3 offset; // Distancia entre la cámara y el personaje
    public float distance = 3f; // Distancia inicial de la cámara al personaje
    private Vector2 lookInput; // Entrada del ratón para la rotación de la cámara
    public LayerMask obstructionMask; 

    void Start()
    {
        // Calcula la distancia inicial entre la cámara y el personaje
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Calcula la rotación en función de la entrada del ratón
        float horizontalInput = lookInput.x * rotationSpeed;
        float verticalInput = -lookInput.y * rotationSpeed;
        Quaternion rotation = Quaternion.Euler(verticalInput, horizontalInput, 0f);

        // Aplica la rotación a la distancia entre la cámara y el personaje
        offset = rotation * offset;
        Vector3 desiredPosition = target.position + offset;

        // Actualiza la posición de la cámara manteniendo al personaje en el centro
        if (UIManager.Instance.canMove) {

            RaycastHit hit;
            if (Physics.Raycast(target.position, desiredPosition - target.position, out hit, distance, obstructionMask))
            {
                // Si el rayo encuentra un obstáculo, ajusta la posición de la cámara
                transform.position = hit.point;
            }
            transform.position = target.position + offset;


            // Hace que la cámara mire hacia el personaje
            transform.LookAt(target.position);
        }


    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Lee la entrada del ratón para la rotación de la cámara
        lookInput = context.ReadValue<Vector2>();
    }
}


