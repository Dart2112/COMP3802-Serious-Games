using UnityEngine;

namespace Puzzles.PhysioTherapy.Scripts
{
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets _i;
        public GameObject block;
        public GameObject block2;
        public GameObject block3;

        public static GameAssets i
        {
            get {
                if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();

                return _i;
            }
        }   

    }
}
