using UnityEngine;

namespace Rehab.Model.Content
{
    [CreateAssetMenu(menuName = "Content/MiniGameContent")]
    public class MiniGameContent : ScriptableObject
    {
        public string gameName;
        public string gameDescription;
        public int difficulty;
        public Sprite gameImage;

        public Sprite[] helpers;
        public Sprite[] answers;
        public Sprite[] fakers;
    }
}
