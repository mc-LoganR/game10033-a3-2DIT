// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Resources;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        ///

        float positionX;
        float positionY;
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
            int ranNumber = Random.Integer(10);

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

            // Moves on x-axis 200px per second
            positionX += inputX * 200 * Time.DeltaTime;
            // Moves on y-axis 250px per second
            positionY += inputY * 250 * Time.DeltaTime;

            // Sword drawing follows WASD
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
