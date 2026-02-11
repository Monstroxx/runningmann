using runningmann;
using Timer = System.Timers.Timer;

Timer timer = new(200);

Mann mann = new(0, 0);

Console.CursorVisible = false;
void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
{
    mann.Draw();
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