namespace Queues_Harjo_Ryan
{
    using System;
    using System.Collections.Generic;

    // Represents a multiplayer game
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
                    queue.Dequeue();
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

    // Represents a player in the game
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
                queue.Enqueue(this);
            }
            else
            {
                // Space available, join the game immediately
                Console.WriteLine("Joining Game");
                game.CurrentPlayers++;
            }
        }

        // Override ToString to display the GamerTag when printing the player
        public override string ToString()
        {
            return GamerTag;
        }
    }

    // Entry point of the program
    class Program
    {
        static void Main()
        {
            // Create a new game with max 50 players and 49 currently playing
            Game game = new Game(50, 49);

            // Create a queue to hold players waiting to join
            Queue<Player> playerQueue = new Queue<Player>();

            // Create four players with 100 health and unique gamer tags
            Player player1 = new Player(100, "PlayerOne");
            Player player2 = new Player(100, "PlayerTwo");
            Player player3 = new Player(100, "PlayerThree");
            Player player4 = new Player(100, "PlayerFour");

            // Each player tries to join the game or queue up
            player1.JoinGame(game, playerQueue);
            player2.JoinGame(game, playerQueue);
            player3.JoinGame(game, playerQueue);
            player4.JoinGame(game, playerQueue);

            // Print the current players waiting in the queue
            Console.WriteLine("Players in Queue");
            foreach (var player in playerQueue)
            {
                Console.WriteLine(player);
            }

            // Remove a player from the game
            game.KickPlayer();

            // Check the queue and add player if space is available
            game.CheckQueue(playerQueue);

            // Print the queue after processing
            Console.WriteLine("\nPlayers in Queue");
            foreach (var player in playerQueue)
            {
                Console.WriteLine(player);
            }
        }
    }





}
