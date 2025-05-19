using System.Collections;
using UnityEngine;

public class Lap : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            SaveScript.WwTextReset = true;
            StartCoroutine(WrongWayReset());
            if (!SaveScript.RaceOver) {
                if (SaveScript.HalfWayActivated) {
                    SaveScript.HalfWayActivated = false;
                    SaveScript.LastLapTimeMin = SaveScript.LapTimeMin;
                    SaveScript.LastLapTimeSec = SaveScript.LapTimeSec;
                    SaveScript.LapNb++;
                    SaveScript.LapChange = true;

                    if (SaveScript.LapNb == 2) {
                        SaveScript.BestLapTimeMin = SaveScript.LapTimeMin;
                        SaveScript.BestLapTimeSec = SaveScript.LapTimeSec;
                        SaveScript.NewRecord = true;
                    }

                    SaveScript.CheckPoint1 = false;
                    SaveScript.CheckPoint2 = false;
                    SaveScript.LastCheckPoint1 = SaveScript.ThisCheckPoint1;
                    SaveScript.LastCheckPoint2 = SaveScript.ThisCheckPoint2;
                }
            }
        }
    }

    private IEnumerator WrongWayReset() {
        yield return new WaitForSeconds(1.5f);
        SaveScript.WwTextReset = false;
    }
}