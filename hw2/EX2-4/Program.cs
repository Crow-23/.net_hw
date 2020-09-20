using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EX4
{
    //委托时间和闹铃事件
    public delegate void SetBellTime(long time);
    public delegate void Alarm(long time);

    class Clock
    {
        //声明两个事件，一个闹钟，一个时间前进
        public event SetBellTime setBellTimeList;
        public event Alarm alarmList;

        public void Work()
        {
            long t = 0;
            while (true)
            {
                t++;
                if (t % 1 == 0) setBellTimeList?.Invoke(t);
                if (t % 3 == 0) alarmList?.Invoke(t);
                Thread.Sleep(1000);
            }
        }

        public void ShowTime(string time)
        {
            Console.WriteLine($"现在时间是 {time},每过3秒响一次");
        }
    }

    class Test
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var clock = new Clock();
                string time = DateTime.Now.ToLongTimeString().ToString();
                clock.ShowTime(time);
                clock.setBellTimeList += s => Console.WriteLine("Tick " + s);
                clock.alarmList += s => Console.WriteLine("Alarm " + s);
                clock.Work();
            }
        }
    }
}