using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuilderIO : MonoBehaviour 
{

    private int SelectionIndex;
    private PuzzlePieceList PuzzleExtension;
    private int SelectionIndexMax = 1;   


    private void Awake()
    {
        PuzzleExtension = PuzzlePieceList.Instance;
    }

    void Start()
    {
        
        SelectionIndexMax = PuzzleExtension.LevelList[SceneManager.GetActiveScene().buildIndex].PuzzlePieces.Count - 1;
        
    }

    private void Update()
    {
        
        //CreateHighlight();
        
        //left click make, right click destroy
        //based on current, show ghost
    }

    public void Create()
    {
        Instantiate(PuzzleExtension.LevelList[SceneManager.GetActiveScene().buildIndex].PuzzlePieces[SelectionIndex].Prefab, /*snappedPosition*/, /*selectedRotation*/);
    }

    public void SelectionChange(SelectionDirection selection)
    {
       if(selection == SelectionDirection.Left)
        {
            if(SelectionIndex == 0)
            {
                return;
            }
            SelectionIndex--;
        }
        else
        {
            if (SelectionIndex == SelectionIndexMax)
            {
                return;
            }
            SelectionIndex++;
        }
       
    }

    //changes count everytime it is placed



}
