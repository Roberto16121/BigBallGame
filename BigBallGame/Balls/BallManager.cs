using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBallGame.Balls
{
    internal class BallManager
    {
        List<Ball> balls = new();
        int totalBalls = 0;
        int regularBalls = 0;
        int width, height;  
        Bitmap bmp;
        Graphics g;
        Panel gameWindow;

        static Random random = new Random();

        public BallManager(int nr, Panel gameWindow)
        {
            totalBalls = nr;
            this.gameWindow = gameWindow;
            width = gameWindow.Width;
            height = gameWindow.Height;
            Init();
            DrawBalls();
        }

        void Init()
        {
            SpawnBall(0);
            SpawnBall(0);
            SpawnBall(0);
            for (int i=3;i<totalBalls; i++) 
                SpawnBall(random.Next(0, 3));
    
        }

        Ball GetNextBall(int id)
        {
            switch (id)
            {
                case 0:
                    {
                        regularBalls++;
                        return new(width, height, BallType.Regular);
                    }
                case 1:
                    {
                        return new(width, height, BallType.Monster);
                    }
                case 2:
                    {
                        return new(width, height, BallType.Repelent);
                    }
            }
            return null;
        }

        void SpawnBall(int id)
        {
            Ball spawned = GetNextBall(id);            
            
            int iteration = 0;
            while (CheckCollisionWithBalls(spawned) != null || !IsInsideWindow(spawned))
            {
                spawned.Respawn();
                iteration++;
                if (iteration > 100)
                    break;
            }
            balls.Add(spawned);
        }

        Ball? CheckCollisionWithBalls(Ball toCheck)
        {
            Position pos = toCheck.Pozitie;
            float raza = toCheck.Raza;
            foreach(Ball b in balls)
            {
                if (b != toCheck)
                {

                    float distance = (float)Math.Sqrt(Math.Pow(b.Pozitie.X - pos.X, 2) + Math.Pow(b.Pozitie.Y - pos.Y, 2));
                    if (distance < (raza + b.Raza))
                        return b;
                }
            }
            return null;
        }

        bool IsInsideWindow(Ball toCheck)
        {
            Position pos = toCheck.Pozitie;
            float raza = toCheck.Raza;
            if (pos.X + raza >= width || pos.X - raza <= 0)
                return false;
            if (pos.Y + raza >= height || pos.Y - raza <= 0)
                return false;
            return true;
        }

        void DrawBalls()
        {
            bmp = new Bitmap(width, height);
            g = Graphics.FromImage(bmp);    
            foreach (Ball ball in balls)
            {
                ball.Draw(g, balls.IndexOf(ball));
            }
            gameWindow.BackgroundImage = bmp;
        }

        bool GameOver = false;

        public void GameLoop()
        {
            if (GameOver)
                return;
            UpdateBalls();
            gameWindow.BackgroundImage = null;
            bmp = new Bitmap(gameWindow.Width, gameWindow.Height);
            g = Graphics.FromImage(bmp);
            foreach (Ball ball in balls)
            {
                ball.Move();
            }
            DrawBalls();
            
            gameWindow.BackgroundImage = bmp;
        }

        bool Changed = false;
        void UpdateBalls()
        {
            Changed = false;
            foreach (Ball ball in balls)
            {
                Ball? b = CheckCollisionWithBalls(ball);
                if (b != null)
                {
                    GameLogic(ball, b);
                }
                if(Changed)
                    break;
            }
            if (Changed)
                UpdateBalls();
        }

        void GameLogic(Ball b1, Ball b2)
        {
            if(b1.Tip == BallType.Regular && b2.Tip == BallType.Regular)
            {
                if(b1.Raza > b2.Raza)
                {
                    b1.Raza += b2.Raza;
                    regularBalls--;
                    balls.Remove(b2);
                }
                else
                {
                    b2.Raza += b1.Raza;
                    regularBalls--;
                    balls.Remove(b1);
                }
                Changed = true;
            }
            else if(b1.Tip == BallType.Regular && b2.Tip == BallType.Monster)
            {
                b2.Raza += b1.Raza;
                regularBalls--;
                balls.Remove(b1);
                Changed = true;
            }
            else if(b1.Tip == BallType.Monster && b2.Tip == BallType.Regular)
            {
                b1.Raza += b2.Raza;
                regularBalls--;
                balls.Remove(b2);
                Changed = true;
            }
            else if(b1.Tip == BallType.Monster && b2.Tip == BallType.Monster)
            {
                balls.Remove(b1);
                Changed = true;
            }
            else if(b1.Tip == BallType.Repelent && b2.Tip == BallType.Regular)
            {
                b1.Culoare = b2.Culoare;
                b2.dy = -b2.dy;
                b2.dx = -b2.dx;

            }
            else if(b1.Tip == BallType.Regular && b2.Tip == BallType.Repelent)
            {
                b2.Culoare = b1.Culoare;
                b1.dy = -b1.dy;
                b1.dx = -b1.dx;
            }
            else if(b1.Tip == BallType.Repelent && b2.Tip == BallType.Monster)
            {
                b1.Raza /= 2;
                b1.dy = -b1.dy;
                b1.dx = -b1.dx;
            }
            else if(b1.Tip == BallType.Monster && b2.Tip == BallType.Repelent)
            {
                b2.Raza /= 2;
                b2.dy = -b2.dy;
                b2.dx = -b2.dx;
            }
            else if(b1.Tip == BallType.Repelent && b2.Tip == BallType.Repelent)
            {
                b1.Culoare = b2.Culoare;
                b1.dy = -b1.dy;
                b1.dx = -b1.dx;
                b2.dy = -b2.dy;
                b2.dx = -b2.dx;
            }
            if(b1.Raza < 5)
            {
                balls.Remove(b1);
                Changed = true;
            }
            if(b2.Raza < 5)
            {
                balls.Remove(b2);
                Changed = true;
            }
            if(regularBalls <= 0)
                GameOver = true;
        }
    }
}
