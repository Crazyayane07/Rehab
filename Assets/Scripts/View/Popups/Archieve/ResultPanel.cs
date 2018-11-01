using System;
using Rehab.Model;
using TMPro;

namespace Rehab.Popups.Archieve
{
    public class ResultPanel : MonoBehaviour2
    {
        public TextMeshProUGUI dateText;
        public TextMeshProUGUI gameNameYext;
        public TextMeshProUGUI resultText;

        private Result result;

        public void SetUp(Result result)
        {
            this.result = result;
            SetTexts();

            SetActive(true);
        }

        private void SetTexts()
        {
            dateText.text = result.Date;
            gameNameYext.text = result.GameName;
            resultText.text = result.TimeResult;
        }
    }
}
