using System;
using System.Collections.Generic;
using System.Linq;

namespace G_Net_40_ADV03
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Execution Calls

            RunExercise1();
            RunExercise2();
            RunExercise3();
            RunExercise4();
            RunExercise5();
            RunExercise6();
            #endregion
        }

        #region Exercise 1: Student Grade Manager 
        static void RunExercise1()
        {
            Console.WriteLine("--- [EX 01] Student Grades ---");
            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

            Console.WriteLine($"Count: {grades.Count} | First: {grades[0]} | Last: {grades[^1]}");

            grades.Sort();
            Console.WriteLine($"Sorted: {string.Join(", ", grades)}");

            Console.WriteLine($"First > 90: {grades.FirstOrDefault(g => g > 90)}");

            var failing = grades.Where(g => g < 75).ToList();
            Console.WriteLine($"Failing (Below 75): {string.Join(", ", failing)}");

            grades.RemoveAll(g => g < 75);
            Console.WriteLine($"After Clean-up: {string.Join(", ", grades)}");

            Console.WriteLine($"Has 100? {grades.Contains(100)}");

            var formatted = grades.Select(g => $"Grade: {g}").ToList();
            Console.WriteLine(string.Join(" | ", formatted));
            Console.WriteLine();
        }
        #endregion

        #region Exercise 2: Leaderboard 
        static void RunExercise2()
        {
            Console.WriteLine("--- [EX 02] Leaderboard ---");
            SortedList<int, string> leaderboard = new SortedList<int, string>();
            leaderboard.Add(500, "Ahmed");
            leaderboard.Add(200, "Sara");
            leaderboard.Add(800, "Ali");
            leaderboard.Add(350, "Mona");

            foreach (var entry in leaderboard)
                Console.WriteLine($"[{entry.Key} pts] : {entry.Value}");

            Console.WriteLine($"First Key: {leaderboard.Keys[0]} | First Value: {leaderboard.Values[0]}");
            Console.WriteLine($"Exists 500? {leaderboard.ContainsKey(500)}");
            Console.WriteLine($"Score 999: {leaderboard.GetValueOrDefault(999, "Not Found")}");

            leaderboard.Remove(200);
            Console.WriteLine("Updated Leaderboard (Score 200 Removed)");
            foreach (var entry in leaderboard) Console.WriteLine($"- {entry.Value}");
            Console.WriteLine();
        }
        #endregion

        #region Exercise 3: Phone Book 
        static void RunExercise3()
        {
            Console.WriteLine("--- [EX 03] Phone Book ---");
            Dictionary<string, string> phoneBook = new Dictionary<string, string>
            {
                { "Ahmed", "010111" }, { "Sara", "010222" }, { "Ali", "010333" }, { "Mona", "010444" }
            };

            phoneBook["Zaki"] = "010555"; // Add if not exists, Update if exists

            try { phoneBook.Add("Ahmed", "010999"); }
            catch (ArgumentException ex) { Console.WriteLine($"Add Conflict: {ex.Message}"); }

            Console.WriteLine($"TryAdd Sara: {phoneBook.TryAdd("Sara", "010888")}");
            Console.WriteLine($"Omar in PhoneBook? {phoneBook.ContainsKey("Omar")}");
            Console.WriteLine($"Get Omar: {phoneBook.GetValueOrDefault("Omar", "Not Found")}");

            Console.WriteLine($"Keys: {string.Join(", ", phoneBook.Keys)}");
            Console.WriteLine($"Values: {string.Join(", ", phoneBook.Values)}");
            Console.WriteLine();
        }
        #endregion

        #region Exercise 4: Unique Email Validator 
        static void RunExercise4()
        {
            Console.WriteLine("--- [EX 04] Email Validator ---");
            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");

            Console.WriteLine($"Unique Emails Count: {emails.Count}");

            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

            var union = new HashSet<int>(setA); union.UnionWith(setB);
            var intersect = new HashSet<int>(setA); intersect.IntersectWith(setB);
            var except = new HashSet<int>(setA); except.ExceptWith(setB);

            Console.WriteLine($"Union: {string.Join(",", union)}");
            Console.WriteLine($"Intersect: {string.Join(",", intersect)}");
            Console.WriteLine($"Except: {string.Join(",", except)}");
            Console.WriteLine($"Is {{1,2}} subset of A? {new HashSet<int> { 1, 2 }.IsSubsetOf(setA)}");
            Console.WriteLine();
        }
        #endregion

        #region Exercise 5: Print Queue Simulator 
        static void RunExercise5()
        {
            Console.WriteLine("--- [EX 05] Print Queue ---");
            Queue<string> printer = new Queue<string>(new[] { "Report.pdf", "Invoice.pdf", "Letter.docx", "Resume.pdf", "Photo.jpg" });

            Console.WriteLine($"Items: {printer.Count} | Next: {printer.Peek()}");

            while (printer.Count > 0)
                Console.WriteLine($"Printing: {printer.Dequeue()}");

            Console.WriteLine($"TryDequeue empty: {printer.TryDequeue(out var doc)}");
            Console.WriteLine();
        }
        #endregion

        #region Exercise 6: Browser History 
        static void RunExercise6()
        {
            Console.WriteLine("--- [EX 06] Browser History ---");
            Stack<string> history = new Stack<string>(new[] { "google.com", "github.com", "stackoverflow.com", "youtube.com", "claude.ai" });

            Console.WriteLine($"Current Page: {history.Peek()}");
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"Going Back From: {history.Pop()}");

            Console.WriteLine($"Current Page Now: {history.Peek()}");
            history.Clear();
            Console.WriteLine($"TryPop on empty: {history.TryPop(out var url)}");
            Console.WriteLine();
        }
        #endregion
    }
}