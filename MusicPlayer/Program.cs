namespace MusicPlayer;

class Program
{
    static void Main(string[] args)
    {
        musicList List1 = new musicList();
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine();

        for (int i = 0; i < n; i++)
        {
            string? command = Console.ReadLine();
            string[] parts = command.Split(' ', 2); // Split the command and argument

            switch (parts[0])
            {
                case "ADD":
                    List1.AddSong(parts[1]);
                    break;
                case "NEXT":
                    List1.ShowNextSong();
                    break;
                case "PREVIOUS":
                    List1.ShowPreviousSong();
                    break;
                case "CURRENT":
                    List1.ShowCurrentSong();
                    break;
                case "DISPLAY":
                    List1.SongTraverse();
                    break;
                case "REMOVE":
                    List1.DeleteSong(parts[1]);
                    break;
            }
            Console.WriteLine();
        }
    }

}
