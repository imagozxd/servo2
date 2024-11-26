using UnityEngine;

public class VehicleController : MonoBehaviour
{

    [Header("Movement Settings")]
    public float moveSpeed = 10f; // Velocidad de movimiento hacia adelante/atr�s
    public float turnSpeed = 50f; // Velocidad de giro

    [Header("Wheel Settings (Optional)")]
    public Transform[] wheels; // Ruedas que girar�n visualmente
    public float wheelRotationSpeed = 360f; // Velocidad de rotaci�n de las ruedas

    private float forwardInput;
    private float turnInput;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ajusta el centro de masa para hacerlo m�s estable
        if (rb != null)
        {
            rb.centerOfMass = new Vector3(0, -0.5f, 0); // Baja el centro de masa
        }
    }
    void Update()
    {
        // Captura de entrada
        forwardInput = Input.GetAxis("Vertical"); // W/S o flechas arriba/abajo
        turnInput = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha

        // Movimiento y giro
        MoveVehicle();
        TurnVehicle();

        // Rotaci�n visual de las ruedas (opcional)
        if (wheels != null && wheels.Length > 0)
        {
            RotateWheels();
        }
    }

    private void MoveVehicle()
    {
        // Mover el veh�culo hacia adelante o atr�s
        transform.Translate(Vector3.forward * -forwardInput * moveSpeed * Time.deltaTime);
    }

    private void TurnVehicle()
    {
        // Girar el veh�culo
        transform.Rotate(Vector3.up, turnInput * turnSpeed * Time.deltaTime);
    }

    private void RotateWheels()
    {
        // Rotar las ruedas cuando el veh�culo se mueve
        foreach (Transform wheel in wheels)
        {
            if (forwardInput != 0)
            {
                wheel.Rotate(Vector3.right, forwardInput * wheelRotationSpeed * Time.deltaTime);
            }
        }
    }
}
