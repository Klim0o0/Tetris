namespace TetrisLogic
{
    public class BlockColor
    {
        public static readonly BlockColor Base = new BlockColor(0, 0, 0);
        public static readonly BlockColor Blue = new BlockColor(0, 0, 255);
        public static readonly BlockColor LightBlue = new BlockColor(0, 255, 255);
        public static readonly BlockColor Red = new BlockColor(255, 0, 0);
        public static readonly BlockColor Orange = new BlockColor(255, 165, 0);
        public static readonly BlockColor Yellow = new BlockColor(255, 255, 0);
        public static readonly BlockColor Green = new BlockColor(0, 128, 0);
        public static readonly BlockColor Purple = new BlockColor(128, 0, 128);
        // Base,
        // Blue,
        // LightBlue,
        // Red,
        // Orange,
        // Yellow, 
        // Green,
        // Purple;
        private BlockColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

    }
}