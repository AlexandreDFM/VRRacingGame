using UnityEngine;

public class FinishLine : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            SaveScript.RaceOver = true;
            Time.timeScale = 0.2f;
        }
    }
}