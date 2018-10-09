using UnityEngine;

namespace Rehab.Model.Content
{
    [CreateAssetMenu(menuName = "Content/Content")]
    public class Content : ScriptableObject
    {
        public ActivityContent[] activities;
        public MiniGameContent[] miniGames;
    }
}
