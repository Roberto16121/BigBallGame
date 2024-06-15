using BigBallGame.Balls;

namespace BigBallGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BallManager ballManager;
        private void Form1_Load(object sender, EventArgs e)
        {
            StartDelay.Start();

        }

        private void StartDelay_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int nr = random.Next(10, 30);
            ballManager = new(nr, GameWindow);
            StartDelay.Stop();
            GameLoop.Start();
        }
        private void GameLoop_Tick(object sender, EventArgs e)
        {
            //Thread.Sleep(2000);
            ballManager.GameLoop();
        }
    }
}
