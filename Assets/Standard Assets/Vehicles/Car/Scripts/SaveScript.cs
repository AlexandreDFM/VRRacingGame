using UnityEngine;

public class SaveScript : MonoBehaviour {
    public static float Speed;
    public static bool BreakSlide;
    public static float TopSpeed;
    public static int Gear;
    public static int LapNb;
    public static bool LapChange;
    public static float LapTimeMin;
    public static float LapTimeSec;
    public static float RaceTimeMin;
    public static float RaceTimeSec;
    public static float BestLapTimeMin = 0;
    public static float BestLapTimeSec = 0;
    public static float LastLapTimeMin = 0;
    public static float LastLapTimeSec = 0;
    public static float GameTime;
    public static float LastCheckPoint1 = 0;
    public static float ThisCheckPoint1 = 0;
    public static float LastCheckPoint2 = 0;
    public static float ThisCheckPoint2 = 0;
    public static bool CheckPoint1 = false;
    public static bool CheckPoint2 = false;
    public static bool NewRecord = false;
    public static bool OntTheRoad = true;
    public static bool OnTheTerrain = false;
    public static bool Rumble1 = false;
    public static bool Rumble2 = false;
    public static bool WrongWay = false;
    public static bool HalfWayActivated = true;
    public static bool WwTextReset = false;
    public static bool RaceStart = false;
    public static float TimeTrialMinG = 0;
    public static float TimeTrialSecondsG = 47;
    public static float TimeTrialMinS = 0;
    public static float TimeTrialSecondsS = 49;
    public static float TimeTrialMinB = 0;
    public static float TimeTrialSecondsB = 52;
    public static int MaxLaps;
    public static bool RaceOver = false;
    public static int PlayerPosition;
    public static bool Gold = false;
    public static bool Silver = false;
    public static bool Bronze = false;
    public static bool Fail = false;
    public static int PenaltySeconds = 0;

    private void Start() {
    }

    private void Update() {
        if (!RaceOver) {
            if (LapChange) {
                LapChange = false;
                LapTimeSec = 0;
                LapTimeMin = 0;
                LapTimeMin = 0;
                GameTime = 0;
            }

            if (LapNb > 0) {
                LapTimeSec += Time.deltaTime;
                RaceTimeSec += Time.deltaTime;
                GameTime += Time.deltaTime;
                if (LapTimeSec > 59) {
                    LapTimeSec = 0;
                    LapTimeMin++;
                }

                if (RaceTimeSec > 59) {
                    RaceTimeSec = 0;
                    RaceTimeMin++;
                }
            }
        }
    }
}