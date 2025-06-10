using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SteeringRotate : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private float maxVisualRotation = 130f;

    private float currentVisualAngle;

    private void Update()
    {
        if (carController == null) return;

        // On force un input entre -1 et 1 (même si le carController déborde)
        float rawSteering = carController.CurrentSteerAngle;
        float maxSteering = Mathf.Max(1f, Mathf.Abs(carController.GetMaxSteerAngle())); // éviter division par 0
        float steeringInput = Mathf.Clamp(rawSteering / maxSteering, -1f, 1f);

        // Application d'une interpolation pour le réalisme
        float targetAngle = -steeringInput * maxVisualRotation;
        currentVisualAngle = Mathf.Lerp(currentVisualAngle, targetAngle, Time.deltaTime * 10f);

        transform.localRotation = Quaternion.Euler(0f, 0f, currentVisualAngle);
    }
}