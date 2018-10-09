using UnityEngine;

namespace Rehab.Model.Content
{
    [CreateAssetMenu(menuName = "Content/ActivityContent")]
    public class ActivityContent : ScriptableObject
    {
        public string activityName;
        public Sprite icon;
    }
}
