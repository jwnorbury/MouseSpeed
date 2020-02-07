using System;

namespace MouseSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                FlipMouseSpeed();
            }
            else
            {
                (uint speed, bool? acceleration) = GetInput(args);
                MouseHandler.SetMouseSpeed(speed);
                if (acceleration.HasValue)
                {
                    MouseHandler.SetMouseAcceleration(acceleration.Value);
                }
            }
        }

        private static void FlipMouseSpeed()
        {
            var mouseSpeed = MouseHandler.GetMouseSpeed();
            if (mouseSpeed == 4)
            {
                MouseHandler.SetMouseSpeed(10);
                MouseHandler.SetMouseAcceleration(true);
            }
            else
            {
                MouseHandler.SetMouseSpeed(4);
                MouseHandler.SetMouseAcceleration(false);
            }
        }

        private static (uint, bool?) GetInput(string[] args)
        {
            if (args.Length == 2)
            {
                return (GetMouseSpeedInput(args), GetMouseAccelerationInput(args));
            }
            else
            {
                return (GetMouseSpeedInput(args), null);
            }
        }

        private static uint GetMouseSpeedInput(string[] args)
        {
            if (!uint.TryParse(args[0], out uint speed))
            {
                throw new ArgumentException($"{args[0]} is not a number.");
            }

            return speed;
        }

        private static bool GetMouseAccelerationInput(string[] args)
        {
            if (!bool.TryParse(args[1], out bool acceleration))
            {
                throw new ArgumentException($"{args[1]} is not a bool.");
            }

            return acceleration;
        }
    }
}
