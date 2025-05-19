using UnityEngine;

public class WheelSlipValue : MonoBehaviour
{
    public WheelCollider WheelC;
    public float RoadForwardStiffness = 3.0f;
    public float TerrainForwardStiffness = 0.6f;
    public float RoadSidewaysStiffness = 1.1f;
    public float TerrainSidewaysStiffness = 0.2f;
    private bool isChanged;

    private void Start()
    {
        WheelC = GetComponent<WheelCollider>();
    }

    private void Update()
    {
        if (SaveScript.OntTheRoad && !isChanged)
        {
            isChanged = true;
            var fFrictionCurve = WheelC.forwardFriction;
            fFrictionCurve.stiffness = RoadForwardStiffness;
            WheelC.forwardFriction = fFrictionCurve;

            var sFrictionCurve = WheelC.sidewaysFriction;
            sFrictionCurve.stiffness = RoadSidewaysStiffness;
            WheelC.sidewaysFriction = sFrictionCurve;
        }

        if (SaveScript.OnTheTerrain && isChanged)
        {
            isChanged = false;
            var fFrictionCurve = WheelC.forwardFriction;
            fFrictionCurve.stiffness = TerrainForwardStiffness;
            WheelC.forwardFriction = fFrictionCurve;

            var sFrictionCurve = WheelC.sidewaysFriction;
            sFrictionCurve.stiffness = TerrainSidewaysStiffness;
            WheelC.sidewaysFriction = sFrictionCurve;
        }
    }
}