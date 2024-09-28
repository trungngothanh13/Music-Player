using System.Text.Json.Nodes;

namespace MusicPlayer;

public class songNode
{
    public string songName { get; set; }
    public songNode? next { get; set; }
    public songNode? previous { get; set; }

    public songNode(string _songName)
    {
        songName = _songName;
        next = null;
        previous = null;
    }
}
