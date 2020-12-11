using CAREier.Interfaces;
using CAREier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAREier
{
    public static class Global
    {
        public static string ProductjsonLocation;
        public static string OrderjsonLocation;
        private static int index;
        public static Store FindShortest(string typesAlowed, bool UsseDeffculty, WorldPoint StartPoint, params Store[] UserPoints)
        {
            List<WorldPoint> WP = new List<WorldPoint>();
            WP.Add(StartPoint);
            foreach (Store item in UserPoints)
            {
                WP.Add(item.Location);
            }
            WorldPoint wpf = FindShortest(typesAlowed, UsseDeffculty, WP.ToArray());
            return UserPoints[index - 1];
        }
        public static Buyer FindShortest(string typesAlowed, bool UsseDeffculty, WorldPoint StartPoint, params Buyer[] UserPoints)
        {
            List<WorldPoint> WP = new List<WorldPoint>();
            WP.Add(StartPoint);
            foreach (Buyer item in UserPoints)
            {
                WP.Add(item.Location);
            }
            WorldPoint wpf = FindShortest(typesAlowed, UsseDeffculty, WP.ToArray());
            return UserPoints[index - 1];
        }
        public static Bringer FindShortest(string typesAlowed, bool UsseDeffculty, WorldPoint StartPoint, params Bringer[] UserPoints)
        {
            List<WorldPoint> WP = new List<WorldPoint>();
            WP.Add(StartPoint);
            foreach (Bringer item in UserPoints)
            {
                WP.Add(item.Location);
            }
            WorldPoint wpf = FindShortest(typesAlowed, UsseDeffculty, WP.ToArray());
            return UserPoints[index - 1];
        }
        public static WorldPoint FindShortest(string typesAlowed,bool UsseDeffculty, params WorldPoint[] points)
        {
            if (points.Length < 2) return points[0];
            WorldPoint startP = points[0];
            WorldPoint Closest = points[1];
            index = 1;
            Int64 Lenght = 99999999999999;
            double Def = 1;
            string[] typs = typesAlowed.Split(',');
            for (int i = 0; i < points.Length; i++)
            {
                if (UsseDeffculty) Def = points[i].Difficulty;
                if (!points[i].Contains(typs)) continue;
                    Int64 len = GetDist(startP.X, startP.Y, points[i].X, points[i].Y);
                if (len * Def < Lenght) {
                    Lenght = len;
                    Closest = points[i];
                    Def = Closest.Difficulty;
                    index = i;
                }
            }
            return Closest;
        }
        public static Int64 GetDist(Int64 XA, Int64 YA, Int64 XB, Int64 YB)
        {
            return (XA - XB) * (XA - XB) + (YA - YB) * (YA - YB);
        }
    }
    public class WorldPoint
    {
        public Int64 X;
        public Int64 Y;
        public double Difficulty;
        private TagSystem Tags;
        public string UnicID(string Name)
        {
            return $"{X}:{Y}:{Name}";
        }
   
        public WorldPoint(Int64 x, Int64 y)
        {
            this.X = x;
            this.Y = y;
            Difficulty = 1;
            Tags = new TagSystem();
        }
        public WorldPoint(Int64 x, Int64 y, double difficulty, string type)
        {
            this.X = x;
            this.Y = y;
            Difficulty = difficulty;
            Tags = new TagSystem();
        }
        

        public override string ToString()
        {
            return $"{X},{Y} type:{Tags.ToString()} Difficulty:{Difficulty}";
        }
        

        public bool Contains(params string[] tags)
        {
            return Tags.Contains(tags);
        }

    }
}
