using runningmann;
using Timer = System.Timers.Timer;

Timer timer = new(200);

Mann mann = new(Console.WindowWidth/2, Console.WindowHeight - 3);
Designmann design = new Designmann();
List<Obstacle> obstacles = new();
Console.CursorVisible = false;
Console.Write($"Health: {mann.health}");
void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
{
    Obstacle obstacle = new(Console.WindowWidth-1, Console.WindowHeight-1, -1);
    mann.Draw();
    if (obstacle.spawn()) {
        obstacles.Add(obstacle);
    }
    obstacle.Move(obstacles);


    for (int i = 0; i < obstacles.Count; i++)
    {
        if (obstacles[i].x == mann.x && (obstacles[i].y == mann.y || obstacles[i].y == mann.y + 1 || obstacles[i].y == mann.y + 2))
        {
            obstacles.RemoveAt(i);
            mann.health --;
            Console.SetCursorPosition(0, 0);
            Console.Write($"Health: {mann.health}");
            if (mann.health == 0)
            {
                GameOver();
            }
        }
    }
}

void GameOver()
{
    Console.Clear();
    Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
    Console.Write("Game Over");
    timer.Stop();
}
void setupTimer()
{
    timer.Elapsed += Timer_Elapsed;
    timer.AutoReset = true;
    timer.Enabled = true;
}

setupTimer();
Console.ReadKey();

while (true)
{
    if (Console.KeyAvailable)
    {
        mann.HandleInput();
    }
    Thread.Sleep(10);
}