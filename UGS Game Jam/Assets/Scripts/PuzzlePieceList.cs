using System;
using System.Collections.Generic;
using UnityEngine;


public class PuzzlePieceList : MonoBehaviour
{
    //God
    #region GodCode
    public static PuzzlePieceList _instance;

    public static PuzzlePieceList Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
    #endregion

    public List<Level> LevelList = new List<Level>();

    [Serializable]
    public class Level
    {
        public List<PuzzlePieceUses> PuzzlePieces = new List<PuzzlePieceUses>();

        [Serializable]
        public class PuzzlePieceUses
        {
            public GameObject Prefab;
            public int Uses = 1;
        }
    }
}