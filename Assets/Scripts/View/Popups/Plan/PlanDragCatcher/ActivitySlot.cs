using System;
using Rehab.Model;
using TMPro;
using UnityEngine.UI;

namespace Rehab.Popups.Plan
{
    public class ActivitySlot : MonoBehaviour2
    {
        public TMP_InputField timeField;
        public Image activityImage;

        private Activity activity;

        private Action onSetUp;

        public void Activate(Action onSetUp)
        {
            this.onSetUp = onSetUp;

            SetActive(true);
        }

        public bool IsReadyToAnimate()
        {
            return activity != null && timeField.text != "";
        }

        public void SetUp(Activity activity)
        {
            this.activity = activity;

            onSetUp();
            SetUpIcon();

            timeField.onValueChanged.AddListener(OnChangeTime);
        }

        private void OnChangeTime(string time)
        {            
            onSetUp();
        }

        private void SetUpIcon()
        {
            activityImage.sprite = activity.Icon;
        }

        public long GetActivityTime()
        {
            return long.Parse(timeField.text);
        }

        public void StartAnimation()
        {

        }
    }
}
