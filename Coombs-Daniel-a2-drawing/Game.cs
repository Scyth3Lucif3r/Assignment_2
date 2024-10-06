// Include code libraries you need below (use the namespace).
using System;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Threading;

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

        float xMouse;
        float yMouse;

        float windowX_Check;
        float windowY_Check;

        float[,] windowX = new float[6, 8];
        float[,] windowY = new float[6, 8];
        bool[] isOnWindow = new bool[48];

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Window Painting");
            Window.SetSize(400, 400);

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
            
            // Make Windows
            Draw.FillColor = grayWindow;
            for (int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    int xCord = i * 40;
                    int yCord = j * 40;
                    Draw.Square(90 + xCord, 90 + yCord, 20);
                    windowX[i, j] = 90 + xCord;
                    windowY[i, j] = 90 + yCord;
                    
                }
                
            }

            //Change Window Color
            xMouse = Input.GetMouseX();
            yMouse = Input.GetMouseY();
            turnOnWindow(xMouse, yMouse, 90, 110, 90, 110, 0);
            turnOnWindow(xMouse, yMouse, 90, 110, 130, 150, 1);
            turnOnWindow(xMouse, yMouse, 90, 110, 170, 190, 2);
            turnOnWindow(xMouse, yMouse, 90, 110, 210, 230, 3);
            turnOnWindow(xMouse, yMouse, 90, 110, 250, 270, 4);
            turnOnWindow(xMouse, yMouse, 90, 110, 290, 310, 5);
            turnOnWindow(xMouse, yMouse, 90, 110, 330, 350, 6);
            turnOnWindow(xMouse, yMouse, 90, 110, 370, 390, 7);
            turnOnWindow(xMouse, yMouse, 130, 150, 90, 110, 8);
            turnOnWindow(xMouse, yMouse, 130, 150, 130, 150, 9);
            turnOnWindow(xMouse, yMouse, 130, 150, 170, 190, 10);
            turnOnWindow(xMouse, yMouse, 130, 150, 210, 230, 11);
            turnOnWindow(xMouse, yMouse, 130, 150, 250, 270, 12);
            turnOnWindow(xMouse, yMouse, 130, 150, 290, 310, 13);
            turnOnWindow(xMouse, yMouse, 130, 150, 330, 350, 14);
            turnOnWindow(xMouse, yMouse, 130, 150, 370, 390, 15);
            turnOnWindow(xMouse, yMouse, 170, 190, 90, 110, 16);
            turnOnWindow(xMouse, yMouse, 170, 190, 130, 150, 17);
            turnOnWindow(xMouse, yMouse, 170, 190, 170, 190, 18);
            turnOnWindow(xMouse, yMouse, 170, 190, 210, 230, 19);
            turnOnWindow(xMouse, yMouse, 170, 190, 250, 270, 20);
            turnOnWindow(xMouse, yMouse, 170, 190, 290, 310, 21);
            turnOnWindow(xMouse, yMouse, 170, 190, 330, 350, 22);
            turnOnWindow(xMouse, yMouse, 170, 190, 370, 390, 23);
            turnOnWindow(xMouse, yMouse, 210, 230, 90, 110, 24);
            turnOnWindow(xMouse, yMouse, 210, 230, 130, 150, 25);
            turnOnWindow(xMouse, yMouse, 210, 230, 170, 190, 26);
            turnOnWindow(xMouse, yMouse, 210, 230, 210, 230, 27);
            turnOnWindow(xMouse, yMouse, 210, 230, 250, 270, 28);
            turnOnWindow(xMouse, yMouse, 210, 230, 290, 310, 29);
            turnOnWindow(xMouse, yMouse, 210, 230, 330, 350, 30);
            turnOnWindow(xMouse, yMouse, 210, 230, 370, 390, 31);
            turnOnWindow(xMouse, yMouse, 250, 270, 90, 110, 32);
            turnOnWindow(xMouse, yMouse, 250, 270, 130, 150, 33);
            turnOnWindow(xMouse, yMouse, 250, 270, 170, 190, 34);
            turnOnWindow(xMouse, yMouse, 250, 270, 210, 230, 35);
            turnOnWindow(xMouse, yMouse, 250, 270, 250, 270, 36);
            turnOnWindow(xMouse, yMouse, 250, 270, 290, 310, 37);
            turnOnWindow(xMouse, yMouse, 250, 270, 330, 350, 38);
            turnOnWindow(xMouse, yMouse, 250, 270, 370, 390, 39);
            turnOnWindow(xMouse, yMouse, 290, 310, 90, 110, 40);
            turnOnWindow(xMouse, yMouse, 290, 310, 130, 150, 41);
            turnOnWindow(xMouse, yMouse, 290, 310, 170, 190, 42);
            turnOnWindow(xMouse, yMouse, 290, 310, 210, 230, 43);
            turnOnWindow(xMouse, yMouse, 290, 310, 250, 270, 44);
            turnOnWindow(xMouse, yMouse, 290, 310, 290, 310, 45);
            turnOnWindow(xMouse, yMouse, 290, 310, 330, 350, 46);
            turnOnWindow(xMouse, yMouse, 290, 310, 370, 390, 47);


            void turnOnWindow (float xMouse, float yMouse, float windowX_checkMin, float windowX_checkMax, float windowY_checkMin, float windowY_checkMax, int num)
            {
                if (xMouse >= windowX_checkMin && xMouse <= windowX_checkMax)
                {
                    if ((yMouse >= windowY_checkMin && yMouse <= windowY_checkMax) || isOnWindow[0] == true)
                    {
                        Draw.FillColor = yellowWindow;
                        Draw.Square(windowX[num, num], windowY[num, num], 20);
                        isOnWindow[0] = !isOnWindow[0];
                        Thread.Sleep(100);
                        Console.WriteLine(isOnWindow[0]);

                    }
                }
            } 
        }
    }
}
    
