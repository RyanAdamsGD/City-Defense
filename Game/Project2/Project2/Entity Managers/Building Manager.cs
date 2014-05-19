using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project2.Entity;
using Project2.Component;
using Project2.Events;
using Microsoft.Xna.Framework;

namespace Project2.Entity_Managers
{
    class Building_Manager :Entity.Entity
    {
        List<Block> blockList = new List<Block>();
        public Building_Manager(Game game):
            base(game)
        {
            addComponent(new Spatial(game, this, Vector3.Zero));
            BoundingBox bb = new BoundingBox(Vector3.Zero, Vector3.Zero);
            addComponent(new Collidable(game, this, CollisionType.environment, onHit, 0, 0, bb));
        }

        public void onHit(eCollision e)
        {

        }

        public void buildBlock(Vector3 start)
        {
            Block newBlock = new Block(Game, start, getComponent<Collidable>());
            newBlock.buildBlock();
            blockList.Add(newBlock);
            adjustPosition();
        }

        public void buildStreet(Vector3 start)
        {
            Block newBlock = new Block(Game, start, getComponent<Collidable>());
            newBlock.buildStreet();
            blockList.Add(newBlock);
            adjustPosition();
        }

        public void buildSpecial(Vector3 start)
        {
            Block newBlock = new Block(Game, start, getComponent<Collidable>());
            newBlock.buildSpecial();
            blockList.Add(newBlock);
            adjustPosition();
        }

        public void buildCanyon(Vector3 start)
        {
            Block newBlock = new Block(Game, start, getComponent<Collidable>());
            newBlock.buildCanyon();
            blockList.Add(newBlock);
            adjustPosition();
        }

        private void adjustPosition()
        {
            Vector3 minPoint = Vector3.Zero;
            Vector3 maxPoint = Vector3.Zero;

            foreach (var block in blockList)
            {
                Vector3 size = block.getBlockSizeMin();
                if (size.X < minPoint.X)
                {
                    minPoint.X = size.X;
                }
                if (size.Y < minPoint.Y)
                {
                    minPoint.Y = size.Y;
                }
                if (size.Z < minPoint.Z)
                {
                    minPoint.Z = size.Z;
                }
                size = block.getBlockSizeMax();
                if (size.X > maxPoint.X)
                {
                    maxPoint.X = size.X;
                } 
                if (size.Y > maxPoint.Y)
                {
                    maxPoint.Y = size.Y;
                }
                if (size.Z > maxPoint.Z)
                {
                    maxPoint.Z = size.Z;
                }
            }

            getComponent<Collidable>().boundingBox = new BoundingBox(minPoint, maxPoint);
        }
    }
}
