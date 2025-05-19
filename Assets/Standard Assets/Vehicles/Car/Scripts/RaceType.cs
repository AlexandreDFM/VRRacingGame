using UnityEngine;

public class RaceType : MonoBehaviour {
    public bool TimeTrial = true;
    public float GoldMinutes;
    public float GoldSeconds;
    public float SilverMinutes;
    public float SilverSeconds;
    public float BronzeMinutes;
    public float BronzeSeconds;

    private void Start() {
        if (TimeTrial) {
            SaveScript.TimeTrialMinG = GoldMinutes;
            SaveScript.TimeTrialSecondsG = GoldSeconds;
            SaveScript.TimeTrialMinS = SilverMinutes;
            SaveScript.TimeTrialSecondsS = SilverSeconds;
            SaveScript.TimeTrialMinB = BronzeMinutes;
            SaveScript.TimeTrialSecondsB = BronzeSeconds;
        }
    }

    private void Update() {
        if (!SaveScript.RaceOver || !TimeTrial)
            return;

        UpdateRaceTime();

        if (IsGold()) {
            Debug.Log("Gold");
            SaveScript.Gold = true;
            return;
        }

        if (IsSilver()) {
            Debug.Log("Silver");
            SaveScript.Silver = true;
            return;
        }

        if (IsBronze()) {
            Debug.Log("Bronze");
            SaveScript.Bronze = true;
            return;
        }

        Debug.Log("Fail");
        SaveScript.Fail = true;
    }

    private void UpdateRaceTime() {
        float totalSeconds = SaveScript.RaceTimeSec + SaveScript.PenaltySeconds;

        if (totalSeconds > 59) {
            SaveScript.RaceTimeMin += totalSeconds / 60;
            SaveScript.RaceTimeSec = totalSeconds % 60;
        }
        else {
            SaveScript.RaceTimeSec = totalSeconds;
        }

        SaveScript.PenaltySeconds = 0;
    }

    private bool IsGold() {
        return SaveScript.RaceTimeMin < GoldMinutes ||
               (SaveScript.RaceTimeMin == GoldMinutes && SaveScript.RaceTimeSec < GoldSeconds);
    }

    private bool IsSilver() {
        return !SaveScript.Gold &&
               (SaveScript.RaceTimeMin < SilverMinutes ||
                (SaveScript.RaceTimeMin == SilverMinutes && SaveScript.RaceTimeSec < SilverSeconds));
    }

    private bool IsBronze() {
        return !SaveScript.Gold && !SaveScript.Silver &&
               (SaveScript.RaceTimeMin < BronzeMinutes ||
                (SaveScript.RaceTimeMin == BronzeMinutes && SaveScript.RaceTimeSec < BronzeSeconds));
    }
}