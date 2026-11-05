// Include the namespaces (code libraries) you need below.
using System;
using System.Diagnostics.CodeAnalysis;
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
    public class Orange()
    {
        public Color peel;
        public float x;
        public float y;

        public void Update()
        {
            // Orange template
            Draw.FillColor = peel;
            Draw.Circle(x, y, 20);
        }
    }

    public class Game
    {
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        ///

        float x;
        float speed = 200;

        // Variables for player control
        float positionX;
        float positionY;
        int radius = 20;

        // Fruit Colors
        Color watermelonGreen = new Color(31, 132, 0);
        Color orangeOrange = new Color(242, 133, 0);

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

            // Melon movementw
            float highSpeed = 175;
            int ranNumber = Random.Integer(200);

            // Checks when object reachs window
            if (x - radius > Window.Width)
            {
                // X resets
                x = -radius;
            }

            x += Time.DeltaTime * speed;

            /// Watermelon initializes
            Watermelon topMelon = new Watermelon
            {
                rind = watermelonGreen,
                x = x + highSpeed,
                y = 100
            };
            topMelon.Update();

            Watermelon midMelon = new Watermelon
            {
                rind = watermelonGreen,
                x = x + 80,
                y = 250
            };
            midMelon.Update();

            Watermelon lowMelon = new Watermelon
            {
                rind = watermelonGreen,
                x = x + 50,
                y = 450
            };
            lowMelon.Update();

            // Orange initializes

            Orange leftOrange = new Orange
            {
                peel = orangeOrange,
                x = 150,
                y = x + 50
            };
            leftOrange.Update();

            Orange midOrange1 = new Orange
            {
                peel = orangeOrange,
                x = 300,
                y = x + 180
            };
            midOrange1.Update();

            Orange midOrange2 = new Orange
            {
                peel = orangeOrange,
                x = 450,
                y = x + highSpeed
            };
            midOrange2.Update();

            Orange rightOrange = new Orange
            {
                peel = orangeOrange,
                x = 600,
                y = x + 120
            };
            rightOrange.Update();

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

            // Moves on x-axis 400px per second
            positionX += inputX * 400 * Time.DeltaTime;
            // Moves on y-axis 400px per second
            positionY += inputY * 400 * Time.DeltaTime;

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
