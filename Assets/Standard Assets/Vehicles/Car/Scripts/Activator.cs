using UnityEngine;

public class Activator : MonoBehaviour {
    public GameObject FinishPoint;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            SaveScript.HalfWayActivated = true;
            if (SaveScript.LapNb == SaveScript.MaxLaps)
                FinishPoint.SetActive(true);
        }
    }
}