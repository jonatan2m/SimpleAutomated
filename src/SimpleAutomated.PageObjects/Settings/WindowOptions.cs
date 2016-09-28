using System.Drawing;

namespace SimpleAutomated.PageObjects.Settings
{
    public class WindowOptions
    {
        private readonly int SIZE_WIDTH = 1920;
        private readonly int SIZE_HEIGHT = 1080;

        private Size size;
        public Size Size
        {
            get
            {
                if (size == null) size = new Size(SIZE_WIDTH, SIZE_HEIGHT);
                return size;
            }
            set { size = value; }
        }
    }
}
