using Skypex.ExtensionMethods;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuilderIO : MonoBehaviour
{
    [SerializeField] private float maxBlockPlaceDistance = 20f;
    [SerializeField] private Vector3 snappingGrid = new Vector3(2.5f, 0.5f, 2.5f);
    [SerializeField] private Color ghostColor;

    private PuzzlePieceList _puzzleExtension;
    private int _selectionIndex;
    private int _selectionIndexMax = 1;
    private Vector3 _snappedPosition;
    private Quaternion _selectedRotation = Quaternion.identity;
    private GameObject _selectedObject;

    private void Awake() => _puzzleExtension = PuzzlePieceList.Instance;

    private void Start() => _selectionIndexMax = _puzzleExtension.LevelList[SceneManager.GetActiveScene().buildIndex].PuzzlePieces.Count - 1;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, maxBlockPlaceDistance))
        {
            _snappedPosition = SnapSelection(hitInfo.point, snappingGrid);
            _selectedObject = hitInfo.transform.gameObject;
        }
    }

    public void OnKey(MouseButton button)
    {
        if (button == MouseButton.LeftClick)
        { 
            Create();
            return;
        }

        Remove();
    }

    private void Create()
    {
        GameObject newBlock = Instantiate(_puzzleExtension.LevelList[SceneManager.GetActiveScene().buildIndex].PuzzlePieces[_selectionIndex].Prefab, _snappedPosition, _selectedRotation);
        newBlock.AddComponent<Removable>();
    }

    private void CreateGhost()
    {
        GameObject newBlock = Instantiate(_puzzleExtension.LevelList[SceneManager.GetActiveScene().buildIndex].PuzzlePieces[_selectionIndex].Prefab, _snappedPosition, _selectedRotation);
        Material blockMat = newBlock.GetComponent<Material>();
        blockMat.color = ghostColor;
    }

    private void Remove() => Destroy(_selectedObject);

    private void SelectionChange(SelectionDirection selection)
    {
       if(selection == SelectionDirection.Left)
        {
            if(_selectionIndex == 0)
                return;

            _selectionIndex--;
        }
        else
        {
            if (_selectionIndex == _selectionIndexMax)
                return;

            _selectionIndex++;
        }       
    }

    private static Vector3 SnapSelection(Vector3 position, Vector3 snapGrid) => position.Round(snapGrid);
}
