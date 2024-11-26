using UnityEngine;

public class VehicleController : MonoBehaviour
{

    [Header("Movement Settings")]
    public float moveSpeed = 10f; // Velocidad de movimiento hacia adelante/atrás
    public float turnSpeed = 50f; // Velocidad de giro

    [Header("Wheel Settings (Optional)")]
    public Transform[] wheels; // Ruedas que girarán visualmente
    public float wheelRotationSpeed = 360f; // Velocidad de rotación de las ruedas

    private float forwardInput;
    private float turnInput;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ajusta el centro de masa para hacerlo más estable
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

        // Rotación visual de las ruedas (opcional)
        if (wheels != null && wheels.Length > 0)
        {
            RotateWheels();
        }
    }

    private void MoveVehicle()
    {
        // Mover el vehículo hacia adelante o atrás
        transform.Translate(Vector3.forward * -forwardInput * moveSpeed * Time.deltaTime);
    }

    private void TurnVehicle()
    {
        // Girar el vehículo
        transform.Rotate(Vector3.up, turnInput * turnSpeed * Time.deltaTime);
    }

    private void RotateWheels()
    {
        // Rotar las ruedas cuando el vehículo se mueve
        foreach (Transform wheel in wheels)
        {
            if (forwardInput != 0)
            {
                wheel.Rotate(Vector3.right, forwardInput * wheelRotationSpeed * Time.deltaTime);
            }
        }
    }
}
