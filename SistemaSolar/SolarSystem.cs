/* 
        Abbas Majeed (i110273)
       
        Fast-Nu Isb Campus
 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaSolar
{
    enum Planets
    { Mercury, Venus, Earth, Mars, Jupiter, Saturn, Neptune, Uranus, Pluto }


    public struct Position
    {
        public float x;
        public float y;
        public float z;

        public Position(int x,int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public class SolarSystem
    {
        Camara camara = new Camara();
        Star star = new Star();
        Sun sun = new Sun();
        List<Planet> planet = new List<Planet>();
       

        public void CreateScene()
        {
            planet.Add(new Planet(0.5f, Planets.Mercury, new Position(5, 0, 0), "mercury.jpg",false));
            planet.Add(new Planet(0.7f, Planets.Venus, new Position(11, 0, 0), "venus.jpg", false));
            planet.Add(new Planet(1, Planets.Earth, new Position(15, 0, 0), "earth.jpg", true));
            planet.Add(new Planet(1, Planets.Mars, new Position(22, 0, 0), "mars.jpg", false));
            planet.Add(new Planet(1.5f, Planets.Jupiter, new Position(28, 0, 0), "jupiter.jpg", false));
            planet.Add(new Planet(1.2f, Planets.Saturn, new Position(35, 0, 0), "saturn.bmp", false));
            planet.Add(new Planet(1.2f, Planets.Uranus, new Position(41, 0, 0), "uranus.jpg", false));
            planet.Add(new Planet(1.2f, Planets.Neptune, new Position(51, 0, 0), "neptune.jpg", false));
            planet.Add(new Planet(1.2f, Planets.Pluto, new Position(60, 0, 0), "pluto.jpg", false));
            star.drawStars(5000);
            sun.Create();
            foreach (var item in planet)
            {
                item.Create();  
            }
        }

        public Camara Camara
        {
            get { return camara; }
        }

        public void DrawScene()
        {  
          
            star.Draw(); // draw the stars 
            sun.Paint(); // texture the sun 
            foreach (var item in planet)
            {
                item.Paint(); 
            }
        }
    }
}
