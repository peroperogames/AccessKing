namespace PeroTools2.AccessKing
{
    public struct ThemeNotification<TTheme> : INotification
    {
        public readonly TTheme theme;

        public ThemeNotification(TTheme theme)
        {
            this.theme = theme;
        }

        public static implicit operator ThemeNotification<TTheme>(TTheme theme)
        {
            return new ThemeNotification<TTheme>(theme);
        }
    }
}