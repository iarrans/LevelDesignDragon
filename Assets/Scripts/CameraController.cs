using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class CameraMovementScript : MonoBehaviour
{
    public Transform target; // Referencia al transform del personaje
    public float rotationSpeed = 1f; // Velocidad de rotaci�n de la c�mara

    private Vector3 offset; // Distancia entre la c�mara y el personaje
    public float distance = 3f; // Distancia inicial de la c�mara al personaje
    private Vector2 lookInput; // Entrada del rat�n para la rotaci�n de la c�mara
    public LayerMask obstructionMask; 

    void Start()
    {
        // Calcula la distancia inicial entre la c�mara y el personaje
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Calcula la rotaci�n en funci�n de la entrada del rat�n
        float horizontalInput = lookInput.x * rotationSpeed;
        float verticalInput = -lookInput.y * rotationSpeed;
        Quaternion rotation = Quaternion.Euler(verticalInput, horizontalInput, 0f);

        // Aplica la rotaci�n a la distancia entre la c�mara y el personaje
        offset = rotation * offset;
        Vector3 desiredPosition = target.position + offset;

        // Actualiza la posici�n de la c�mara manteniendo al personaje en el centro
        if (UIManager.Instance.canMove) {

            RaycastHit hit;
            if (Physics.Raycast(target.position, desiredPosition - target.position, out hit, distance, obstructionMask))
            {
                // Si el rayo encuentra un obst�culo, ajusta la posici�n de la c�mara
                transform.position = hit.point;
            }
            transform.position = target.position + offset;


            // Hace que la c�mara mire hacia el personaje
            transform.LookAt(target.position);
        }


    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Lee la entrada del rat�n para la rotaci�n de la c�mara
        lookInput = context.ReadValue<Vector2>();
    }
}


