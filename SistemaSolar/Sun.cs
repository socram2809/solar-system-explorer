﻿/* 
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
    class Sun
    {
              
        int list;
        float SunRotation;

        public void Create()
        {
            Glu.GLUquadric quadratic = Glu.gluNewQuadric();
            Glu.gluQuadricNormals(quadratic, Glu.GLU_SMOOTH);
            Glu.gluQuadricTexture(quadratic, Gl.GL_TRUE);

            list = Gl.glGenLists(1);
            Gl.glNewList(list, Gl.GL_COMPILE);
            Gl.glPushMatrix();
            Gl.glRotated(90, 1, 0, 0);
      
            Glu.gluSphere(quadratic, 3, 32, 32);
       
            Gl.glPopMatrix();
            Gl.glEndList();
        }

        public  void Paint()
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, ContentManager.GetTextureByName("sun.jpg"));   
            Gl.glPushMatrix();
            SunRotation += 0.2f; // sun rotation along y-axis
            Gl.glRotatef(SunRotation, 0, 1, 0);  
            Gl.glCallList(list);
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D); 
        } 
    }
}
