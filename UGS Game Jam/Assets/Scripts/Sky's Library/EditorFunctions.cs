#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Skypex.ExtensionMethods;
using UnityEngine.Rendering;

namespace Skypex.EditorFunctions
{
    //Colors used in Unity
    public struct EditorColors
    {
        //Greyscale Colors from the Editor windows
        public static Color EditorToolbarBlack = new Color(0.09803922f, 0.09803922f, 0.09803922f, 1f);
        public static Color EditorOutlineBlack = new Color(0.1254902f, 0.1254902f, 0.1254902f, 1f);
        public static Color EditorSeperationLineBlack = new Color(0.1372549f, 0.1372549f, 0.1372549f, 1f);
        public static Color EditorObjectFieldGrey = new Color(0.1568628f, 0.1568628f, 0.1568628f, 1f);
        public static Color EditorTextFieldGrey = new Color(0.1647059f, 0.1647059f, 0.1647059f, 1f);
        public static Color EditorDarkBackgroundGrey = new Color(0.2078432f, 0.2078432f, 0.2078432f, 1f);
        public static Color EditorBackgroundGrey = new Color(0.2196079f, 0.2196079f, 0.2196079f, 1f);
        public static Color EditorHoverSelectionGrey = new Color(0.2666667f, 0.2666667f, 0.2666667f, 1f);
        public static Color EditorBackgroundSelectedGrey = new Color(0.3019608f, 0.3019608f, 0.3019608f, 1f);
        public static Color EditorButtonGrey = new Color(0.3176471f, 0.3176471f, 0.3176471f, 1f);
        
        //Colors from the Editor windows
        public static Color EditorTextWhite = new Color(0.8980393f, 0.8980393f, 0.8980393f, 1f);
        public static Color EditorSelectedBlue = new Color(0.17254901f, 0.36470588f, 0.52941176f, 1f);

        //Colors from Prefabs
        public static Color PrefabTextBlue = new Color(0.4745098f, 0.6509804f, 0.909804f, 1f);
        public static Color PrefabIconBlue = new Color(0.4980392f, 0.8392158f, 0.9921569f, 1f);

        //Colors from the Console
        public static Color ConsoleErrorRed = new Color(1f, 0.3254902f, 0.2901961f, 1f);
        public static Color ConsoleWarningYellow = new Color(1f, 0.7568628f, 0.02745098f, 1f);
        public static Color ConsoleLogWhite = new Color(0.9411765f, 0.9411765f, 0.9411765f, 1f);
    }

    public struct Colors
    {
        //Transparent Colors
        private const float TRANSPARENCY = 0.5f;
        public static Color GhostWhite = Color.white.With(a: TRANSPARENCY);
        public static Color GhostBlack = Color.black.With(a: TRANSPARENCY);
        public static Color GhostBlue = Color.blue.With(a: TRANSPARENCY);
        public static Color GhostCyan = Color.cyan.With(a: TRANSPARENCY);
        public static Color GhostGray = Color.gray.With(a: TRANSPARENCY);
        public static Color GhostGrey = Color.grey.With(a: TRANSPARENCY);
        public static Color GhostMagenta = Color.magenta.With(a: TRANSPARENCY);
        public static Color GhostRed = Color.red.With(a: TRANSPARENCY);
        public static Color GhostYellow = Color.yellow.With(a: TRANSPARENCY);
    }

    //Draw Functions for Unity UI Elements
    public static class DrawEditor
    {
        //Line
        public static void Line(int thickness = 2, int padding = 10, Color? color = null)
        {
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
            rect.height = thickness;
            rect.y += padding / 2;
            rect.x -= 2;
            rect.width += 6;
            EditorGUI.DrawRect(rect, color ?? EditorColors.EditorSeperationLineBlack);
        }
    }

    //Draw Functions for the sceneview
    public static class Draw
    {
        //Color
        private static void SetColor(Color? color = null)
        {
            Handles.color = color ?? Color.white;
            Gizmos.color = color ?? Color.white;
        }
        private static void SetGhostColor(Color? color = null)
        {
            const float TRANSPARENCY = 0.5f;
            Handles.color = color ?? Color.white.With(a: TRANSPARENCY);
            Gizmos.color = color ?? Color.white.With(a: TRANSPARENCY);
        }

        //Lines
        public static void Line(params Vector3[] points) => 
            Handles.DrawAAPolyLine(points);

        public static void Line(float thickness, params Vector3[] points) => 
            Handles.DrawAAPolyLine(thickness, points);

        public static void Line(Color? color = null, params Vector3[] points)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Handles.DrawAAPolyLine(points);
            SetColor(defaultColor);
        }

        public static void Line(float thickness, Color? color = null, params Vector3[] points)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Handles.DrawAAPolyLine(thickness, points);
            SetColor(defaultColor);
        }

        public static void Line(Vector3 origin, Vector3 direction, float distance) =>
            Handles.DrawAAPolyLine(origin, origin.DirectionTo3D(direction).normalized * distance);

        public static void Line(float thickness, Vector3 origin, Vector3 direction, float distance) =>
            Handles.DrawAAPolyLine(thickness, origin, origin.DirectionTo3D(direction).normalized * distance);

        public static void Line(Vector3 origin, Vector3 direction, float distance, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Handles.DrawAAPolyLine(origin, origin.DirectionTo3D(direction).normalized * distance);
            SetColor(defaultColor);
        }

        public static void Line(float thickness, Vector3 origin, Vector3 direction, float distance, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Handles.DrawAAPolyLine(thickness, origin, origin.DirectionTo3D(direction).normalized * distance);
            SetColor(defaultColor);
        }

        //Dotted Lines
        public static void DottedLine(Vector3 p1, Vector3 p2)
        {
            Handles.DrawDottedLine(p1, p2, 5f);
        }

        public static void DottedLine(Vector3 p1, Vector3 p2, float screenSpaceSize)
        {
            Handles.DrawDottedLine(p1, p2, screenSpaceSize);
        }

        public static void DottedLine(Vector3 p1, Vector3 p2, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Handles.DrawDottedLine(p1, p2, 5f);
            SetColor(defaultColor);
        }

        public static void DottedLine(Vector3 p1, Vector3 p2, float screenSpaceSize, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Handles.DrawDottedLine(p1, p2, screenSpaceSize);
            SetColor(defaultColor);
        }

        //Bezier Curves
        public static void Bezier(Vector3 startPosition, Vector3 endPosition, float curviness = .5f, float thickness = 1f, Color? color = null)
        {
            Vector3 startTangent;
            Vector3 endTangent;

            curviness = curviness.MinMax(0f, 1f);

            float yDistance = startPosition.y - endPosition.y;

            startTangent = startPosition.With(y: (startPosition.y - yDistance * curviness));
            endTangent = endPosition.With(y: (endPosition.y + yDistance * curviness));

            Handles.DrawBezier(startPosition, endPosition, startTangent, endTangent, color ?? Color.white, Texture2D.whiteTexture, thickness);
        }

        //Circles
        public static void Circle(Vector3 center, Vector3 normal, float radius, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Handles.DrawWireDisc(center, normal, radius);
            SetColor(defaultColor);
        }
        public static void Circle(Vector3 center, Vector3 normal, float radius, float thickness = 1f, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Handles.DrawWireDisc(center, normal, radius, thickness);
            SetColor(defaultColor);
        }

        //Arcs 
        public static void Arc(Vector3 center, Vector3 normal, Vector3 from, float angle, float radius, float thickness = 1f, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Handles.DrawWireArc(center, normal, from, angle, radius, thickness = 1f);
            SetColor(defaultColor);
        }

        //Cubes 
        public static void Cube(Vector3 center, Vector3 size, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Handles.DrawWireCube(center, size);
            SetColor(defaultColor);
        }

        //Spheres 
        public static void Sphere(Vector3 center, float radius, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Gizmos.DrawWireSphere(center, radius);
            SetColor(defaultColor);
        }

        //Rays 
        public static void Ray(Ray ray, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Gizmos.DrawRay(ray);
            SetColor(defaultColor);
        }
        public static void Ray(Vector3 from, Vector3 direction, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Gizmos.DrawRay(from, direction);
            SetColor(defaultColor);
        }

        //Meshes
        public static void Mesh(Mesh mesh, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetGhostColor(color);
            Gizmos.DrawMesh(mesh);
            SetColor(defaultColor);
        }
        public static void Mesh(Mesh mesh, Vector3 position, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetGhostColor(color);
            Gizmos.DrawMesh(mesh, position);
            SetColor(defaultColor);
        }
        public static void Mesh(Mesh mesh, Vector3 position, Quaternion rotation, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetGhostColor(color);
            Gizmos.DrawMesh(mesh, position, rotation);
            SetColor(defaultColor);
        }
        public static void Mesh(Mesh mesh, Vector3? position = null, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetGhostColor(color);
            Gizmos.DrawMesh(mesh, position ?? Vector3.zero, rotation ?? Quaternion.identity, scale ?? Vector3.one);
            SetColor(defaultColor);
        }
        public static void Mesh(Mesh mesh, int submeshIndex, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetGhostColor(color);
            Gizmos.DrawMesh(mesh, submeshIndex);
            SetColor(defaultColor);
        }
        public static void Mesh(Mesh mesh, int submeshIndex, Vector3 position, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetGhostColor(color);
            Gizmos.DrawMesh(mesh, submeshIndex, position);
            SetColor(defaultColor);
        }
        public static void Mesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetGhostColor(color);
            Gizmos.DrawMesh(mesh, submeshIndex, position, rotation);
            SetColor(defaultColor);
        }
        public static void Mesh(Mesh mesh, int submeshIndex, Vector3? position = null, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetGhostColor(color);
            Gizmos.DrawMesh(mesh, submeshIndex, position ?? Vector3.zero, rotation ?? Quaternion.identity, scale ?? Vector3.one);
            SetColor(defaultColor);
        }

        //Wire Meshes
        public static void WireMesh(Mesh mesh, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Gizmos.DrawWireMesh(mesh);
            SetColor(defaultColor);
        }
        public static void WireMesh(Mesh mesh, Vector3 position, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Gizmos.DrawWireMesh(mesh, position);
            SetColor(defaultColor);
        }
        public static void WireMesh(Mesh mesh, Vector3 position, Quaternion rotation, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Gizmos.DrawWireMesh(mesh, position, rotation);
            SetColor(defaultColor);
        }
        public static void WireMesh(Mesh mesh, Vector3? position = null, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Gizmos.DrawWireMesh(mesh, position ?? Vector3.zero, rotation ?? Quaternion.identity, scale ?? Vector3.one);
            SetColor(defaultColor);
        }
        public static void WireMesh(Mesh mesh, int submeshIndex, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Gizmos.DrawWireMesh(mesh, submeshIndex);
            SetColor(defaultColor);
        }
        public static void WireMesh(Mesh mesh, int submeshIndex, Vector3 position, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Gizmos.DrawWireMesh(mesh, submeshIndex, position);
            SetColor(defaultColor);
        }
        public static void WireMesh(Mesh mesh, int submeshIndex, Vector3 position, Quaternion rotation, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Gizmos.DrawWireMesh(mesh, submeshIndex, position, rotation);
            SetColor(defaultColor);
        }
        public static void WireMesh(Mesh mesh, int submeshIndex, Vector3? position = null, Quaternion? rotation = null, Vector3? scale = null, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);
            Gizmos.DrawWireMesh(mesh, submeshIndex, position ?? Vector3.zero, rotation ?? Quaternion.identity, scale ?? Vector3.one);
            SetColor(defaultColor);
        }

        //Miscellaneous
        /// <summary>
        /// Project a line on a surface along its normal using the sceneview center.
        /// </summary>
        /// <param name="sceneView"></param>
        /// <param name="thickness"></param>
        /// <param name="color"></param>
        public static void LineOnSurface(SceneView sceneView, float thickness, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);

            Transform camTf = sceneView.camera.transform;

            Ray ray = new Ray(camTf.position, camTf.forward);
            if (Physics.Raycast(ray, out RaycastHit hit))
                Line(thickness, color, hit.point, hit.normal);

            SetColor(defaultColor);
        }

        /// <summary>
        /// Project a circle on a surface around its normal using the sceneview center.
        /// </summary>
        /// <param name="sceneView"></param>
        /// <param name="radius"></param>
        /// <param name="thickness"></param>
        /// <param name="color"></param>
        public static void CircleOnSurface(SceneView sceneView, float radius, float thickness, Color? color = null)
        {
            Color defaultColor = Handles.color;
            SetColor(color);

            Transform camTf = sceneView.camera.transform;

            Ray ray = new Ray(camTf.position, camTf.forward);
            if (Physics.Raycast(ray, out RaycastHit hit))
                Circle(hit.point, hit.normal, radius, thickness, color);

            SetColor(defaultColor);
        }                
        
        /// <summary>
        /// Draw lines behind meshes in the scene.
        /// NB! Only works for the Handle class! Not the Gizmos class.
        /// </summary>
        public static void Behind() =>
            Handles.zTest = CompareFunction.LessEqual;
        public static void InFront() =>
            Handles.zTest = CompareFunction.Always;
        public static void Mask() =>
            Handles.zTest = CompareFunction.GreaterEqual;
    }
}
#endif