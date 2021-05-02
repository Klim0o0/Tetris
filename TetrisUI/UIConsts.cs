using SFML.Graphics;
using System.Collections.Generic;
using System.IO;

namespace TetrisUI
{
    public static class UIConsts
    {
        public const int CellLength = 32;
        //public static readonly Dictionary<BlockColor, Color> Colors = new();
        private static readonly string FontFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts);
        public readonly static Font Font = new(Path.Combine(FontFolder, "arial.ttf"));

        static UIConsts()
        {
            //Colors[BlockColor.Base] = Color.White;
            //Colors[BlockColor.Blue] = Color.Blue;
            //Colors[BlockColor.Green] = Color.Green;
            //Colors[BlockColor.LightBlue] = new Color(0, 127, 255);
            //Colors[BlockColor.Orange] = new Color(253, 106, 2);
            //Colors[BlockColor.Purple] = new Color(79, 15, 117);
            //Colors[BlockColor.Red] = Color.Red;
            //Colors[BlockColor.Yellow] = Color.Yellow;
        }
    }
}
