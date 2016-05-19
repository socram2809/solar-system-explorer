/* 
        Abbas Majeed (i110273)
        
        Fast-Nu Isb Campus
 
 */
using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using ShadowEngine;

namespace SistemaSolar
{
    class Planet
    {
        Planets planet;
        Position position;
        float axisRotation; // rotation about their own axis
        float anguloOrbita;
        float radio;
        int list;
        static Random r = new Random();
        float orbitalVelocity; // orbital velocity of planets
        string texture;
        Satellite moon;


        public Planet(float radio, Planets plnt, Position p, string texture,bool hasMoon)
        {
            this.radio = radio;
            this.planet = plnt;
            position = p;
            anguloOrbita = r.Next(360);
            orbitalVelocity = (float)r.NextDouble() * 0.3f;
            this.texture = texture;
            if (hasMoon)
            {
                moon = new Satellite(0.5f, Planets.Earth, p, "luna.jpg"); 
            }   
        }

        public void Create()
        {
            Glu.GLUquadric quadratic = Glu.gluNewQuadric(); 
            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);
            Glu.gluQuadricTexture(quadratic, Gl.GL_TRUE);

            list = Gl.glGenLists(1); 
            Gl.glNewList(list, Gl.GL_COMPILE);
            Gl.glPushMatrix();
            Gl.glRotated(270, 1, 0, 0);
            Glu.gluSphere(quadratic, radio, 32, 32);
            Gl.glPopMatrix();
            Gl.glEndList();
            if (planet == Planets.Earth)
            {
                moon.Create();
            }
        }

        public void DrawOrbit()
        {
            Gl.glBegin(Gl.GL_LINE_STRIP);

            for (int i = 0; i < 361; i++)
            {
                Gl.glVertex3f(position.x * (float)Math.Sin(i * Math.PI / 180), 0, position.x * (float)Math.Cos(i * Math.PI / 180));
            }
            Gl.glEnd(); 
        }

        public void Paint()
        {
            if (MainForm.ShowOrbit)
            {
                DrawOrbit();
            }
            if (planet == Planets.Earth)
            {
                moon.Paint(position, anguloOrbita);  
            }
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName(texture));
            Gl.glPushMatrix();
            anguloOrbita += orbitalVelocity;
            axisRotation += 0.6f;
            Gl.glRotatef(anguloOrbita, 0, 1, 0);
            Gl.glTranslatef(-position.x, -position.y, -position.z);

            Gl.glRotatef(axisRotation, 0, 1, 0);
           
            Gl.glCallList(list);
          
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        } 
    }
}
