using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._PuzzleGame.Scripts
{
    [CreateAssetMenu(menuName = "Create Level/Level Data")]
    public class LevelData : ScriptableObject
    {
        public Color Levelcolor;
        public int LevelIndex;

        //public void Tick()
        //{
        //    o que quiser rodar no update
        //}


    }
}
