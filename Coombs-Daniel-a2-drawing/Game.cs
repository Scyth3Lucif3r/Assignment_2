// Include code libraries you need below (use the namespace).
using System;
using System.Net.NetworkInformation;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Color grayBuilding = new Color(0x4b, 0x4a, 0x4b);
        Color grayWindow = new Color(0x6c, 0x6a, 0x6c);
        Color yellowWindow = new Color(0xff, 0xdf, 0x00);
        Color nightSkyBlue = new Color(0x08, 0x08, 0x38);

        float[] xCoordinates = [];
        float[] yCoordinates = [];

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Window Painting");
            Window.SetSize(400, 400);

            int count = 100;
            xCoordinates = new float[count];
            yCoordinates = new float[count];

            for (int i = 0; i < count; i++)
            {
                xCoordinates[i] = Random.Integer(10, 390);
                yCoordinates[i] = Random.Integer(10, 250);
            }
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(nightSkyBlue);

            Draw.LineSize = 0;
            Draw.FillColor = grayBuilding;
            // Vertical building rectangles
            for (int index = 0; index < 6; index++)
            {
                int xOffset = index * 40;
                Draw.Rectangle(80 + xOffset, 60, 10, 340);
                
                for (int j = 0; j < 6; j++)
                {
                    xOffset = j * 40;
                    Draw.Rectangle(110 + xOffset, 60, 10, 340);

                } 

            }
            
            Draw.LineSize = 0;
            Draw.FillColor = grayBuilding;
            // Horizontal building rectangles
            Draw.Rectangle(80, 60, 240, 30);
            for (int index = 0; index < 8; index++)
            {
                int yOffset = index * 40;
                Draw.Rectangle(80, 80 + yOffset, 240, 10);

                for (int j = 0; j < 8; j++)
                {
                    yOffset = j * 40;
                    Draw.Rectangle(80, 110 + yOffset, 240, 10);

                }

            }
            /*
            // Draw pellets
            Draw.FillColor = Color.White;
            for (int i = 0; i < xCoordinates.Length; i++)
            {
                Draw.Circle(xCoordinates[i], yCoordinates[i], pelletRadius);
            } */
        }
    }
}
    
