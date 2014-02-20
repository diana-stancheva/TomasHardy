namespace Ivo
{
    class StartProgram
    {
        static void Main()
        {
            string filePath = "../../Map level 1.txt";
            var mapHandling = new MapHandling(filePath);
            mapHandling.ReadFromFile();
            mapHandling.LoadMapOnScreen();

            var player = new PlayerMovement(mapHandling.MapMatrix);
            player.GetPlayerStartPosition();

            while (true)
            {
                player.Move();
            }
        }
    }
}