namespace GreenVsRed
{
    using Game.Engine;

    public class StartUp
    {
        public static void Main()
        {
            IGame greenVsRed = new Game();
            greenVsRed.Start();
        }
    }
}
