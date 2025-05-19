using UnityEngine;

public class Checkpoints : MonoBehaviour {
    public bool Checkpoint1 = true;
    public bool Checkpoint2;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (Checkpoint1) {
                SaveScript.ThisCheckPoint1 = SaveScript.GameTime;
                SaveScript.CheckPoint1 = true;
            }
            else if (Checkpoint2) {
                SaveScript.ThisCheckPoint2 = SaveScript.GameTime;
                SaveScript.CheckPoint2 = true;
            }
        }
    }
}