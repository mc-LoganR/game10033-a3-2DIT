// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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

    public class Game
    {
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        ///

        // Variables for player control
        float positionX;
        float positionY;

        // Variable for object movement
        float lrSlowMove;
        float lrFastMove;
        float lrRandomMove;

        // Fruit Colors
        Color watermelonGreen = new Color(31, 132, 0);

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
            // Cyan background
            Window.ClearBackground(Color.Cyan);

            // Mouse movement variables
            float inputX = 0;
            float inputY = 0;

            // Time variables
            // Time in seconds between last frame and current frame
            float deltaTime = Time.DeltaTime;
            // Frames elapsed since system start-up
            int framesElapsed = Time.FramesElapsed;
            // Seconds elapsed since system start-up
            float secondsElapsed = Time.SecondsElapsed;

            // Melon movement
            float lowSpeed = 200;
            float highSpeed = 300;
            int ranNumber = Random.Integer(300);
            lrSlowMove += Time.DeltaTime * lowSpeed;
            lrFastMove += Time.DeltaTime * highSpeed;
            lrRandomMove += Time.DeltaTime * ranNumber;

            /// Watermelon initializes
            Watermelon goodMelon1 = new Watermelon();
            goodMelon1.rind = watermelonGreen;
            goodMelon1.x = lrSlowMove + 5;
            goodMelon1.y = 50;
            goodMelon1.Update();

            Watermelon goodMelon2 = new Watermelon();
            goodMelon2.rind = watermelonGreen;
            goodMelon2.x = lrFastMove;
            goodMelon2.y = 200;
            goodMelon2.Update();

            Watermelon goodMelon3 = new Watermelon();
            goodMelon3.rind = watermelonGreen;
            goodMelon3.x = lrRandomMove;
            goodMelon3.y = 350;
            goodMelon3.Update();

            Watermelon goodMelon4 = new Watermelon();
            goodMelon4.rind = watermelonGreen;
            goodMelon4.x = lrRandomMove;
            goodMelon4.y = 500;
            goodMelon4.Update();

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
