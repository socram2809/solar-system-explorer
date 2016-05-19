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
    class Satellite
    {
        Planets planet;
        Position planetPosition;
        Position lunaPos;
        float moonEarthRotation;
        float radio;
        int list;
        float velocidadOrbita=0;
        string texture;


        public Satellite(float radio, Planets p, Position pos, string texture)
        {
            this.radio = radio;
            this.planet = p;
            planetPosition = pos;
            lunaPos = planetPosition;
            lunaPos.x += 3; 
            this.texture = texture; 
        }

        public void Create()
        {
            Glu.GLUquadric quadratic = Glu.gluNewQuadric();
            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);
            Glu.gluQuadricTexture(quadratic, Gl.GL_TRUE);

            list = Gl.glGenLists(1);
            Gl.glNewList(list, Gl.GL_COMPILE);
            Gl.glPushMatrix();
            Gl.glRotated(90, 1, 0, 0);
            Glu.gluSphere(quadratic, radio, 32, 32);
            Gl.glPopMatrix();
            Gl.glEndList();
        }

        public void Paint(Position p,float angle)
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName(texture));

            angle += velocidadOrbita;
            moonEarthRotation += 0.6f; // moon rotaion around earth
            Gl.glPushMatrix();
            Gl.glRotatef(angle, 0, 1, 0);
            Gl.glTranslatef(-p.x,-p.y,-p.z);
            Gl.glRotatef(moonEarthRotation, 0, 1, 0);
            Gl.glTranslatef(2, 0, 0);
            Gl.glCallList(list);
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);  
        } 
    }
}
