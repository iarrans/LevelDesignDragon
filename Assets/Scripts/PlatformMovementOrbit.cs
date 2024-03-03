using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementOrbit : MonoBehaviour
{
    public Transform centerObject; // El objeto alrededor del cual se va a mover
    public float radius = 2f; // Radio de la órbita
    public float orbitSpeed = 30f; // Velocidad de la órbita en grados por segundo
    public float phaseOffset = 0f;

    void Update()
    {
        // Calcular la posición del objeto en la órbita usando coordenadas polares
        Vector3 offset = new Vector3(Mathf.Cos((Time.time * orbitSpeed) + phaseOffset) * radius, Mathf.Sin((Time.time * orbitSpeed) + phaseOffset) * radius, 0f);

        // Asignar la posición relativa al centro de la órbita
        transform.position = centerObject.position + offset;

        //Para que el objeto no se incline indebidamente
        transform.rotation = new Quaternion(0, 0, 0, 0);

        transform.RotateAround(transform.position, Vector3.left, orbitSpeed * Time.deltaTime);
    }
}
