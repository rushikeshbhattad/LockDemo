﻿using System;
using System.Threading;

namespace LockDemo
{
    class DataAccess
    {
        public void PrintData(string str)
        {
            lock (this)
            {
                Monitor.Enter(this);
                Console.WriteLine("Writing " + str + " finished");
                Monitor.Exit(this);
            }
        }
    }
    class Program
    {
        static DataAccess da = new DataAccess();

        public static void Thread1()
        {
            Console.WriteLine("Thread 1 is Writing");
            da.PrintData("Welcome");
        }
        public static void Thread2()
        {
            Console.WriteLine("Thread 2 is Writing");
            da.PrintData("To Happy World");
        }
        static void Main(string[] args)
        {
            ThreadStart ts1 = new ThreadStart(Thread1);
            ThreadStart ts2 = new ThreadStart(Thread2);

            Thread t1 = new Thread(ts1);
            Thread t2 = new Thread(ts2);

            t1.Start();
            t2.Start();
            Console.ReadKey();
        }
    }
}