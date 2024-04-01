using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace myAssignment4
{
    class Clock
    {
        public event Action<Clock> AlarmEvent;
        public event Action<Clock> TickEvent;
        public int hour, minute, second;
        public int alarmHour, alarmMinute, alarmSecond;
        private bool stop = false;
        public Clock()
        {
            TickEvent += c => Console.WriteLine("Tick!   " + hour + " : " + minute + " : " + second );
            AlarmEvent += c => Console.WriteLine("Alarm!");
        }
        public void Run()
        {
            stop = false;
            DateTime now = DateTime.Now;
            //初始化闹钟时间
            hour = now.Hour;
            minute = now.Minute;
            second = now.Second;
            alarmHour = now.Hour;
            alarmMinute = now.Minute;
            alarmSecond = now.Second + 10;
            //判断闹钟时间是否进位
            if (alarmSecond > 59)
            {
                alarmMinute++;
                alarmSecond -= 60;
            }
            if (alarmMinute > 59)
            {
                alarmHour++;
                alarmMinute -= 60;
            }
            alarmHour %= 24;
            //循环采集时间并判断是否响闹钟
            while (!stop) {
                TickEvent(this);
                if (hour == alarmHour && minute == alarmMinute && second == alarmSecond)
                {
                    stop = true;
                    AlarmEvent(this);
                }
                now = DateTime.Now;
                hour = now.Hour;
                minute = now.Minute;
                second = now.Second;
                Thread.Sleep(1000);
            }
            Console.WriteLine("Clock is stopped!");
        }
        public void Stop()
        {
            this.stop = true;
        }
    }
}