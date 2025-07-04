using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car {
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour {
        private CarController m_Car; // the car controller we want to use


        private void Awake() {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate() {
            if (SaveScript.RaceStart) {
                // pass the input to the car!
                var h = CrossPlatformInputManager.GetAxis("Horizontal");
                var v = CrossPlatformInputManager.GetAxis("Vertical");

                if (v < 0 && h != 0)
                    SaveScript.BreakSlide = true;

                if (v >= 0)
                    SaveScript.BreakSlide = false;

#if !MOBILE_INPUT
                var handbrake = CrossPlatformInputManager.GetAxis("Jump");
                m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
            }
        }
    }
}