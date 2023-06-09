using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(CoreAI))]
public class CoreAIEditor : Editor
{
    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        //calculate a circle 
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    private void OnSceneGUI()
    {
        CoreAI fov = (CoreAI)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov._FoVRadius);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov._FoVAngle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov._FoVAngle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov._FoVRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov._FoVRadius);

        CoreAI proximity = (CoreAI)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(proximity.transform.position, Vector3.up, Vector3.forward, 360, proximity._proximityRadius);

        Vector3 proxAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov._proximityAngle / 2);
        Vector3 proxAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov._proximityAngle / 2);

        Handles.color = Color.cyan;
        Handles.DrawLine(fov.transform.position, fov.transform.position + proxAngle01 * proximity._proximityRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + proxAngle02 * proximity._proximityRadius);

        if (fov._canSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, fov._player.transform.position);
        }
        if (proximity._canSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(proximity.transform.position, proximity._player.transform.position);
        }
      






    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
