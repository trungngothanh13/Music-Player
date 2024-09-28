using System.Collections.Specialized;
using System.Text.Json.Nodes;

namespace MusicPlayer;

public class musicList
{
    private songNode? head;
    private songNode? tail;
    private songNode? current;


    public void AddSong(string songName)
    {
        var newNode = new songNode(songName);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            current = newNode;
            head.next = head;
            head.previous = head;
        }
        else
        {
            tail.next = newNode; // Cannot be null as it already contains songName
            newNode.previous = tail;
            tail = newNode;
            tail.next = head; // Make it circular
            head.previous = tail;
        }
    }
    public void ShowCurrentSong()
    {
        if (current != null)
        {
            Console.WriteLine("Current Song: " + current.songName);
        }
    }

    public void ShowNextSong()
    {
        if (current != null)
        {
            current = current.next; // Current nullity is checked
            Console.WriteLine("Now Playing: " + current.songName);
        }
    }

    public void ShowPreviousSong()
    {
        if (current != null)
        {
            current = current.previous; // Current nullity is checked
            Console.WriteLine("Now Playing: " + current.songName);
        }
    }

    public void DeleteSong(string songName)
    {
        if (head == null) return;

        songNode? temp = head;

        // Check if the head needs to be deleted
        if (temp.songName == songName)
        {
            if (head.next == head) head = null;
            else
            {
                tail.next = head.next;
                head.next.previous = tail;
                head = head.next;
            }
            return;
        }

        do
        {
            if (temp.next.songName == songName)
            {
                songNode nodeToDelete = temp.next; // Store the node to delete
                temp.next = nodeToDelete.next; // Bypass the node

                if (nodeToDelete == tail) tail = temp; // Update the tail reference
                else temp.next.previous = temp; // Set the next node's previous

                return;
            }
            temp = temp.next;
        } while (temp != head);

        Console.WriteLine("Song not found");
    }

    public void SongTraverse()
    {
        for (songNode? i = head; i != tail; i = i.next)
            Console.WriteLine(i.songName);
        Console.WriteLine(tail.songName);
    }
}
