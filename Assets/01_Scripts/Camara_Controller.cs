using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Controller : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distanceFromTarget = 3.0f;

    [SerializeField]
    private float _cameraHeight = 1.5f; // Ajusta esta altura según lo necesites

    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-40, 40);

    void Update()
    {
        // Obtén la posición detrás del jugador
        Vector3 desiredPosition = _target.position - _target.forward * _distanceFromTarget;

        // Ajusta la altura de la cámara
        desiredPosition.y = _target.position.y + _cameraHeight;

        // Asigna la nueva posición
        transform.position = desiredPosition;

        // Asigna la rotación del jugador a la cámara
        transform.rotation = _target.rotation;
    }
}
