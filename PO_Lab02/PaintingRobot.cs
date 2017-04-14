using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class PaintingRobot
    {
        public virtual double GetPaintedLength(double time)
        {
            return time;
        }
        public override string ToString()
        {
            return "basic robot: \n";
        }
    }

    public abstract class RobotDecorator : PaintingRobot
    {
        protected PaintingRobot robot;

        public RobotDecorator(PaintingRobot _robot)
        {
            robot = _robot;
        }
        public override double GetPaintedLength(double time)
        {
            return robot.GetPaintedLength(time);
        }
        public override string ToString()
        {
            return robot.ToString();
        }
    }
    class RobotNTimes : RobotDecorator
    {
        int n;
        public RobotNTimes(PaintingRobot r,int _n = 2):base(r)
        {
            n = _n;
        }

        public override double GetPaintedLength(double time)
        {
            return base.GetPaintedLength(time) * n;
        }

        public override string ToString()
        {
            base.ToString();
            if (n == 2) return base.ToString() + "Two times faster Robot \n";
            else return base.ToString() + n.ToString() + " times faster Robot \n";
        }
    }
    class RobotplusN : RobotDecorator
    {
        int n;
        public RobotplusN(PaintingRobot r, int n1 = 1):base(r)
        {
            this.n = n1;
        }

        public override double GetPaintedLength(double time)
        {
            return base.GetPaintedLength(time) + n;
        }
        public override string ToString()
        {
            return base.ToString() + "Add " +n.ToString() +" Robot \n";
        }
    }
    class RobotLog : RobotDecorator
    {
        public RobotLog(PaintingRobot r) : base(r)
        {
            
        }

        public override double GetPaintedLength(double time)
        {
            return base.GetPaintedLength(time) * Math.Log(time);
        }
        public override string ToString()
        {
            return base.ToString() + "N*log(N) Robot \n";
        }
    }
    class Compaund : PaintingRobot
    {
        PaintingRobot[] robots;
        PaintingRobot curr;
        public Compaund(params PaintingRobot[] r)
        {
            robots = new PaintingRobot[r.GetLength(0)];
            for (int i = 0; i < r.GetLength(0); i++)
            {
                robots[i] = r[i];
            }
        }
        public override double GetPaintedLength(double time)
        {
            double max = 0;

            foreach (var r in robots)
            {
                if (r.GetPaintedLength(time) > max)
                {
                    max = r.GetPaintedLength(time);
                    curr = r;
                }
            }
            return max;
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("Compound Max Robot\n");
            foreach(var r in robots)
            {
                s.Append(r.ToString());
            }
            return s.ToString();          
        }
    }  
}
