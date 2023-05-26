namespace PeroTools2.AccessKing
{
    public class ThemeEventBus<TTheme> : EventBus<ThemeNotification<TTheme>> where TTheme : new()
    {
        
    }
}