using System;

namespace BigBallGame.Balls
{
    public class Ball
    {
        public float Raza {get; set; }
        public Position Pozitie { get; private set; }
        public CustomColor Culoare { get; set; }
        public double dx, dy;
        public BallType Tip { get; set; }

        static Random random = new();
        static int width, height;
        public Ball(int t_width, int t_height, BallType tip)
        {
            width = t_width;
            height = t_height;
            Raza = random.Next(10, 100);
            Pozitie = new Position(random.Next(0, width), random.Next(0, height));
            Culoare = new CustomColor();
            Tip = tip;
            if (tip == BallType.Monster)
            {
                dx = 0;
                dy = 0;
            }
            else
            {
                dx = random.Next(5, 25);
                dy = random.Next(5, 25);
                if(random.Next(0, 2) == 1)
                {
                    dx = -dx;
                }
                if(random.Next(0, 2) == 1)
                {
                    dy = -dy;
                }
            }
        }

        public void Respawn()
        {
            Pozitie = new Position(random.Next(0, width), random.Next(0, height));
            Raza = random.Next(10, 100);
        }

        public void Move()
        {
            if(Pozitie.X + Raza >= width || Pozitie.X - Raza <= 0)
            {
                dx = -dx;
            }
            if(Pozitie.Y + Raza >= height || Pozitie.Y - Raza <= 0)
            {
                dy = -dy;
            }
            float X = Pozitie.X + (float)dx;
            float Y = Pozitie.Y + (float)dy;
            Pozitie = new Position(X, Y);
        }


        public void Draw(Graphics g, int id)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(Culoare.r, Culoare.g, Culoare.b));
            g.FillEllipse(brush, Pozitie.X - Raza, Pozitie.Y - Raza, 2 * Raza, 2 * Raza);
            brush.Dispose();
        }

    }
}
