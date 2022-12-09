﻿namespace _03.Raiding.IO
{
    using System;

    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Write(object value) => Console.Write(value);

        public void WriteLine(object value) => Console.WriteLine(value);
    }
}