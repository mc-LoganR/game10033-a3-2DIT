// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    /// 

    //Classes
    public class Watermelon()
    {
        // Public Variables
        public Color rind;
        public float x;
        public float y;

        public void Update()
        {
            // Watermelon template
            Draw.FillColor = rind;
            Draw.Ellipse(x, y, 140, 90);
        }
    }

    public class Banana()
    {
        // Public Variables
        public Color skin;
        public float x;
        public float y;

        public void Update()
        {
            // Banana template
            Draw.FillColor = skin;
            // IMPORTANT: Turn this into banana shape Draw.Arc();
        }
    }
    public class Orange()
    {
        // Public Variables
        public Color peel;
        public float x;
        public float y;

        public void Update()
        {
            // Orange template
            Draw.FillColor = peel;
            Draw.Circle(0, 0, 20);
        }
    }
    public class Game
    {
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        ///

        // Variables for player control
        float positionX;
        float positionY;

        // Fruit Colors
        Color watermelonGreen = new Color(31, 132, 0);
        Color bananaYellow = new Color(225, 225, 0);
        Color orangeOrange = new Color(242, 133, 0);
        Color badRed = new Color(132, 2, 0);

        public void Setup()
        {
            // Window
            Window.SetTitle("Food Fighter");
            Window.SetSize(800, 600);
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        
        public void Update()
        {
            // Dark brown background
            Window.ClearBackground(101, 67, 33);

            // Variables
            float inputX = 0;
            float inputY = 0;
            float speed = 200;
            int ranNumber = Random.Integer(10);

            // Good fruit initalizes
            /// Watermelon 
            Watermelon goodMelon = new Watermelon();
            goodMelon.rind = watermelonGreen;
            goodMelon.Update();

            /// Banana
            Banana goodBanana = new Banana();
            goodBanana.skin = bananaYellow;
            goodBanana.Update();

            /// Orange
            Orange goodOrange = new Orange();
            goodOrange.peel = orangeOrange;
            goodOrange.Update();

            // Bad fruit initalizes
            /// Watermelon
            Watermelon badMelon = new Watermelon();
            badMelon.rind = badRed;
            badMelon.Update();

            /// Banana
            Banana badBanana = new Banana();
            badBanana.skin = badRed;
            badBanana.Update();

            /// Orange
            Orange badOrange = new Orange();
            badOrange.peel = badRed;
            badOrange.Update();

            // WASD controls
            // Up
            if (Input.IsKeyboardKeyDown(KeyboardKey.Up) || Input.IsKeyboardKeyDown(KeyboardKey.W))
            {
                inputY -= 1;
            }

            // Down
            if (Input.IsKeyboardKeyDown(KeyboardKey.Down) || Input.IsKeyboardKeyDown(KeyboardKey.S))
            {
                inputY += 1;
            }

            // Left
            if (Input.IsKeyboardKeyDown(KeyboardKey.Left) || Input.IsKeyboardKeyDown(KeyboardKey.A))
            {
                inputX -= 1;
            }

            // Right
            if (Input.IsKeyboardKeyDown(KeyboardKey.Right) || Input.IsKeyboardKeyDown(KeyboardKey.D))
            {
                inputX += 1;
            }

            // Moves on x-axis 300px per second
            positionX += inputX * 300 * Time.DeltaTime;
            // Moves on y-axis 300px per second
            positionY += inputY * 300 * Time.DeltaTime;

            // Sword drawing moves with WASD
            // Sword changes on left-click
            if (Input.IsMouseButtonDown(MouseButton.Left) == false)
            {
                // Sheath
                Draw.SetFillColor(95, 95, 95);
                Draw.Rectangle(positionX, positionY, 30, 75);

                // Guard
                Draw.SetFillColor(255, 215, 0);
                Draw.Rectangle(positionX - 7, positionY + 70, 45, 15);

                // Hilt
                Draw.SetFillColor(Color.Black);
                Draw.Rectangle(positionX, positionY + 85, 30, 40);
            }

            else
            {
                // Blade
                Draw.SetFillColor(Color.White);
                Draw.Rectangle(positionX, positionY + 15, 30, 60);

                // Blade tip
                Draw.Triangle(positionX + 15, positionY, positionX, positionY + 15, positionX + 30, positionY + 15);

                // Guard
                Draw.SetFillColor(255, 215, 0);
                Draw.Rectangle(positionX - 7, positionY + 70, 45, 15);

                // Hilt
                Draw.SetFillColor(Color.Black);
                Draw.Rectangle(positionX, positionY + 85, 30, 40);
            }
        }
    }

}
