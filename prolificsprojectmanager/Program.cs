using System;
using System.Collections.Generic;
using ppm.model;
using ppm.ui.cli;

namespace ppm 
{
    static class Program
    {
        public static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            Cmd co = new Cmd();
            co.startprogram();

        }
    }
}


