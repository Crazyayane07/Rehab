using UnityEngine;

namespace Rehab.Model.Content
{
    [CreateAssetMenu(menuName = "Content")]
    public class Content : ScriptableObject
    {
        public ActivityContent[] activities;
    }
}
