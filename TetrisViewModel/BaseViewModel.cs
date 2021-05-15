using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisViewModel
{
    public enum KeybordKey
    {
        A, W, S, D, Space
    }

    public enum MouseKey
    {
        L, M, R, ScrolUp, ScrolDown
    }

    public enum KeyEventType
    {
        Pressed, Realesed
    }

    public record Point(double X, double Y);
    public record DrawInfo(Point PercentagePosition, Size PercentageSize, Color Color, float Rotate, string Text, IEnumerable<DrawInfo> NestedDraw);
    public record Size(double Width, double Height);
    public record Color(byte R, byte G, byte B, byte A);
    public record UserAction(KeyEvent[] KeyEvents, MouseEvent[] MouseEvents);
    public record KeyEvent(KeybordKey Key, KeyEventType KeyEventType);
    public record MouseEvent(MouseKey Key, KeyEventType KeyEventType);

    public abstract class BaseViewModel
    {
        public abstract IEnumerable<DrawInfo> GetDrawInfo();

        public abstract void Update(UserAction userAction);
    }
}
