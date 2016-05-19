/* 
        Abbas Majeed (i110273)
       
        Fast-Nu Isb Campus
 
 */
using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl; 

namespace SistemaSolar
{
    class Star
    {
        List<Position> stars = new List<Position>();
   
        public void drawStars(int amount)
        {
            Random r = new Random();
            int count = 0;

            while (count != amount)
            {
                Position p = default(Position);
                p.x = (r.Next(210)) * (float)Math.Pow(-1, r.Next()); // next() returns a random number < than passed parameter
                p.z = (r.Next(210)) * (float)Math.Pow(-1, r.Next());
                p.y = (r.Next(210)) * (float)Math.Pow(-1, r.Next());
                if (Math.Pow(Math.Pow(p.x, 2) + Math.Pow(p.y, 2) + Math.Pow(p.z, 2), 1 / 3f) > 15)
                {
                    stars.Add(p);
                    count++;
                }
            }
        }

        public void Draw()
        {
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glColor3f(2,2,1);
            Gl.glPointSize(10);
            foreach (var item in stars)
            {
                Gl.glVertex3f(item.x, item.y, item.z);   
            }
            Gl.glEnd(); 
        }
    }
}