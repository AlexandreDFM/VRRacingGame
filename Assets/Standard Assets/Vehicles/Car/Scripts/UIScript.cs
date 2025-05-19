using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    public Image Speedometer;
    public TMP_Text SpeedText;
    public TMP_Text GearText;
    public TMP_Text LapNbText;
    public TMP_Text TotalLapsText;
    public TMP_Text LapTimeMinText;
    public TMP_Text LapTimeSecText;
    public TMP_Text RaceTimeMinText;
    public TMP_Text RaceTimeSecText;
    public TMP_Text BestLapTimeMinText;
    public TMP_Text BestLapTimeSecText;
    public TMP_Text CheckPointTime;
    public TMP_Text WWText;
    public TMP_Text TotalCarsText;
    public TMP_Text PlayerPosition;

    public GameObject CheckPointDisplay;
    public GameObject NewLapRecord;
    public GameObject WrongWayText;
    public int TotalLaps = 3;
    public int TotalCars = 1;

    private void Start() {
        SaveScript.MaxLaps = TotalLaps;
        WrongWayText.SetActive(false);
        Speedometer.fillAmount = 0f;
        SpeedText.text = "0";
        GearText.text = "1";
        LapNbText.text = "0";
        TotalLapsText.text = "/" + TotalLaps;
        CheckPointDisplay.SetActive(false);
        NewLapRecord.SetActive(false);
        TotalCarsText.text = "/" + TotalCars;
        PlayerPosition.text = "1";
    }

    private void Update() {
        // Speedometer
        UpdateSpeedometer();
        UpdateLapInfo();

        // Checkpoints
        HandleCheckpoint(SaveScript.CheckPoint1, ref SaveScript.CheckPoint1, SaveScript.ThisCheckPoint1,
            SaveScript.LastCheckPoint1);
        HandleCheckpoint(SaveScript.CheckPoint2, ref SaveScript.CheckPoint2, SaveScript.ThisCheckPoint2,
            SaveScript.LastCheckPoint2);

        // Timer update
        TimeUpdate();
        WrongWayDraw();

        // Player position
        PlayerPosition.text = SaveScript.PlayerPosition.ToString();
    }

    private void WrongWayDraw() {
        if (SaveScript.WrongWay)
            WrongWayText.SetActive(true);
        else
            WrongWayText.SetActive(false);

        if (!SaveScript.WwTextReset)
            WWText.text = "WRONG WAY!";
        else
            WWText.text = " ";
    }

    private void UpdateSpeedometer() {
        Speedometer.fillAmount = SaveScript.Speed / SaveScript.TopSpeed;
        SpeedText.text = Mathf.Round(SaveScript.Speed).ToString();
        GearText.text = (SaveScript.Gear + 1).ToString();
    }

    private void UpdateLapInfo() {
        LapNbText.text = SaveScript.LapNb.ToString();
    }

    private void HandleCheckpoint(bool checkPointFlag, ref bool checkpointFlagVariable, float currentCheckPointTime,
        float lastCheckPointTime) {
        if (checkPointFlag) {
            checkpointFlagVariable = false;
            if (SaveScript.LapNb > 1) {
                CheckPointDisplay.SetActive(true);
                var timeDifference = currentCheckPointTime - lastCheckPointTime;

                if (timeDifference > 0) {
                    CheckPointTime.color = Color.red;
                    CheckPointTime.text = "-" + Mathf.Abs(timeDifference);
                }
                else {
                    CheckPointTime.color = Color.green;
                    CheckPointTime.text = "+" + Mathf.Abs(timeDifference);
                }

                StartCoroutine(CheckPointOff());
            }
        }
    }


    private void TimeUpdate() {
        // Best Lap Time
        if (SaveScript.LapChange) {
            if (SaveScript.LastLapTimeMin == SaveScript.BestLapTimeMin)
                if (SaveScript.LastLapTimeSec < SaveScript.BestLapTimeSec) {
                    SaveScript.BestLapTimeSec = SaveScript.LastLapTimeSec;
                    SaveScript.NewRecord = true;
                }

            if (SaveScript.LastLapTimeMin < SaveScript.BestLapTimeMin) {
                SaveScript.BestLapTimeMin = SaveScript.LastLapTimeMin;
                SaveScript.BestLapTimeSec = SaveScript.LastLapTimeSec;
                SaveScript.NewRecord = true;
            }
        }

        // Lap Time
        TimeDraw(SaveScript.LapTimeMin, SaveScript.LapTimeSec, LapTimeMinText, LapTimeSecText);
        TimeDraw(SaveScript.RaceTimeMin, SaveScript.RaceTimeSec, RaceTimeMinText, RaceTimeSecText);
        TimeDraw(SaveScript.BestLapTimeMin, SaveScript.BestLapTimeSec, BestLapTimeMinText, BestLapTimeSecText);

        if (SaveScript.NewRecord) {
            NewLapRecord.SetActive(true);
            StartCoroutine(LapRecordOff());
        }
    }

    private void TimeDraw(float min, float sec, TMP_Text MinText, TMP_Text SecText) {
        if (min <= 9)
            MinText.text = "0" + Mathf.Round(min) + ":";
        else if (min >= 10) MinText.text = Mathf.Round(min) + ":";

        if (sec <= 9)
            SecText.text = "0" + Mathf.Round(sec);
        else if (sec >= 10) SecText.text = Mathf.Round(sec).ToString();
    }

    private IEnumerator CheckPointOff() {
        yield return new WaitForSeconds(2);
        CheckPointDisplay.SetActive(false);
    }

    private IEnumerator LapRecordOff() {
        yield return new WaitForSeconds(2);
        NewLapRecord.SetActive(false);
        SaveScript.NewRecord = false;
    }
}