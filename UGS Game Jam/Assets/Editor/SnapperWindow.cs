using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Skypex.ExtensionMethods;

public class SnapperWindow : EditorWindow
{
    [MenuItem("Tools/Snapper %#&S")]
    public static void OpenWindow() => GetWindow<SnapperWindow>("Snapper");

    SerializedObject _so;
    SerializedProperty _propGridSize;
    SerializedProperty _propGridDrawExtent;

    [SerializeField]
    private float _gridSize = 1f;
    [SerializeField]
    private float _gridDrawExtent = 16f;

    private bool _drawGrid = true;
    private bool _drawXYGrid = true;
    private bool _drawXZGrid = false;
    private bool _drawYZGrid = false;
    private int _gridPlaneIndex;
    private int _gridScaleIndex;
    private bool _gridXRay = false;

    private readonly string[] GridPlane =
    {
        "XY",
        "XZ",
        "YZ"
    };

    private readonly string[] GridScale =
    {
        "Small",
        "Medium",
        "Big",
        "Large",
        "Massive"
    };

    private void OnEnable()
    {
        _so = new SerializedObject(this);
        _propGridSize = _so.FindProperty("_gridSize");
        _propGridDrawExtent = _so.FindProperty("_gridDrawExtent");

        Selection.selectionChanged += Repaint;
        SceneView.duringSceneGui += DuringSceneGUI;

        //Load saved data
        LoadData();
    }

    private void OnDestroy()
    {
        Selection.selectionChanged -= Repaint;
        SceneView.duringSceneGui -= DuringSceneGUI;

        //Save data
        SaveData();
    }

    private void OnGUI()
    {
        _so.Update();
        
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Scale", GUILayout.Width(35));
            _gridScaleIndex = EditorGUILayout.Popup(_gridScaleIndex, GridScale, GUILayout.Width(68));

            GUILayout.Label("Grid Size", GUILayout.Width(59));
            EditorGUILayout.PropertyField(_propGridSize, GUIContent.none);

            GUILayout.Label("Grid Draw Extent", GUILayout.Width(97));
            EditorGUILayout.PropertyField(_propGridDrawExtent, GUIContent.none);
        }

        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Plane", GUILayout.Width(35));
            _gridPlaneIndex = EditorGUILayout.Popup(_gridPlaneIndex, GridPlane, GUILayout.Width(68));
            GUILayout.Label("Draw Grid", GUILayout.Width(59));
            _drawGrid = EditorGUILayout.Toggle(_drawGrid, GUILayout.Width(14));

            GUILayout.FlexibleSpace();

            if (GUILayout.Button("XRay Lines", GUILayout.MinWidth(100)))
            {
                ToggleGridXRay();
            }

            if (GUILayout.Button("Save", GUILayout.MinWidth(100)))
            {
                SaveData();
            }
        }

        using (new EditorGUI.DisabledScope(Selection.gameObjects.Length == 0))
        {
            if (GUILayout.Button("Snap Selection"))
            {
                SnapSelection();
            }
        }

        _so.ApplyModifiedProperties();

        switch (_gridScaleIndex)
        {
            case 0:
                _gridDrawExtent = _gridDrawExtent.MinMax(0.1f, 4f);
                _gridSize = _gridSize.MinMax(.01f, 1f);
                break;

            case 1:
                _gridDrawExtent = _gridDrawExtent.MinMax(1f, 16f);
                _gridSize = _gridSize.MinMax(.04f, 4f);
                break;

            case 2:
                _gridDrawExtent = _gridDrawExtent.MinMax(4f, 64f);
                _gridSize = _gridSize.MinMax(1f, 16f);
                break;

            case 3:
                _gridDrawExtent = _gridDrawExtent.MinMax(16f, 256f);
                _gridSize = _gridSize.MinMax(4f, 64f);
                break;

            case 4:
                _gridDrawExtent = _gridDrawExtent.MinMax(64f, 1024f);
                _gridSize = _gridSize.MinMax(16f, 256f);
                break;
        }

        switch (_gridPlaneIndex)
        {
            case 0:
                _drawXYGrid = true;
                _drawXZGrid = false;
                _drawYZGrid = false;                
                SceneView.RepaintAll();
                break;

            case 1:
                _drawXYGrid = false;
                _drawXZGrid = true;
                _drawYZGrid = false;
                SceneView.RepaintAll();
                break;

            case 2:
                _drawXYGrid = false;
                _drawXZGrid = false;
                _drawYZGrid = true;
                SceneView.RepaintAll();
                break;
        }        

    }

    private void DuringSceneGUI(SceneView sceneView)
    {
        Handles.zTest = CompareFunction.LessEqual;

        int lineCount = Mathf.RoundToInt((_gridDrawExtent * 2) / _gridSize);
        if (lineCount % 2 == 0)
            lineCount++;
        int halfLineCount = lineCount / 2;

        if (!_drawGrid)
            return;

        //Draw XY Plane Lines
        if (_drawXYGrid)
            DrawXYLines(lineCount, halfLineCount);

        //Draw XZ Plane Lines
        if (_drawXZGrid)
            DrawXZLines(lineCount, halfLineCount);

        //Draw YZ Plane Lines
        if (_drawYZGrid)
            DraYZLines(lineCount, halfLineCount);
    }

    private void DrawXYLines(int lineCount, int halfLineCount)
    {
        for (int i = 0; i < lineCount; i++)
        {
            int intOffset = i - halfLineCount;
            float xCoord = intOffset * _gridSize;
            float yCoord = halfLineCount * _gridSize;
            float yCoordNegative = -halfLineCount * _gridSize;

            Vector3 point;
            Vector3 pointNegative;
            Vector3 worldOffset = Selection.transforms.Positions().Average().Round(_gridSize);

            //Draw Y Axis Lines
            point = new Vector3(xCoord + worldOffset.x, yCoord + worldOffset.y, worldOffset.z);
            pointNegative = new Vector3(xCoord + worldOffset.x, yCoordNegative + worldOffset.y, worldOffset.z);
            Handles.DrawAAPolyLine(point, pointNegative);

            //Draw X Axis Lines
            point = new Vector3(yCoord + worldOffset.x, xCoord + worldOffset.y, worldOffset.z);
            pointNegative = new Vector3(yCoordNegative + worldOffset.x, xCoord + worldOffset.y, worldOffset.z);
            Handles.DrawAAPolyLine(point, pointNegative);
        }
    }

    private void DrawXZLines(int lineCount, int halfLineCount)
    {
        for (int i = 0; i < lineCount; i++)
        {
            int intOffset = i - halfLineCount;
            float xCoord = intOffset * _gridSize;
            float zCoord = halfLineCount * _gridSize;
            float zCoordNegative = -halfLineCount * _gridSize;

            Vector3 point;
            Vector3 pointNegative;
            Vector3 worldOffset = Selection.transforms.Positions().Average().Round(_gridSize);

            //Draw Z Axis Lines
            point = new Vector3(xCoord + worldOffset.x, worldOffset.y, zCoord + worldOffset.z);
            pointNegative = new Vector3(xCoord + worldOffset.x, worldOffset.y, zCoordNegative + worldOffset.z);
            Handles.DrawAAPolyLine(point, pointNegative);

            //Draw X Axis Lines
            point = new Vector3(zCoord + worldOffset.x, worldOffset.y, xCoord + worldOffset.z);
            pointNegative = new Vector3(zCoordNegative + worldOffset.x, worldOffset.y, xCoord + worldOffset.z);
            Handles.DrawAAPolyLine(point, pointNegative);
        }
    }

    private void DraYZLines(int lineCount, int halfLineCount)
    {
        for (int i = 0; i < lineCount; i++)
        {
            int intOffset = i - halfLineCount;
            float yCoord = intOffset * _gridSize;
            float zCoord = halfLineCount * _gridSize;
            float zCoordNegative = -halfLineCount * _gridSize;

            Vector3 point;
            Vector3 pointNegative;
            Vector3 worldOffset = Selection.transforms.Positions().Average().Round(_gridSize);

            //Draw Z Axis Lines            
            point = new Vector3(worldOffset.x, yCoord + worldOffset.y, zCoord + worldOffset.z);
            pointNegative = new Vector3(worldOffset.x, yCoord + worldOffset.y, zCoordNegative + worldOffset.z);
            Handles.DrawAAPolyLine(point, pointNegative);


            //Draw Y Axis Lines            
            point = new Vector3(worldOffset.x, zCoord + worldOffset.y, yCoord + worldOffset.z);
            pointNegative = new Vector3(worldOffset.x, zCoordNegative + worldOffset.y, yCoord + worldOffset.z);
            Handles.DrawAAPolyLine(point, pointNegative);
        }
    }

    private void SnapSelection()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RecordObject(obj.transform, "Snap Objects");
            obj.transform.position = obj.GetPosition().Round(_gridSize);
        }
    }

    private void ToggleGridXRay() => _gridXRay ^= true;

    private void LoadData()
    {
        _gridScaleIndex = EditorPrefs.GetInt("SNAPPER_TOOL_GridScaleIndex", 0);
        _gridSize = EditorPrefs.GetFloat("SNAPPER_TOOL_GridSize", 1f);
        _gridDrawExtent = EditorPrefs.GetFloat("SNAPPER_TOOL_GridDrawExtent", 16f);
        _gridPlaneIndex = EditorPrefs.GetInt("SNAPPER_TOOL_GridPlaneIndex", 3);
    }

    private void SaveData()
    {
        EditorPrefs.SetInt("SNAPPER_TOOL_GridScaleIndex", _gridScaleIndex);
        EditorPrefs.SetFloat("SNAPPER_TOOL_GridSize", _gridSize);
        EditorPrefs.SetFloat("SNAPPER_TOOL_GridDrawExtent", _gridDrawExtent);
        EditorPrefs.SetInt("SNAPPER_TOOL_GridPlaneIndex", _gridPlaneIndex);
    }
}
