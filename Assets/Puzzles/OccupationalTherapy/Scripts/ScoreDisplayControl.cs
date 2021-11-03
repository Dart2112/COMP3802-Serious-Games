using UnityEngine;
using UnityEngine.UI;

namespace Puzzles.OT_Assets.Scripts
{
    public class ScoreDisplayControl : MonoBehaviour
    {
        public Text hitsText, missesText;

        // Start is called before the first frame update
        public void UpdateScores(int hits, int misses)
        {
            hitsText.text = hits + "";
            missesText.text = misses + "";
        }
    }
}