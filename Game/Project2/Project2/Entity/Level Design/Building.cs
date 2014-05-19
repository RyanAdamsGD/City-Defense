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
    enum BuildingType{
        Bridge,
        Building_With_Tower,
        Building,
        Circular_Tower,
        City_Building,
        Iffel_Tower,
        Pointed_Tower,
        Skyscraper,
        Tower,
        Triangle_Building,
        Warehouse

    }
    class Building:Entity
    {
        public static Building_Manager managers;
        public Building(Game game, BuildingType type, Collidable parentCollidable, Vector3 position,float scale = 1.0f, bool rotate90 = false)
            :base(game)
        {
            addComponent(new Spatial(game, this,Vector3.Zero));
            if(rotate90)
                getComponent<Spatial>().transform = Matrix.CreateScale(scale) * Matrix.CreateRotationY((float)Math.PI/2.0f) * Matrix.CreateTranslation(position);
            else
                getComponent<Spatial>().transform = Matrix.CreateScale(scale) * Matrix.CreateTranslation(position);

            Model m;
            switch (type)
            {
                case BuildingType.Bridge:
                    m = Game.Content.Load<Model>(@"Models\Buildings\Bridge");
                    break;
                case BuildingType.Building_With_Tower:
                    m = Game.Content.Load<Model>(@"Models\Buildings\Building_With_Tower");
                    break;
                case BuildingType.Building:
                    m = Game.Content.Load<Model>(@"Models\Buildings\Building_02");
                    break;
                case BuildingType.Circular_Tower:
                    m = Game.Content.Load<Model>(@"Models\Buildings\Circular_Tower");
                    break;
                case BuildingType.City_Building:
                    m = Game.Content.Load<Model>(@"Models\Buildings\City_Building");
                    break;
                case BuildingType.Iffel_Tower:
                    m = Game.Content.Load<Model>(@"Models\Buildings\Iffel_Tower");
                    break;
                case BuildingType.Pointed_Tower:
                    m = Game.Content.Load<Model>(@"Models\Buildings\Pointed_Tower");
                    break;
                case BuildingType.Skyscraper:
                    m = Game.Content.Load<Model>(@"Models\Buildings\Skyscraper");
                    break;
                case BuildingType.Tower:
                    m = Game.Content.Load<Model>(@"Models\Buildings\Tower");
                    break;
                case BuildingType.Triangle_Building:
                    m = Game.Content.Load<Model>(@"Models\Buildings\Triangle_Building");
                    break;
                case BuildingType.Warehouse:
                    m = Game.Content.Load<Model>(@"Models\Buildings\Warehouse");
                    break;
                default:
                    m = Game.Content.Load<Model>(@"Models\Buildings\Building");
                    break;
            }
            addComponent(new Drawable3D(game,this,m));
            addComponent(new Collidable(game, this, CollisionType.environment, onHit, 0, 1000, parentCollidable, getComponent<Drawable3D>().modelBoundingBox));
        }

        public static void init(Game game)
        {
            managers = new Building_Manager(game);
            managers.buildBlock(Vector3.Zero);
            managers.buildBlock(new Vector3(Block.getBlockSizeBuildings().X + (5 * Block.xShift), 0, 0));
            managers.buildBlock(new Vector3(0, 0, Block.getBlockSizeBuildings().Z + (5 * Block.zShift)));
            
            managers.buildBlock(new Vector3(-Block.getBlockSizeBuildings().X - (5 * Block.xShift), 0, 0));
            managers.buildSpecial(new Vector3(0, 0, -Block.getBlockSizeBuildings().Z - (5 * Block.zShift)));
            
            managers.buildSpecial(new Vector3(-Block.getBlockSizeBuildings().X - (7 * Block.xShift), 0, -Block.getBlockSizeBuildings().Z - (7 * Block.zShift)));
            
            managers.buildBlock(new Vector3(Block.getBlockSizeBuildings().X + (5 * Block.xShift), 0, Block.getBlockSizeBuildings().Z + (5 * Block.zShift)));
            managers.buildBlock(new Vector3(Block.getBlockSizeBuildings().X + (5 * Block.xShift), 0, Block.getBlockSizeBuildings().Z + (5 * Block.zShift)));
        }

        public void onHit(eCollision e)
        {

        }
    }
}
