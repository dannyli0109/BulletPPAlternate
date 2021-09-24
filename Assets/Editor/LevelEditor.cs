using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{

    Level levelTarget;
    
    private void OnEnable()
    {
    }


    private void OnSceneGUI()
    {
        levelTarget = (Level)target;

        Event e = Event.current;
        HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

        Vector3[] polygonPoints = new Vector3[4];

        Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);

        Plane hPlane = new Plane(Vector3.up, Vector3.zero);
        // Plane.Raycast stores the distance from ray.origin to the hit point in this variable:
        float distance = 0;
        Vector3 pos = new Vector3(0, 0, 0);
        // if the ray hits the plane...
        if (hPlane.Raycast(ray, out distance))
        {
            // get the hit point:
            pos = ray.GetPoint(distance);
        }

        pos.x = Mathf.Floor(pos.x);
        pos.z = Mathf.Floor(pos.z);


        float cellWidth = levelTarget.cellSize.x;
        float cellHeigh = levelTarget.cellSize.y;

        polygonPoints[0] = new Vector3(pos.x - 0, 0, pos.z - 0);
        polygonPoints[1] = new Vector3(pos.x - 0 + cellWidth, 0, pos.z - 0);
        polygonPoints[2] = new Vector3(pos.x - 0 + cellWidth, 0, pos.z + cellHeigh - 0);
        polygonPoints[3] = new Vector3(pos.x - 0, 0, pos.z + cellHeigh - 0);


        Handles.color = Color.yellow * new Color(1f, 1f, 1f, 0.2f);
        Handles.DrawAAConvexPolygon(polygonPoints);
        if (e.type == EventType.MouseDown && e.button == 0)
        {
            GameObject tileObject = PrefabUtility.InstantiatePrefab(levelTarget.prefabs[(int)levelTarget.type]) as GameObject;
            tileObject.transform.SetParent(levelTarget.transform);
            tileObject.transform.position = new Vector3(pos.x + 1, pos.y, pos.z + 1);
            tileObject.transform.localRotation = Quaternion.Euler(0, levelTarget.rotation, 0);
            Undo.RegisterCreatedObjectUndo(tileObject, "Created game object");
        }
        SceneView.RepaintAll();
    }
}
