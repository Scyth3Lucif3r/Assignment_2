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
        float[,] isOnWindow = new float[6, 8];

        int num1_global;
        int num2_global;

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
            Draw.LineSize = 0;
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
            /*
            //Console.WriteLine(isOnWindow[num1, num2]);
            if (isOnWindow[num1, num2] > 0 && isOnWindow[num1, num2] < 3)
            {
                Draw.FillColor = yellowWindow;
                Draw.Square(windowX[num1, num2], windowY[num1, num2], 20);
            }
            else if (isOnWindow[num1, num2] <= 3 || isOnWindow[num1, num2] <= 0)
            {
                Draw.FillColor = grayWindow;
                Draw.Square(windowX[num1, num2], windowY[num1, num2], 20);
                isOnWindow[num1, num2] = 0;
            } */


            //Change Window Color
            xMouse = Input.GetMouseX();
            yMouse = Input.GetMouseY();
            //Row 1
            turnOnWindow(xMouse, yMouse, 90, 110, 90, 110, 0, 0);
            keepWindowOn(0, 0);
            turnOnWindow(xMouse, yMouse, 90, 110, 130, 150, 0, 1);
            keepWindowOn(0, 1);
            turnOnWindow(xMouse, yMouse, 90, 110, 170, 190, 0, 2);
            keepWindowOn(0, 2);
            turnOnWindow(xMouse, yMouse, 90, 110, 210, 230, 0, 3);
            keepWindowOn(0, 3);
            turnOnWindow(xMouse, yMouse, 90, 110, 250, 270, 0, 4);
            keepWindowOn(0, 4);
            turnOnWindow(xMouse, yMouse, 90, 110, 290, 310, 0, 5);
            keepWindowOn(0, 5);
            turnOnWindow(xMouse, yMouse, 90, 110, 330, 350, 0, 6);
            keepWindowOn(0, 6);
            turnOnWindow(xMouse, yMouse, 90, 110, 370, 390, 0, 7);
            keepWindowOn(0, 7);
            //Row 2
            turnOnWindow(xMouse, yMouse, 130, 150, 90, 110, 1, 0);
            keepWindowOn(1, 0);
            turnOnWindow(xMouse, yMouse, 130, 150, 130, 150, 1, 1);
            keepWindowOn(1, 1);
            turnOnWindow(xMouse, yMouse, 130, 150, 170, 190, 1, 2);
            keepWindowOn(1, 2);
            turnOnWindow(xMouse, yMouse, 130, 150, 210, 230, 1, 3);
            keepWindowOn(1, 3);
            turnOnWindow(xMouse, yMouse, 130, 150, 250, 270, 1, 4);
            keepWindowOn(1, 4);
            turnOnWindow(xMouse, yMouse, 130, 150, 290, 310, 1, 5);
            keepWindowOn(1, 5);
            turnOnWindow(xMouse, yMouse, 130, 150, 330, 350, 1, 6);
            keepWindowOn(1, 6);
            turnOnWindow(xMouse, yMouse, 130, 150, 370, 390, 1, 7);
            keepWindowOn(1, 7);
            //Row 3
            turnOnWindow(xMouse, yMouse, 170, 190, 90, 110, 2, 0);
            keepWindowOn(2, 0);
            turnOnWindow(xMouse, yMouse, 170, 190, 130, 150, 2, 1);
            keepWindowOn(2, 1);
            turnOnWindow(xMouse, yMouse, 170, 190, 170, 190, 2, 2);
            keepWindowOn(2, 2);
            turnOnWindow(xMouse, yMouse, 170, 190, 210, 230, 2, 3);
            keepWindowOn(2, 3);
            turnOnWindow(xMouse, yMouse, 170, 190, 250, 270, 2, 4);
            keepWindowOn(2, 4);
            turnOnWindow(xMouse, yMouse, 170, 190, 290, 310, 2, 5);
            keepWindowOn(2, 5);
            turnOnWindow(xMouse, yMouse, 170, 190, 330, 350, 2, 6);
            keepWindowOn(2, 6);
            turnOnWindow(xMouse, yMouse, 170, 190, 370, 390, 2, 7);
            keepWindowOn(2, 7);
            //Row 4
            turnOnWindow(xMouse, yMouse, 210, 230, 90, 110, 3, 0);
            keepWindowOn(3, 0);
            turnOnWindow(xMouse, yMouse, 210, 230, 130, 150, 3, 1);
            keepWindowOn(3, 1);
            turnOnWindow(xMouse, yMouse, 210, 230, 170, 190, 3, 2);
            keepWindowOn(3, 2);
            turnOnWindow(xMouse, yMouse, 210, 230, 210, 230, 3, 3);
            keepWindowOn(3, 3);
            turnOnWindow(xMouse, yMouse, 210, 230, 250, 270, 3, 4);
            keepWindowOn(3, 4);
            turnOnWindow(xMouse, yMouse, 210, 230, 290, 310, 3, 5);
            keepWindowOn(3, 5);
            turnOnWindow(xMouse, yMouse, 210, 230, 330, 350, 3, 6);
            keepWindowOn(3, 6);
            turnOnWindow(xMouse, yMouse, 210, 230, 370, 390, 3, 7);
            keepWindowOn(3, 7);
            //Row 5
            turnOnWindow(xMouse, yMouse, 250, 270, 90, 110, 4, 0);
            keepWindowOn(4, 0);
            turnOnWindow(xMouse, yMouse, 250, 270, 130, 150, 4, 1);
            keepWindowOn(4, 1);
            turnOnWindow(xMouse, yMouse, 250, 270, 170, 190, 4, 2);
            keepWindowOn(4, 2);
            turnOnWindow(xMouse, yMouse, 250, 270, 210, 230, 4, 3);
            keepWindowOn(4, 3);
            turnOnWindow(xMouse, yMouse, 250, 270, 250, 270, 4, 4);
            keepWindowOn(4, 4);
            turnOnWindow(xMouse, yMouse, 250, 270, 290, 310, 4, 5);
            keepWindowOn(4, 5);
            turnOnWindow(xMouse, yMouse, 250, 270, 330, 350, 4, 6);
            keepWindowOn(4, 6);
            turnOnWindow(xMouse, yMouse, 250, 270, 370, 390, 4, 7);
            keepWindowOn(4, 7);
            //Row 6
            turnOnWindow(xMouse, yMouse, 290, 310, 90, 110, 5, 0);
            keepWindowOn(5, 0);
            turnOnWindow(xMouse, yMouse, 290, 310, 130, 150, 5, 1);
            keepWindowOn(5, 1);
            turnOnWindow(xMouse, yMouse, 290, 310, 170, 190, 5, 2);
            keepWindowOn(5, 2);
            turnOnWindow(xMouse, yMouse, 290, 310, 210, 230, 5, 3);
            keepWindowOn(5, 3);
            turnOnWindow(xMouse, yMouse, 290, 310, 250, 270, 5, 4);
            keepWindowOn(5, 4);
            turnOnWindow(xMouse, yMouse, 290, 310, 290, 310, 5, 5);
            keepWindowOn(5, 5);
            turnOnWindow(xMouse, yMouse, 290, 310, 330, 350, 5, 6);
            keepWindowOn(5, 6);
            turnOnWindow(xMouse, yMouse, 290, 310, 370, 390, 5, 7);
            keepWindowOn(5, 7);


            void turnOnWindow (float xMouse, float yMouse, float windowX_checkMin, float windowX_checkMax, float windowY_checkMin, float windowY_checkMax, int num1, int num2)
            {
                if (xMouse >= windowX_checkMin && xMouse <= windowX_checkMax)
                {
                    if ((yMouse >= windowY_checkMin && yMouse <= windowY_checkMax))
                    {
                        Draw.FillColor = yellowWindow;
                        Draw.Square(windowX[num1, num2], windowY[num1, num2], 20);
                        isOnWindow[num1, num2] += 1;
                        Thread.Sleep(250);
                        Console.WriteLine(isOnWindow[num1, num2]);

                        
                    }
                }
            }
            void keepWindowOn(int num1,int num2)
            {
                //Console.WriteLine(isOnWindow[num1, num2]);
                if (isOnWindow[num1, num2] > 0 && isOnWindow[num1, num2] < 3)
                {
                    Draw.FillColor = yellowWindow;
                    Draw.Square(windowX[num1, num2], windowY[num1, num2], 20);
                }
                else if (isOnWindow[num1, num2] <= 3 || isOnWindow[num1, num2] <= 0)
                {
                    Draw.FillColor = grayWindow;
                    Draw.Square(windowX[num1, num2], windowY[num1, num2], 20);
                    isOnWindow[num1, num2] = 0;
                }
            }
        }
    }
}
    
