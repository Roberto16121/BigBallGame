using System;
namespace BigBallGame.Balls
{
    public enum BallType
    { 
        Regular,
        Monster,
        Repelent
    }
    public struct Position
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Position(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    public class CustomColor
    {
        public int r, g, b;
        static Random random= new ();
        public CustomColor()
        {
            this.r = random.Next(0, 255);
            this.g = random.Next(0, 255);
            this.b = random.Next(0, 255);
        }
    }
}
