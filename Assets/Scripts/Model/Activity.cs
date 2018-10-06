using UnityEngine;

namespace Rehab.Model
{
    public class Activity
    {
        private string activityName;
        private Sprite icon;

        public string ActivityName { get { return activityName; } }
        public Sprite Icon { get { return icon; } }

        public Activity(string activityName, Sprite icon)
        {
            this.activityName = activityName;
            this.icon = icon;
        }
    }
}
