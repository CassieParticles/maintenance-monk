using UnityEditor;
using UnityEngine;

public class ReputationBar : MonoBehaviour {

    float visualReputation;
    [SerializeField][Range(0, 100)] float reputation = 50;

    [SerializeField] Vector3 MinRepPosition;
    [SerializeField] Vector3 MaxRepPosition;
    Vector3 gizmoSize = new Vector3(50f, 50f, 50f);
    GameObject ReputationArrow;
    [SerializeField] SecondOrderMovement<float> SOMreputation = new SecondOrderMovement<float>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReputationArrow = transform.GetChild(0).gameObject;
        SOMreputation.InitFunction(reputation);
    }

    // Update is called once per frame
    void Update()
    {
        visualReputation = SOMreputation.Update(Time.deltaTime, visualReputation, reputation);
        ReputationArrow.transform.localPosition = Vector3.LerpUnclamped(MinRepPosition, MaxRepPosition, visualReputation / 100);
    }

    /// <summary>
    /// Changes the reputation by an amount, this does not override, but adds the value to the current reputation.
    /// </summary>
    /// <param name="value"> The amount the reputation is changed by</param>
    public void ChangeReputation(float value) {
        reputation += value;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(MinRepPosition, gizmoSize);

        Gizmos.color = Color.green;
        Gizmos.DrawCube(MaxRepPosition, gizmoSize);
    }
}
