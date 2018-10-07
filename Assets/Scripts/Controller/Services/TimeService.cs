

namespace Rehab.Services
{
    public interface ITimeService
    {
        string TranslateTime(float time);
    }

    public class TimeService : ITimeService
    {
        public string TranslateTime(float time)
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            hours = (int)(time / 3600f);
            if(hours != 0)
                time -= hours * 3600;
            minutes = (int)(time / 60f);
            if (minutes != 0)
                time -= minutes * 60;
            seconds = (int)time;

            string hoursPart = hours == 0 ? "" : hours.ToString() + "h";
            string minutesPart = minutes == 0 ? "" : minutes.ToString() + "min";
            string secondsPart = seconds == 0 ? "" : seconds.ToString() + "sec";

            return hoursPart + " " + minutesPart + " " + secondsPart;
        }
    }
}
