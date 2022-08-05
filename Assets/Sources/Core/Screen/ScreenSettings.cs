namespace Sources.Core.Screen
{
    public static class ScreenSettings
    {
        public static int HeightScreen
        {
            get
            {
                return _heightScreen;
            }
        }

        public static int WidthScreen
        {
            get
            {
                return _widthScreen;
            }
        }

        public static int HalfHeightScreen
        {
            get
            {
                return _heightScreen / 2;
            }
        }

        public static int HalfWidthScreen
        {
            get
            {
                return _widthScreen / 2;
            }
        }
        public static int BorderOnLeft
        {
            get
            {
                return _borderOnLeftInPixels;
            }
        }

        public static int BorderOnRight
        {
            get
            {
                return _borderOnRightInPixels;
            }
        }
        
        private static readonly int _heightScreen;
        private static readonly int _widthScreen;

        private static readonly int _borderOnLeftInPixels;
        private static readonly int _borderOnRightInPixels;
        
        private const int _borderOnLeftInPercentage = 3;
        private const int _bordersOnRightInPercentage = 3;

        static ScreenSettings()
        {
            _heightScreen = UnityEngine.Screen.height;
            _widthScreen = UnityEngine.Screen.width;

            _borderOnLeftInPixels = GetBorderInPixels(_widthScreen, _borderOnLeftInPercentage);
            _borderOnRightInPixels = GetBorderInPixels(_widthScreen, _bordersOnRightInPercentage);
        }

        private static int GetBorderInPixels(int sideScreen, int percentage)
        {
            return sideScreen / 100 * percentage;
        }

    }
}