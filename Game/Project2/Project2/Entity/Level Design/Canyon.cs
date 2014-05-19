using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project2.Component;
using Project2.Events;
using Project2.Entity_Managers;

namespace Project2.Entity
{
    //yoffset = 12.546
    enum CanyonType
    {
        Canyon1,
        Canyon2,
        Canyon3,
        Canyon4,
        Canyon5
    }
    class Canyon : Entity
    {
        public static Building_Manager manager;
        public CanyonType type;
        public static Vector3 canyon1Offset = new Vector3(22.235f, 0f, -23.689f);
        public static Vector3 canyon2Offset = new Vector3(36.021f, 0f, -23.689f);
        public static Vector3 canyon3Offset = new Vector3(36.021f, 0f, -22.235f);
        public static Vector3 canyon4Offset = new Vector3(22.235f, 0f, -22.235f);
        public static Vector3 canyon5Offset = new Vector3(21.835f, 0f, -36.021f); 

        public Canyon(Game game, CanyonType type, Collidable parentCollidable, Vector3 position, float scale, float rotation = 0.0f)
            : base(game)
        {
            addComponent(new Spatial(game, this, Vector3.Zero));
            
            Model m;
            this.type = type;
            switch (type)
            {
                case CanyonType.Canyon1:
                    m = Game.Content.Load<Model>(@"Models\Canyon\Canyon1");
                    break;
                case CanyonType.Canyon2:
                    m = Game.Content.Load<Model>(@"Models\Canyon\Canyon2");
                    break;
                case CanyonType.Canyon3:
                    m = Game.Content.Load<Model>(@"Models\Canyon\Canyon3");
                    break;
                case CanyonType.Canyon4:
                    m = Game.Content.Load<Model>(@"Models\Canyon\Canyon4");
                    break;
                case CanyonType.Canyon5:
                    m = Game.Content.Load<Model>(@"Models\Canyon\Canyon5");
                    break;
                default:
                    m = Game.Content.Load<Model>(@"Models\Canyon\Canyon5");
                    break;
            }
            getComponent<Spatial>().transform = Matrix.CreateRotationY(rotation) * Matrix.CreateScale(new Vector3(scale, scale * 2, scale)) ;
            getComponent<Spatial>().position = position;
            addComponent(new Drawable3D(game, this, m));
            addComponent(new Collidable(game, this, CollisionType.environment, onHit, 0, 1000, parentCollidable, getComponent<Drawable3D>().modelBoundingBox));
        }

        public static void init(Game game)
        {
            manager = new Building_Manager(game);
            manager.buildCanyon(new Vector3(6000,0,1500));
        }

        public void onHit(eCollision e)
        {

        }
    }
}
