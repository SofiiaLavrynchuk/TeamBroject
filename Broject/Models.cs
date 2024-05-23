using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broject
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public List<VoteResult> Results { get; set; }
        public override string ToString()
        {
            string info =
                $"Username: {Username}\n" +
                $"Password: {Password}\n";

            if (IsAdmin == true) info += "Is administrator\n";
            else info += "Is not administrator\n";

            info += "Results:\n";
            foreach (var res in Results)
                info += $"- Title: {res.PollTitle}, Percentage: {res.Percentage}\n";

            return info;
        }
    }

    public class Poll
    {
        public string Title { get; set; }
        public string Difficulty { get; set; }
        public List<Question> Questions { get; set; }
        public override string ToString()
        {
            string info = $"Title: {Title}\n" +
                $"Difficulty: {Difficulty}\n" +
                $"Count of questions: {Questions.Count}\n";

            return info;
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public List<string> CorrectOptions { get; set; }
        public override string ToString()
        {
            int i = 1;
            string info = $"Question: {Text}\nAnswer options:\n";
            foreach (var opt in Options) { info += $"{i} - {opt}\n"; i++; }

            return info;
        }
    }

    public class VoteResult
    {
        public string PollTitle { get; set; }
        public int QuesCount { get; set; }
        public int CorrAnswersCount { get; set; }
        public int WrongAnswersCount { get { return QuesCount - CorrAnswersCount; } }
        public int Percentage { get { return (100 / QuesCount * CorrAnswersCount); } }
        public int Attempts { get; set; }
        public bool CanRetake { get; set; }
        public override string ToString()
        {
            string info =
                $"Title: {PollTitle}\n" +
                $"Count of questions: {QuesCount}" +
                $"Correct / Wrong answers: {CorrAnswersCount} / {WrongAnswersCount}\n" +
                $"Percentage: {Percentage}%\n";

            return info;
        }
    }
}
