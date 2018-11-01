
namespace Rehab.Model
{
    public class Result
    {
        private string email;
        private string date;
        private string gameName;
        private string timeResult;

        public string Email { get { return email; } }
        public string Date { get { return date; } }
        public string GameName { get { return gameName; } }
        public string TimeResult { get { return timeResult; } }
        
        public Result(string email, string date, string gameName, string timeResult)
        {
            this.email = email;
            this.date = date;
            this.gameName = gameName;
            this.timeResult = timeResult;
        }
    }
}
