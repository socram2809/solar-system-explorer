/* 
        Abbas Majeed (i110273)
        Members:
            Sibghatullah(i110297)
            Zohaib Nasir(i110283)
        Fast-Nu Isb Campus
 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShadowEngine;
using ShadowEngine.OpenGL; 
using Tao.OpenGl; 

namespace SistemaSolar
{
    public partial class MainForm : Form
    {
        //handle  viewport
        uint hdc;
        SolarSystem sistema = new SolarSystem();
        static bool showOrbit = true;
        static Vector2 formPos;
        int moviendo;
        float r = 0; //rotacao
        float t = 0; //translação
        int d = 0; //distância
        float s = 0; //tamanho

        public static Vector2 FormPos
        {
            get { return MainForm.formPos; }
            set { MainForm.formPos = value; }
        }

        public static bool ShowOrbit
        {
            get { return MainForm.showOrbit; }
            set { MainForm.showOrbit = value; }
        } 

        public MainForm()
        {
            InitializeComponent();
            hdc = (uint)pnlViewPort.Handle;
            string error = "";
           
            OpenGLControl.OpenGLInit(ref hdc, pnlViewPort.Width, pnlViewPort.Height, ref error);
            

            if (error != "")
            {
                MessageBox.Show(error);   
            }
            
            sistema.Camara.InitCamara(); 
            


            float[] materialAmbient = { 0.5F, 0.5F, 0.5F, 1.0F };
            float[] materialDiffuse = { 1f, 1f, 1f, 1.0f };
            float[] materialSpecular = { 1.0F, 1.0F, 1.0F, 1.0F };
            float[] materialShininess = { 10.0F };
            float[] ambientLightPosition = { 0F, 0F, 0F, 1.0F };
            float[] lightAmbient = { 0.85F, 0.85F, 0.85F, 0.0F }; 

            Lighting.MaterialAmbient = materialAmbient;
            Lighting.MaterialDiffuse = materialDiffuse;
            Lighting.MaterialShininess = materialShininess;
            Lighting.AmbientLightPosition = ambientLightPosition;
            Lighting.LightAmbient = lightAmbient;

            Lighting.SetupLighting();  

            // textur
            ContentManager.SetTextureList("texturas\\");
            ContentManager.LoadTextures(); 
            sistema.CreateScene();
            Camara.CenterMouse(); 
           
            Gl.glClearColor(0, 0, 0, 1);//red green blue alpha 
        }

        private void tmrPaint_Tick(object sender, EventArgs e)
        {
            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            
            sistema.Camara.Update(moviendo);
            
            sistema.DrawScene();
            
            Winapi.SwapBuffers(hdc);
         
            Gl.glFlush(); 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            formPos = new Vector2(this.Left, this.Top); 
        }

        private void pnlViewPort_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moviendo = 1;
            }
            else
            {
                moviendo = -1;
            }
           
        }

        private void pnlViewPort_MouseUp(object sender, MouseEventArgs e)
        {
            moviendo = 0;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode  == Keys.Escape)
            {
                this.Close(); 
            }
            if (e.KeyCode == Keys.O)
            {
                if (showOrbit == true)
                    showOrbit = false;
                else
                    showOrbit = true; 
            }
            if (e.KeyCode == Keys.R)
            {
                r = r + 1;
                sistema.mudarRotacao(r);
            }
            if (e.KeyCode == Keys.T)
            {
                t = t + 1;
                sistema.mudarTranslacao(t);
            }
            if (e.KeyCode == Keys.D)
            {
                d = d + 1;
                sistema.mudarDistancia(d);
            }
            if(e.KeyCode == Keys.S)
            {
                s = s + 1;
                sistema.mudarRaio(s);
            }
        }
    }
}
