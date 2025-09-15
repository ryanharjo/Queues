using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues_Harjo_Ryan
{
    public class Player
    {
        // Player's health (read/write)
        public int Health { get; set; }

        // Player's unique gamer tag (read-only)
        public string GamerTag { get; }

        // Constructor initializes health and gamer tag
        public Player(int health, string gamerTag)
        {
            Health = health;
            GamerTag = gamerTag;
        }

        // Attempts to join a game or queues if the game is full
        public void JoinGame(Game game, Queue<Player> queue)
        {
            if (game.CurrentPlayers == game.MaxPlayers)
            {
                // Game is full, add this player to the queue
                Console.WriteLine($"{GamerTag} is queued.");
                queue.Enqueue(this);
            }
            else
            {
                // Space available, join the game immediately
                Console.WriteLine($"{GamerTag} is joining the game.");
                game.CurrentPlayers++;
            }
        }

        // Override ToString to display the GamerTag when printing the player
        public override string ToString()
        {
            return GamerTag;
        }
    }
}

