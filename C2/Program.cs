using System;
using System.Threading;
namespace C2
{
    class AlarmClock
    {
        private static long second = 0;
        private static long minute = 0;
        private static long hour = 0;
        private static long asecond = 0;
        private static long aminute = 0;
        private static long ahour = 0;
        public event Action<Object> Tick = delegate
        {
            ++second;
            if (second >= 60)
            {
                minute += 1;
                second = 0;
            }
            if (minute >= 60)
            {
                hour += 1;
                minute = 0;
            }
            if (hour >= 24)
                hour = 0;
            Console.WriteLine("嘀嗒嘀嗒");
            Console.WriteLine($"Time: {hour.ToString("00")} : {minute.ToString("00")} : {second.ToString("00")}");
        };
        public event Action<Object> Alarm =
            delegate (Object obj)
            {
                if (ahour == hour && aminute == minute && asecond == second)
                {
                    Console.WriteLine("闹钟响了");
                    Console.WriteLine("闹钟响了");
                    Console.WriteLine("闹钟响了");
                }
            };
        public void Run()
        {
            while (true)
            {
                Tick(this);
                Alarm(this);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        public void Run(long newh, long newm, long news)
        {
            hour = newh;
            minute = newm;
            second = news;
        }

        public void SetAlarm(long h, long m, long s)
        {
            ahour = h;
            aminute = m;
            asecond = s;
        }
    }
    class Form
    {
        public AlarmClock clk = new AlarmClock();

        public void SetTime(long h, long m, long s)
        {
            clk.Run(h, m, s);
        }

        public void SetAlarm(long h, long m, long s)
        {
            clk.SetAlarm(h, m, s);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Form f1 = new Form();
            f1.SetTime(00, 0, 0);
            f1.SetAlarm(00, 0, 10);
            f1.clk.Run();
        }
    }
}
