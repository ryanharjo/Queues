using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues_Harjo_Ryan
{
    public class Game
    {
        // Maximum number of players allowed (read-only)
        public int MaxPlayers { get; }

        // Current number of players in the game (read/write)
        public int CurrentPlayers { get; set; }

        // Constructor that initializes max and current players
        public Game(int maxPlayers, int currentPlayers)
        {
            MaxPlayers = maxPlayers;
            CurrentPlayers = currentPlayers;
        }

        // Removes one player from the game (decrements current players)
        public void KickPlayer()
        {
            if (CurrentPlayers > 0)
                CurrentPlayers--;
        }

        // Checks the player queue and moves players into the game if there's space
        public void CheckQueue(Queue<Player> queue)
        {
            if (CurrentPlayers < MaxPlayers)
            {
                if (queue.Count > 0)
                {
                    // Remove player from the queue and add to the game
                    Player playerJoining = queue.Dequeue();
                    Console.WriteLine($"{playerJoining} has joined the game.");
                    CurrentPlayers++;
                }
                else
                {
                    // No players waiting in the queue
                    Console.WriteLine("No Players in the Queue!");
                }
            }
        }
    }
}

