using System.Text.Json;

class KeypadInteraction
{
    public static TimeSpan endTime = DateTime.Now.TimeOfDay;
    public static void RunCommand()
    {
        // Story fluff here

        while (Program.attemptsLeft > 0)
        {
            Console.Clear();

            Console.WriteLine($"Attempts left: {Program.attemptsLeft}");

            string userCode = EnterCode.RunCommand();

            string textCode = "";

            foreach (int n in PuzzleManager.passwordNum)
            {
                textCode += n.ToString();
            }

            if (userCode.Equals("inventory") || userCode.Equals("inv"))
            {
                CheckInventoryCommand.RunCommand();
                continue;
            }
            else if (userCode.Equals("leave"))
            {
                return;
            }
            else if (userCode != textCode)
            {
                Console.Clear();
                Program.attemptsLeft--;
                Console.WriteLine("Wrong code.");
                PressKeyToContinue.RunCommand();
            }
            else if (userCode.Equals(textCode))
            {
                Console.Clear();
                Dialogue.PrintYouWin();

                string playerName = " ";

                while (true)
                {
                    Console.Clear();
                    Console.Write("Write your name (Exactly 3 letters): ");
                    playerName = Console.ReadLine()!;

                    if (playerName.Length == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nName must be 3 letters.");
                        PressKeyToContinue.RunCommand();
                    }
                }

                TimeSpan finalTime = endTime - Program.StartTime;

                Highscore highscore = new Highscore(playerName, finalTime);
                Highscore.highscoreList.Add(highscore);

                Highscore.highscoreList.Sort((time1, time2) => time1.Time.CompareTo(time2.Time));

                if (Highscore.highscoreList.Count == 11)
                {
                    Highscore.highscoreList.RemoveRange(10, 1);
                }

                JsonSerializerOptions json = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Highscore.highscoreList, json);
                File.WriteAllText("./Utilities/highscore.json", jsonString);

                Console.Clear();

                string tookHours;
                string tookMinutes;
                string result;

                for (int i = 0; i < Highscore.highscoreList.Count; i++)
                {
                    int hour = Highscore.highscoreList[i].Time.Hours;
                    int min = Highscore.highscoreList[i].Time.Minutes;
                    int sec = Highscore.highscoreList[i].Time.Seconds;
                    int hundredth = Highscore.highscoreList[i].Time.Milliseconds / 10;

                    tookHours = $"Place {i + 1} - {Highscore.highscoreList[i].Name}\t\tTime: {hour}h {min}min {sec},{hundredth}sec";
                    tookMinutes = $"Place {i + 1} - {Highscore.highscoreList[i].Name}\t\tTime: {min}min {sec},{hundredth}sec";

                    string r = hour > 0 ? tookHours : tookMinutes;

                    Console.WriteLine(r);
                }

                tookHours = $"\n\tYour time: {finalTime.Hours}h {finalTime.Minutes}min {finalTime.Seconds},{finalTime.Milliseconds / 10}sec!";
                tookMinutes = $"\n\tYour time: {finalTime.Minutes}min {finalTime.Seconds},{finalTime.Milliseconds / 10}sec";

                result = finalTime.Hours > 0 ? tookHours : tookMinutes;

                Color.TextGreen(result);
                
                Console.WriteLine();

                PressKeyToContinue.RunCommand();
                ExitCommand.RunCommand();
                return;
            }
        }
        Console.Clear();
        Console.WriteLine("Game Over");
        PressKeyToContinue.RunCommand();
        ExitCommand.RunCommand();
    }
}