using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project2.Entity;
using Microsoft.Xna.Framework;
using Project2.Component;

namespace Project2.Entity_Managers
{
    class PowerUpManager:GameComponent
    {
        List<Shield> shieldList;
        List<PowerUp> powerUpList;

        public PowerUpManager(Game game)
            :base(game)
        {
            shieldList = new List<Shield>();
            powerUpList = new List<PowerUp>();
        }

        public void addShield(Shield s)
        {
            shieldList.Add(s);
        }

        public void removeShield(Shield s)
        {
            shieldList.Remove(s);
        }

        public void addPowerUp(PowerUp r)
        {
            powerUpList.Add(r);
        }

        public void removePowerUp(PowerUp r)
        {
            powerUpList.Remove(r);
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < shieldList.Count; i++)
			{
                shieldList[i].Update(gameTime);
            }
            for (int i = 0; i < powerUpList.Count; i++)
			{			 
                powerUpList[i].Update(gameTime);
            }
            base.Update(gameTime);
        }
    }
}
