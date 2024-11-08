class KeypadInteraction
{
    public static TimeSpan endTime = DateTime.Now.TimeOfDay;

    public static void RunCommand()
    {
        while (PuzzleManager.attemptsLeft > 0)
        {
            Console.Clear();
            string textCode = PuzzleManager.ConvertCodeToString();
            Console.WriteLine($"Attempts left: {PuzzleManager.attemptsLeft}");

            string userCode = EnterCode.RunCommand();

            if (userCode != textCode && userCode.All(char.IsDigit) && userCode.Length.Equals(4))
            {
                Console.Clear();
                PuzzleManager.LoseAttempt();
                Console.WriteLine("Wrong code.");
                PressKeyToContinue.RunCommand();
                continue;
            }
            else if (userCode.Equals(textCode))
            {
                Highscore.AddAndPrintList();
                EndCredits.RunCommand();
                return;
            }

            switch (userCode)
            {
                case "inventory" or "inv":
                    CheckInventoryCommand.RunCommand();
                    break;

                case "help":
                    HelpCommand.RunCommand();
                    break;

                case "leave" or "":
                    return;

                default:
                    InvalidInput.RunCommand(userCode);
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine("Game Over");
        PressKeyToContinue.RunCommand();
        ExitCommand.RunCommand();
    }
}
