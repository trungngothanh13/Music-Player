using System.Text.Json.Nodes;

namespace MusicPlayer;

public class musicList
{
    private songNode? head;

    public void AddSong(string songName)
    {
        var newNode = new songNode(songName);
        if (head == null)
        {
            head = newNode;
            head.next = head; // Points to itself, creating a circular reference
        }
        else
        {
            var current = head;
            while (current?.next != head) // Traverse to the last node
            {
                current = current?.next;
            }
            current.next = newNode; // Link the new node
            newNode.next = head; // Make it circular
        }
    }
}
