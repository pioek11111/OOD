using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    class Program
    {
        static void Main(string[] args)
        {
            PaintingRobot[] robots = new PaintingRobot[5];
            robots[0] = new PaintingRobot();
            robots[1] = new RobotNTimes(robots[0]);
            robots[2] = new RobotLog(robots[1]);
            robots[3] = new RobotplusN(robots[2]);
            robots[4] = new Compaund(robots[1], robots[2], robots[3]);

            foreach (var robot in robots)
            {
                Console.WriteLine($"Current robot: {robot}");
                Console.WriteLine($"Painted length in 2 time units: {robot.GetPaintedLength(2)}.");
                Console.WriteLine($"Painted length in 3 time units: {robot.GetPaintedLength(3)}.");
                Console.WriteLine("");
            }

            PaintingRobot robot2 = new PaintingRobot();            
            robot2 = new RobotNTimes(robot2);
            robot2 = new RobotplusN(robot2,10);
            robot2 = new RobotNTimes(robot2,3);

            Console.WriteLine($"Current robot: {robot2}");
            Console.WriteLine($"Painted length in 2 time units: {robot2.GetPaintedLength(2)}.");
            Console.WriteLine($"Painted length in 3 time units: {robot2.GetPaintedLength(3)}.");
            Console.WriteLine("");
        }
    }
}
