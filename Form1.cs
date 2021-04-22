using Roshchina_Anastasia_pri117_railway.Roshchina_Anastasia_pri117_lab15;
using System;
using System.Windows.Forms;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Roshchina_Anastasia_pri117_railway
{
    public partial class Form1 : Form
    {
        public delegate double MovingCamera();

        public static double[] camera = new double[7];

        private double[] initialCamera = {
            0,-10,-10,30,1,0,0.1
        };


        private TexturesForObjects textureLoader;
        private anModelLoader model;

        private int fieldSize = 500;

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textureLoader = new TexturesForObjects();
            model = new anModelLoader();

            // инициализация OpenGL
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Il.ilInit();
            Ilut.ilutInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluPerspective(45, AnT.Width / AnT.Height, 0.2, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            camera = initialCamera;

            Draw();

            model.LoadModel("bench.ase");
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        // функция для отрисовки поверхности
        private void DrawGround()
        {
            Gl.glPushMatrix();

            Gl.glTranslated(0, 0, 0);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glRotated(45, 0, 0, 1);

            // включаем режим текстурирования
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_NORMALIZE);

            textureLoader.LoadTextureForModel("grass.jpg");
            uint grassTexture = textureLoader.GetTextureObj();

            Gl.glActiveTexture(Gl.GL_TEXTURE0);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, grassTexture);

            // отрисовываем полигон 
            Gl.glBegin(Gl.GL_QUADS);
            // указываем поочередно вершины и текстурные координаты 
            int count = 25;
            int quad_size = fieldSize / count;

            int y = -fieldSize / 2;
            for (int i = 0; i < count; i++)
            {
                int x = -fieldSize / 2;
                for (int j = 0; j < count; j++)
                {
                    Gl.glVertex3d(x - quad_size + j * quad_size, y - quad_size, 0);
                    Gl.glTexCoord2f(0, 0);
                    Gl.glVertex3d(x - quad_size + j * quad_size, y + quad_size, 0);
                    Gl.glTexCoord2f(1, 0);
                    Gl.glVertex3d(x + quad_size + j * quad_size, y + quad_size, 0);
                    Gl.glTexCoord2f(1, 1);
                    Gl.glVertex3d(x + quad_size + j * quad_size, y - quad_size, 0);
                    Gl.glTexCoord2f(0, 1);
                    x += quad_size;
                }

                y += quad_size;
            }

            // завершаем отрисовку 
            Gl.glEnd();

            //Glut.glutSolidCylinder(30, 10, 4, 4);

            Gl.glPopMatrix();
            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glDisable(Gl.GL_NORMALIZE);
        }

        private void DrawBench()
        {
            if (model != null)
                model.DrawModel();
        }

        private void DrawRail()
        {
            /*double[,] railContour =
            {
                {0, 0},
                {58, 37},
                {50, 61},
                {30, 93},
                {48, 132},
                {70, 141},
                {73, 147},
                {145, 147},
                {158, 137},
                {183, 90},
                {165, 60},
                {149, 35},
                {215, 0}
            };*/

            Gl.glPushMatrix();

            Gl.glTranslated(0, 0, 0);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glRotated(45, 0, 0, 1);

            // включаем режим текстурирования
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_NORMALIZE);

            textureLoader.LoadTextureForModel("metal.jpg");
            uint texture = textureLoader.GetTextureObj();

            Gl.glActiveTexture(Gl.GL_TEXTURE0);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture);

            /*// отрисовываем полигон 
            Gl.glBegin(Gl.GL_POLYGON);

            int first;
            double xA;
            double xB;
            double xC;
            double xD;

            double yA;
            double yB;
            double yC;
            double yD;

            double a0;
            double a1;
            double a2;
            double a3;

            double b0;
            double b1;
            double b2;
            double b3;

            double t;

            double X;
            double Y;

            int N = 13;
            for (int i = 1; i < N - 2; i++)
            {
                // реализация представленного в теоретическом описании алгоритма для калькуляции сплайна 
                first = 1;
                xA = railContour[i - 1, 0];
                xB = railContour[i, 0];
                xC = railContour[i + 1, 0];
                xD = railContour[i + 2, 0];

                yA = railContour[i - 1, 1];
                yB = railContour[i, 1];
                yC = railContour[i + 1, 1];
                yD = railContour[i + 2, 1];

                a3 = (-xA + 3 * (xB - xC) + xD) / 6.0;

                a2 = (xA - 2 * xB + xC) / 2.0;

                a1 = (xC - xA) / 2.0;

                a0 = (xA + 4 * xB + xC) / 6.0;

                b3 = (-yA + 3 * (yB - yC) + yD) / 6.0;

                b2 = (yA - 2 * yB + yC) / 2.0;

                b1 = (yC - yA) / 2.0;

                b0 = (yA + 4 * yB + yC) / 6.0;

                // отрисовка сегментов 

                for (int j = 0; j <= N; j++)
                {
                    // параметр t на отрезке от 0 до 1 
                    t = j / N;

                    // генерация координат 
                    X = (((a3 * t + a2) * t + a1) * t + a0);
                    Y = (((b3 * t + b2) * t + b1) * t + b0);

                    // и установка вершин 
                    if (first == 1)
                    {
                        first = 0;
                        Gl.glVertex3d(X, 0, -Y);
                    }
                    else
                        Gl.glVertex3d(X, 0, -Y);

                }
            }
            Gl.glVertex3d(railContour[0, 0], 0, -railContour[0, 1]);

            // завершаем отрисовку 
            Gl.glEnd();*/

            //Glut.glutSolidCylinder(30, 10, 4, 4);

            int[] segmentsRot =
            {
                0,0,0,0,0,10,30,0
            };

            int segmentLength = 70;
            int railSize = 3;
            int segmentsCount = segmentsRot.Length;

            int x = -fieldSize / 2;
            int currentRotation = 0;
            int lastRotation = 0;
            double deltaY = 0;
            double deltaX = 0;
            for (int i = 0; i < segmentsCount; i++)
            {

                if (segmentsRot[i] != lastRotation && segmentsRot[i] != 0)
                {

                    deltaY += Math.Sin(lastRotation) * segmentLength / 2.4;
                    deltaX += segmentLength - Math.Sqrt((segmentLength * segmentLength) - (deltaY * 4 * deltaY));

                    currentRotation += segmentsRot[i];
                    lastRotation = segmentsRot[i];
                }
                else
                {
                    if (currentRotation != 0)
                    {
                        deltaY += deltaY;
                        deltaX += deltaX;
                    }
                }

                Gl.glPushMatrix();

                Gl.glTranslated(x + i * segmentLength - deltaX, deltaY, -railSize * 2);
                Gl.glRotated(90, 0, 1, 0);
                Gl.glRotated(45, 0, 0, 1);
                Gl.glRotated(currentRotation, 1, 0, 0);

                Glut.glutSolidCylinder(railSize, segmentLength, 16, 16);
                Gl.glPopMatrix();

                Gl.glPushMatrix();

                Gl.glTranslated(x + i * segmentLength - deltaX, deltaY, -railSize);
                Gl.glRotated(90, 0, 1, 0);
                Gl.glRotated(45, 0, 0, 1);
                Gl.glRotated(currentRotation, 1, 0, 0);

                Glut.glutSolidCylinder(railSize * 0.8, segmentLength, 4, 4);
                Gl.glPopMatrix();


            }

            Gl.glPopMatrix();
            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glDisable(Gl.GL_NORMALIZE);
        }

        private void Draw()
        {

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();

            Gl.glPushMatrix();

            // используем параметры для установленной камеры
            Gl.glTranslated(camera[0], camera[1], camera[2]);
            Gl.glScaled(camera[6], camera[6], camera[6]);
            Gl.glRotated(camera[3], 1, 0, 0);
            Gl.glRotated(camera[4], 0, 1, 0);
            Gl.glRotated(camera[5], 0, 0, 1);

            DrawGround();
            DrawBench();
            DrawRail();

            Gl.glPopMatrix();
            Gl.glFlush();

            // обновляем окно
            AnT.Invalidate();
        }

        EventHandler MovingForwardHandler = new EventHandler(MovingForward);
        EventHandler MovingBackHandler = new EventHandler(MovingBack);
        EventHandler MovingRightHandler = new EventHandler(MovingRight);
        EventHandler MovingLeftHandler = new EventHandler(MovingLeft);
        EventHandler RotateRightHandler = new EventHandler(RotateRight);
        EventHandler RotateLeftHandler = new EventHandler(RotateLeft);
        EventHandler ZoomInHandler = new EventHandler(ZoomIn);
        EventHandler ZoomOutHandler = new EventHandler(ZoomOut);

        static double scaleSpeed = 2;

        private static void MovingForward(object sender, EventArgs e)
        {
            if (camera[2] < -1)
            {
                camera[2] += scaleSpeed;
            }
        }

        private static void MovingBack(object sender, EventArgs e)
        {
            camera[2] -= scaleSpeed;
        }

        private static void MovingLeft(object sender, EventArgs e)
        {
            camera[0] += scaleSpeed;
        }

        private static void MovingRight(object sender, EventArgs e)
        {
            camera[0] -= scaleSpeed;
        }

        private static void RotateRight(object sender, EventArgs e)
        {
            camera[4] += scaleSpeed;
        }

        private static void RotateLeft(object sender, EventArgs e)
        {
            camera[4] -= scaleSpeed;
        }

        private static void ZoomIn(object sender, EventArgs e)
        {
            if (camera[6] < 5)
            {
                camera[6] += scaleSpeed / 10;
            }
        }

        private static void ZoomOut(object sender, EventArgs e)
        {
            if (camera[6] > 0.1)
            {
                camera[6] -= scaleSpeed / 100;
            }
        }

        private void buttonForward_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += MovingForwardHandler;
            RenderTimer.Start();
        }

        private void buttonForward_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= MovingForwardHandler;
            RenderTimer.Stop();
        }

        private void buttonBack_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += MovingBackHandler;
            RenderTimer.Start();
        }

        private void buttonBack_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= MovingBackHandler;
            RenderTimer.Stop();
        }

        private void buttonLeft_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += MovingLeftHandler;
            RenderTimer.Start();
        }

        private void buttonLeft_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= MovingLeftHandler;
            RenderTimer.Stop();
        }

        private void buttonRight_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += MovingRightHandler;
            RenderTimer.Start();
        }

        private void buttonRight_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= MovingRightHandler;
            RenderTimer.Stop();
        }

        private void buttonRotRight_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += RotateRightHandler;
            RenderTimer.Start();
        }

        private void buttonRotRight_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= RotateRightHandler;
            RenderTimer.Stop();
        }

        private void buttonRotLeft_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += RotateLeftHandler;
            RenderTimer.Start();
        }

        private void buttonRotLeft_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= RotateLeftHandler;
            RenderTimer.Stop();
        }

        private void buttonToStart_Click(object sender, EventArgs e)
        {
            camera = initialCamera;
            Draw();
        }

        private void buttonZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += ZoomInHandler;
            RenderTimer.Start();
        }

        private void buttonZoomIn_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= ZoomInHandler;
            RenderTimer.Stop();
        }

        private void buttonZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick += ZoomOutHandler;
            RenderTimer.Start();
        }

        private void buttonZoomOut_MouseUp(object sender, MouseEventArgs e)
        {
            RenderTimer.Tick -= ZoomOutHandler;
            RenderTimer.Stop();
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            scaleSpeed = trackBarZoom.Value;
        }
    }
}
