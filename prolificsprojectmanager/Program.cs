using System;
using System.Collections.Generic;
using ppm.model;
using ppm.ui.cli;

namespace ppm 
{
    class program
    {
        public static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            cmd co = new cmd();
            co.startprogram();

        }
    }
}


