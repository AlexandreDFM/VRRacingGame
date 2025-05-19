using UnityEngine;

public class ProgressWaypoints : MonoBehaviour {
    public int WPnumber;
    public int CarTracking;
    public bool PenaltyOption;
    public int PenaltyWayPoint;
    public int Position;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Progress")) {
            CarTracking = other.gameObject.GetComponent<ProgressTracker>().CurrentWP;
            if (CarTracking < WPnumber) {
                other.gameObject.GetComponent<ProgressTracker>().CurrentWP = WPnumber;
                Position++;
                SaveScript.PlayerPosition = Position;
            }

            if (CarTracking > WPnumber)
                other.gameObject.GetComponent<ProgressTracker>().LastWPNumber = WPnumber;

            if (PenaltyOption) {
                if (CarTracking < PenaltyWayPoint) {
                    Debug.Log("Penalty Waypoint");
                    SaveScript.PenaltySeconds += 5;
                    PenaltyOption = false;
                }
            }
        }
    }
}