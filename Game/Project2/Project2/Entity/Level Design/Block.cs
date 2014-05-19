using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Project2.Component;
using Project2.Events;
using Project2.Entity_Managers;

namespace Project2.Entity
{
    class Block: Entity
    {
        List<Entity> buildingList = new List<Entity>();
        public const float xShift = 100;
        public const float zShift = 120;
        public const float maxHeight = 1400.0f;
        private const float canyonScale = 60.0f;
        private int count = 0;

        public Block(Game game, Vector3 position, Collidable parentCollidable)
            :base(game)
        {
            addComponent(new Spatial(game, this, position));
            addComponent(new Collidable(game, this, CollisionType.environment, onHit, 0, 0, parentCollidable, new BoundingBox()));
        }

        public static Vector3 getBlockSizeBuildings()
        {
            return new Vector3((int)(12 * xShift), maxHeight, (int)(10 * zShift));
        }

        public Vector3 getBlockSizeMax()
        {
            return Vector3.Transform(getComponent<Collidable>().boundingBox.Max, getComponent<Spatial>().transform);
        }

        public Vector3 getBlockSizeMin()
        {
            return Vector3.Transform(getComponent<Collidable>().boundingBox.Min, getComponent<Spatial>().transform);            
        }

        public void buildBlock()
        {
            Vector3 start = getComponent<Spatial>().position;
            getComponent<Spatial>().position = start + new Vector3(xShift * 6, 0, zShift * 5);
            buildingList.Add(new Building(Game, BuildingType.Iffel_Tower, getComponent<Collidable>(), start, 250.0f));
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(3 * xShift, 0, 0 * zShift), 250.0f));
            buildingList.Add(new Building(Game, BuildingType.Warehouse, getComponent<Collidable>(), start + new Vector3(6 * xShift, 0, 0 * zShift), 280.0f));
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(12 * xShift, 0, 0 * zShift), 180.0f));
            //
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(0 * xShift, 0, 5 * zShift), 240.0f));
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(3 * xShift, 0, 5 * zShift), 190.0f));
            buildingList.Add(new Building(Game, BuildingType.Bridge, getComponent<Collidable>(), start + new Vector3(12 * xShift, 0, 5 * zShift), 170.0f, true));
            //
            buildingList.Add(new Building(Game, BuildingType.Circular_Tower, getComponent<Collidable>(), start + new Vector3(0 * xShift, 0, 10 * zShift), 270.0f));
            buildingList.Add(new Building(Game, BuildingType.Skyscraper, getComponent<Collidable>(), start + new Vector3(5 * xShift, 0, 10 * zShift), 220.0f));
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(12 * xShift, 0, 10 * zShift), 220.0f));
            adjustBoundingBox();
        }

        public void buildStreet()
        {
            Vector3 start = getComponent<Spatial>().position;
            getComponent<Spatial>().position = start + new Vector3(xShift * 6, 0, zShift * 5);
            buildingList.Add(new Building(Game, BuildingType.Pointed_Tower, getComponent<Collidable>(), start, 200.0f));
            buildingList.Add(new Building(Game, BuildingType.Skyscraper, getComponent<Collidable>(), start + new Vector3(3 * xShift, 0, 0 * zShift), 200.0f));
            buildingList.Add(new Building(Game, BuildingType.Circular_Tower, getComponent<Collidable>(), start + new Vector3(6 * xShift, 0, 0 * zShift), 170.0f));
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(12 * xShift, 0, 0 * zShift), 300.0f));
            //
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(0 * xShift, 0, 5 * zShift), 300.0f));
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(3 * xShift, 0, 5 * zShift), 250.0f));
            buildingList.Add(new Building(Game, BuildingType.Circular_Tower, getComponent<Collidable>(), start + new Vector3(6 * xShift, 0, 5 * zShift), 330.0f));
            buildingList.Add(new Building(Game, BuildingType.Pointed_Tower, getComponent<Collidable>(), start + new Vector3(12 * xShift, 0, 5 * zShift), 300.0f));
            //
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(0 * xShift, 0, 10 * zShift), 330.0f));
            buildingList.Add(new Building(Game, BuildingType.Skyscraper, getComponent<Collidable>(), start + new Vector3(6 * xShift, 0, 10 * zShift), 330.0f));
            buildingList.Add(new Building(Game, BuildingType.Circular_Tower, getComponent<Collidable>(), start + new Vector3(12 * xShift, 0, 10 * zShift), 300.0f));
            adjustBoundingBox();
        }

        public void buildSpecial()
        {
            Vector3 start = getComponent<Spatial>().position;
            getComponent<Spatial>().position = start + new Vector3(xShift * 6, 0, zShift * 5);
            buildingList.Add(new Building(Game, BuildingType.Iffel_Tower, getComponent<Collidable>(), start + new Vector3(0 * xShift, 0, 0 * zShift), 270.0f));

            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(-3 * xShift, 0, 0 * zShift), 220.0f));
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(0 * xShift, 0, -3 * zShift), 230.0f));
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(3 * xShift, 0, 0 * zShift), 190.0f));
            buildingList.Add(new Building(Game, BuildingType.Building, getComponent<Collidable>(), start + new Vector3(0 * xShift, 0, 3 * zShift), 220.0f));

            buildingList.Add( new Building(Game, BuildingType.Bridge, getComponent<Collidable>(), start + new Vector3(14 * xShift, 0, 8 * zShift), 140.0f, true));
            buildingList.Add( new Building(Game, BuildingType.Skyscraper, getComponent<Collidable>(), start + new Vector3(0 * xShift, 0, 6 * zShift), 205.0f));
            buildingList.Add( new Building(Game, BuildingType.Skyscraper, getComponent<Collidable>(), start + new Vector3(3 * xShift, 0, 6 * zShift), 200.0f));
            buildingList.Add( new Building(Game, BuildingType.Skyscraper, getComponent<Collidable>(), start + new Vector3(6 * xShift, 0, 6 * zShift), 95.0f));
            buildingList.Add( new Building(Game, BuildingType.Skyscraper, getComponent<Collidable>(), start + new Vector3(9 * xShift, 0, 6 * zShift), 230.0f));
            buildingList.Add( new Building(Game, BuildingType.Skyscraper, getComponent<Collidable>(), start + new Vector3(0 * xShift, 0, 12 * zShift), 200.0f));
            buildingList.Add( new Building(Game, BuildingType.Skyscraper, getComponent<Collidable>(), start + new Vector3(3 * xShift, 0, 12 * zShift), 240.0f));
            buildingList.Add( new Building(Game, BuildingType.Skyscraper, getComponent<Collidable>(), start + new Vector3(6 * xShift, 0, 12 * zShift), 240.0f));
            buildingList.Add( new Building(Game, BuildingType.Skyscraper, getComponent<Collidable>(), start + new Vector3(9 * xShift, 0, 12 * zShift), 205.0f));
            adjustBoundingBox();
        }

        public void buildCanyon()
        {
            Vector3 start = getComponent<Spatial>().position;
            Vector3 c2Offset = Vector3.Zero;
            c2Offset.Z -= Canyon.canyon1Offset.X*0.5f + Canyon.canyon2Offset.X*0.5f;
            Vector3 c3Offset = c2Offset;
            c3Offset.X -= Canyon.canyon3Offset.Z*0.5f + Canyon.canyon2Offset.Z*0.5f;
            Vector3 c4Offset = Vector3.Zero;
            c4Offset.X = c3Offset.X;
            Vector3 c5Offset = Vector3.Zero;
            c5Offset.Z -= Canyon.canyon1Offset.X * 0.5f + Canyon.canyon5Offset.X * 0.5f;
            c5Offset.X -= Canyon.canyon1Offset.Z * 0.5f + Canyon.canyon4Offset.Z + Canyon.canyon5Offset.Z * 0.5f;
            c2Offset *= canyonScale;
            c3Offset *= canyonScale;
            c4Offset *= canyonScale;
            c5Offset *= canyonScale;

            Canyon c1 = new Canyon(Game, CanyonType.Canyon1, getComponent<Collidable>(), start, canyonScale, (float)Math.PI * 0.5f);
            Canyon c2 = new Canyon(Game, CanyonType.Canyon2, getComponent<Collidable>(), start + c2Offset, canyonScale, (float)Math.PI * 0.5f);
            Canyon c3 = new Canyon(Game, CanyonType.Canyon3, getComponent<Collidable>(), start + c3Offset, canyonScale, (float)Math.PI * 0.5f);
            Canyon c4 = new Canyon(Game, CanyonType.Canyon4, getComponent<Collidable>(), start + c4Offset, canyonScale, (float)Math.PI * 0.5f);
            Canyon c5 = new Canyon(Game, CanyonType.Canyon5, getComponent<Collidable>(), start + c5Offset, canyonScale, (float)Math.PI * 0.5f);
            buildingList.Add(c1);
            buildingList.Add(c2);
            buildingList.Add(c3);
            buildingList.Add(c4);
            buildingList.Add(c5);
            adjustBoundingBox();            
        }

        public void onHit(eCollision e)
        {
            count++;
        }

        private void adjustBoundingBox()
        {
            Vector3 position = getComponent<Spatial>().position;
            Vector3 minPoint = position;
            Vector3 maxPoint = position;

            foreach (var mod in buildingList)
            {
                Vector3[] points = new Vector3[2];
                points[0] = Vector3.Transform(mod.getComponent<Drawable3D>().modelBoundingBox.Min, mod.getComponent<Spatial>().transform);
                points[1] = Vector3.Transform(mod.getComponent<Drawable3D>().modelBoundingBox.Max, mod.getComponent<Spatial>().transform);

                BoundingBox bb = BoundingBox.CreateFromPoints(points);
                Vector3 start = bb.Min;
                if (start.X < minPoint.X)
                {
                    minPoint.X = start.X;
                }
                if (start.Y < minPoint.Y)
                {
                    minPoint.Y = start.Y;
                }
                if (start.Z < minPoint.Z)
                {
                    minPoint.Z = start.Z;
                }
                start = bb.Max;
                if (start.X > maxPoint.X)
                {
                    maxPoint.X = start.X;
                }
                if (start.Y > maxPoint.Y)
                {
                    maxPoint.Y = start.Y;
                }
                if (start.Z > maxPoint.Z)
                {
                    maxPoint.Z = start.Z;
                }
            }
            getComponent<Collidable>().boundingBox = new BoundingBox(minPoint - position, maxPoint - position);
        }
    }
}
