using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SpaceBunnyJump.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpaceBunnyJump.Classes;
using System.Drawing;
using Point = System.Drawing.Point;

namespace SpaceBunnyJump.Logic
{
    internal class GameLogic : IGameModel, IGameControl
    {
        public event EventHandler Changed;
        public event EventHandler GameOver;

        public System.Collections.Generic.List<Platform> Platforms { get; set; }

        public System.Collections.Generic.List<Bullet> Shots { get; set; }

        public System.Collections.Generic.List<Alien> Aliens { get; set; }

        public System.Collections.Generic.List<Carrot> Carrots { get; set; }

        public System.Collections.Generic.List<Diamond> Diamonds { get; set; }

        public System.Collections.Generic.List<Shield> Shields { get; set; }

        public System.Collections.Generic.List<Shoe> Shoes { get; set; }

        public System.Windows.Size area { get; set; }
        //public System.Drawing.Rectangle playerHitbox { get; set; }


        public Player player { get; set; }


        public GameLogic()
        {
            Platforms = new List<Platform>();
            Shots = new List<Bullet>();
            Aliens = new List<Alien>();
            Carrots = new List<Carrot>();
            Diamonds = new List<Diamond>();
            Shields = new List<Shield>();
            Shoes = new List<Shoe>();
            PlatformController.platforms = new System.Collections.Generic.List<Platform>();
            //PlatformController.startPlatformPosY = 400;
            //PlatformController.score = 0;
            PlatformController.GenerateStartSequence();
            Platforms = PlatformController.platforms;
            platformExtra();

            this.player = new Player();

        }
        public void TimeUpdate()
        {
            FollowPlayer();
            

            int[] coords = new int[] { ((int)player.position.Y), ((int)player.position.X), };
            int i = coords[0];
            int j = coords[1];
            if (j < 750 && !PlatformHitbox())
            {
                j = j + 5;
            }
            if (j == 750)
            {
                player.Alive = false;
            }

            if (CarrotHitbox())
            {
                player.Ammo = player.Ammo + 1;
            }
            if (DiamondHitbox())
            {
                player.Score = player.Score + 10;
            }

            if (AlienHitbox())
            {
                player.Alive = false;
            }

            if (ShieldHitbox())
            {
                player.Shield = true;
            }

            if (ShoeHitbox())
            {
                player.Shoe = player.Shoe+3;
            }

            player.position = new Point(j, i);
            player.Move();


            
            BulletTravel();
            BulletFlyOut();
            AlienDied();
            CarrotRemove();
            RemoveDiamonds();
            RemoveShields();
            RemoveShoes();


            if (player.Alive == false)
            {
                GameOver?.Invoke(this, null);
            }

            Changed?.Invoke(this, null);
        }
        public bool PlatformHitbox()
        {
            bool platformstatus = false;
            int i = 0;
            while (platformstatus == false && i < Platforms.Count)
            {
                if (
                    player.hitbox.IntersectsWith(Platforms[i].hitbox) &&
                    player.hitbox.BottomLeft.Y < Platforms[i].hitbox.BottomLeft.Y     
                    )
                {
                    platformstatus = true;
                }
                else
                {
                    platformstatus = false;
                }
                i++;
                
            }
            return platformstatus;
        }
        public bool AlienHitbox()
        {
            bool hit = false;
            int i = 0;
            while (hit == false && i < Aliens.Count)
            {
                if (player.hitbox.IntersectsWith(Aliens[i].hitbox) && player.Shield == false)
                {
                    hit = true;
                }
                else if(player.hitbox.IntersectsWith(Aliens[i].hitbox) && player.Shield == true)
                {
                    hit = false;
                    Aliens[i].Alive = false;
                    AlienDied();
                    player.Shield = false;
                }
                else
                {
                    hit = false;
                }
                i++;

            }
            return hit;
        }

        public bool CarrotHitbox()
        {
            bool hit = false;
            int i = 0;
            while (hit == false && i < Carrots.Count)
            {
                if (player.hitbox.IntersectsWith(Carrots[i].hitbox))
                {
                    hit = true;
                    Carrots[i].Alive = false;
                }
                else
                {
                    hit = false;
                }
                i++;

            }
            return hit;
        }
        public bool DiamondHitbox()
        {
            bool hit = false;
            int i = 0;
            while (hit == false && i < Diamonds.Count)
            {
                if (player.hitbox.IntersectsWith(Diamonds[i].hitbox))
                {
                    hit = true;
                    Diamonds[i].Alive = false;
                }
                else
                {
                    hit = false;
                }
                i++;
            }
            return hit;
        }
        public bool ShieldHitbox()
        {
            bool hit = false;
            int i = 0;
            while (hit == false && i < Shields.Count)
            {
                if (player.hitbox.IntersectsWith(Shields[i].hitbox))
                {
                    hit = true;
                    Shields[i].Alive = false;
                }
                else
                {
                    hit = false;
                }
                i++;

            }
            return hit;
        }
        public bool ShoeHitbox()
        {
            bool hit = false;
            int i = 0;
            while (hit == false && i < Shoes.Count)
            {
                if (player.hitbox.IntersectsWith(Shoes[i].hitbox))
                {
                    hit = true;
                    Shoes[i].Alive = false;
                }
                else
                {
                    hit = false;
                }
                i++;

            }
            return hit;
        }


        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;

 
        }
        //public enum GameItems
        //{
        //    player, platform, enemy, bonus, air
        //}


        public enum Directions
        {
            left, right, space//jump
        }
        



        public void HorizontalMove(Directions direction)
        {
            int[] coords = new int[] { ((int)player.position.Y), ((int)player.position.X), };
            int i = coords[0];
            int j = coords[1];
            int old_i = i;
            int old_j = j;
            switch (direction)
            {
                //case Directions.jump:
                //    if (j - 1 >= 0)
                //    {
                //        j = j - 80;
                //    }
                //    break;
                case Directions.left:
                    if (i - 40 >= 0)
                    {
                        i = i - 40;
                    }
                    else
                    {
                        i = i - 40;
                        i = (int)area.Width + i;
                    }
                    break;
                case Directions.right:
                    if (i + 40 < area.Width)
                    {
                        i = i + 40;
                    }
                    else
                    {
                        i = i + 40;
                        i = i - (int)area.Width;
                    }
                    break;
                default:
                    break;
            }
            player.position = new Point(j, i);
            player.Move();

            //if (VisualMap[i, j] == GameItems.air)
            //{
            //    VisualMap[i, j] = GameItems.player;
            //    VisualMap[old_i, old_j] = GameItems.air;
            //}
        }


        public void Jump(bool jump)
        {
            //var coords = WhereAmI();
            int[] coords = new int[] { ((int)player.position.Y), ((int)player.position.X), };
            int i = coords[0];
            int j = coords[1];
            int old_i = i;
            int old_j = j;
            if (PlatformHitbox())
            {
                if (player.Shoe == 0)
                {
                    if (jump && j - 160 >= 0)
                    {
                        j = j - 160;

                    }

                }
                else
                {
                    if (jump && j - 200 >= 0)
                    {
                        j = j - 200;
                        player.Shoe = player.Shoe - 1;
                    }
                }

                player.position = new Point(j, i);
                player.Move();
            }
        }



        public void Shoot(bool shoot)
        {
            if (player.Ammo > 0)
            {
                
                Shots.Add(new Bullet(player.position));
                player.Ammo = player.Ammo - 1;

            }
        }
        public void BulletTravel()
        {
            foreach (var item in Shots)
            {
                int shotlocation = item.position.X;

                foreach (var alien in Aliens)
                {
                    if (item.hitbox.IntersectsWith(alien.hitbox))
                    {
                        alien.Alive = false;
                        item.flyOut = true;
                    }
                }

                if (shotlocation > 10)
                {
                    shotlocation = shotlocation - 10;
                    item.position = new Point(shotlocation, item.position.Y);
                    item.Move();
                }
                else
                {
                   item.flyOut = true;
                }
                


            }
        }
        public void AlienDied()
        {
            for (int i = Aliens.Count - 1; i >= 0; i--)
            {
                if (Aliens[i].Alive == false)
                {
                    Aliens.RemoveAt(i);
                    player.Score = player.Score + 100;
                }
                    
            }
        }

        public void CarrotRemove()
        {
            for (int i = Carrots.Count - 1; i >= 0; i--)
            {
                if (Carrots[i].Alive == false)
                {
                    Carrots.RemoveAt(i);
                }

            }
        }

        public void BulletFlyOut()
        {
            for (int i = Shots.Count - 1; i >= 0; i--)
            {
                if (Shots[i].flyOut)
                    Shots.RemoveAt(i);
            }
        }

        public void platformExtra()
        {
            foreach (var item in Platforms)
            {
                if (item.BonusAlreadyLoaded == false)
                {


                    if (item.bonus == Platform.BonusItem.alien)
                    {
                        Aliens.Add(new Alien(new Point(item.transform.position.X - 100, item.transform.position.Y - 40)));

                    }
                    if (item.bonus == Platform.BonusItem.carrot)
                    {
                        Carrots.Add(new Carrot(new Point(item.transform.position.X - 70, item.transform.position.Y - 10)));

                    }
                    if (item.bonus == Platform.BonusItem.diamond)
                    {
                        Diamonds.Add(new Diamond(new Point(item.transform.position.X - 30, item.transform.position.Y - 5)));

                    }
                    if (item.bonus == Platform.BonusItem.shield)
                    {
                        Shields.Add(new Shield(new Point(item.transform.position.X - 70, item.transform.position.Y-20)));

                    }

                    if (item.bonus == Platform.BonusItem.shoe)
                    {
                        Shoes.Add(new Shoe(new Point(item.transform.position.X - 70, item.transform.position.Y - 20)));

                    }
                }
            }
        }

        public void FollowPlayer()
        {

            if (player.position.X < 350)
            {
                foreach (var item in Platforms)
                {
                    item.BonusAlreadyLoaded = true;
                }
                ////PlatformController.GenerateRandomSequence();
                ////Platforms = PlatformController.platforms;
                while (Platforms.Last().transform.position.X > 10)
                {
                    Platforms.Add(PlatformController.GenerateRandomPlatform(Platforms.Last().transform.position.X));
                }
                foreach (var item in Platforms)
                {
                    item.transform.position.X += 100;
                    item.Move();
                }

                int newPosition = player.position.X + 100;
                player.position = new Point(newPosition, player.position.Y);
                player.Move();



                foreach (var item in Aliens)
                {
                    int newAlienPosition = item.position.X + 100;
                    item.position = new Point(newAlienPosition, item.position.Y);
                    item.Move();
                }

                foreach (var item in Carrots)
                {
                    int newCarrotPosition = item.position.X + 100;
                    item.position = new Point(newCarrotPosition, item.position.Y);
                    item.Move();
                }
                foreach (var item in Diamonds)
                {
                    int newDiamondPosition = item.position.X + 100;
                    item.position = new Point(newDiamondPosition, item.position.Y);
                    item.Move();
                }

                foreach (var item in Shields)
                {
                    int newShieldPosition = item.position.X + 100;
                    item.position = new Point(newShieldPosition, item.position.Y);
                    item.Move();
                }

                foreach (var item in Shoes)
                {
                    int newShoePosition = item.position.X + 100;
                    item.position = new Point(newShoePosition, item.position.Y);
                    item.Move();
                }

                foreach (var item in Platforms)
                {
                    if (item.transform.position.X > 800)
                    {
                        item.visible = false;
                    }
                }


                platformExtra();
                RemovePlatform();
                RemoveDiamonds();
                RemoveShields();
                RemoveShoes();
                player.Score = player.Score + 50;
                
            }            

        }

        public void RemovePlatform()
        {
            for (int i = Platforms.Count - 1; i >= 0; i--)
            {
                if (Platforms[i].visible == false)
                    Platforms.RemoveAt(i);
            }
        }
        public void RemoveDiamonds()
        {
            for (int i = Diamonds.Count - 1; i >= 0; i--)
            {
                if (Diamonds[i].Alive == false)
                {
                    player.Score = player.Score + 20;
                    Diamonds.RemoveAt(i);
                }

            }
        }
        public void RemoveShields()
        {
            for (int i = Shields.Count - 1; i >= 0; i--)
            {
                if (Shields[i].Alive == false)
                {
                    Shields.RemoveAt(i);
                }

            }
        }
        public void RemoveShoes()
        {
            for (int i = Shoes.Count - 1; i >= 0; i--)
            {
                if (Shoes[i].Alive == false)
                {
                    Shoes.RemoveAt(i);
                }

            }
        }
    }
}
