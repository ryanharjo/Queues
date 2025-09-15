namespace Queues_Harjo_Ryan
{
    using System;
    using System.Collections.Generic;

    // Represents a multiplayer game
    public class Program
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
            Console.WriteLine("\nPlayers in Queue:");
            foreach (var player in playerQueue)
            {
                Console.WriteLine(player);
            }

            // Remove a player from the game
            game.KickPlayer();

            // Check the queue and add player if space is available
            game.CheckQueue(playerQueue);

            // Print the queue after processing
            Console.WriteLine("\nPlayers in Queue after CheckQueue:");
            foreach (var player in playerQueue)
            {
                Console.WriteLine(player);
            }
        }
    }
}






