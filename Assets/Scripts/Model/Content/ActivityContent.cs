using UnityEngine;

namespace Rehab.Model.Content
{
    [CreateAssetMenu(menuName = "ActivityContent")]
    public class ActivityContent : ScriptableObject
    {
        public string activityName;
        public Sprite icon;
    }
}
