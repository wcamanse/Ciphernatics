using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ciphernatic.Models;
using Microsoft.Owin.Hosting;
using Owin;

namespace Ciphernatic
{
    /// <summary>
    /// Author: Windell Noble Camanse
    /// Created : June 12, 2017
    /// Last Modified : June 12, 2017
    /// 
    /// This program performs hash cryptography.  Allows user to select hash type and generates hashed value
    /// base on the requested input.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            Console.Clear();
            var endprogram = false;

            // start program loop
            while (true)
            {
                // display welcome scroll and user options
                Console.WriteLine("-- WELCOME TO CIPHERNATIC-- ");
                HashAlgorithm.HashOptions();
                Console.WriteLine("----------------------------");
                Console.Write("Select your algorithm: ");
                // retrieve user input
                var selectedOption = Console.ReadLine();

                // define int parse value
                var optionValue = 999;
                // asses numeric value
                var valid = int.TryParse(selectedOption, out optionValue);
                // validate define input against enum values and input value is not zero
                if (Enum.IsDefined(typeof(HashOptions), optionValue) && optionValue!=0 && optionValue!=99)
                {
                    // request the value to be hashed
                    Console.Write("Enter a value to hash : ");
                    // retrieve user input
                    var inputValue = Console.ReadLine();
                    // parse input and display results
                    Ciphernatic((HashOptions)optionValue, inputValue, out endprogram);

                }else if (optionValue == 99)
                {
                    // parse input and display results
                    Ciphernatic((HashOptions)optionValue, "", out endprogram);
                }
                else if (optionValue == 0 && valid)
                {
                    // break from loop and end program
                    break;
                }

                // evaluate valid input 
                if (endprogram && valid)
                {
                    // if input value is zero and is a valid numeric
                    // break from loop and end program
                    break;
                }
                else
                {
                    
                    if (!valid)
                    {
                        // non numeric value
                        Console.WriteLine("Not a valid input, try again.  Click enter to restart....");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        // request user to restart program
                        Console.WriteLine("Click enter to restart program....");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }
        
        }

        /// <summary>
        /// Parse and initialize program base on the requested input parameter values
        /// </summary>
        /// <param name="options"></param>
        /// <param name="inputValue"></param>
        /// <param name="endprogram"></param>
        private static void Ciphernatic(HashOptions options, string inputValue, out bool endprogram)
        {


            // define default values
            var outputValue = "";
            var description = "";
            endprogram = false;

            // evaluate requested enum options
            switch (options)
            {
                case HashOptions.Exit:
                    endprogram = true;
                    return;
                case HashOptions.WebService:
                    CipherNaticWebServerInit();
                    return;
                default:
                    // define HashAlgorithm with input value
                    var output = HashAlgorithm.HashValue(options,inputValue);
                    outputValue = output.OutputValue;
                    description = output.Description;
                    break;
            }


            // evaluate if option is not 0
            if (options != HashOptions.Exit)
            {
                // display results
                Console.WriteLine("----------------------------");
                Console.WriteLine($"DESCRIPTION: {description}");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Hash Output Value : {outputValue}");
                Console.WriteLine("----------------------------");
            }



        }

        /// <summary>
        /// Initialize web server accessible through localhost port 8888
        /// </summary>
        private static void CipherNaticWebServerInit()
        {
            var baseAddress = "http://localhost:8888/";

            WebApp.Start<WebApiConfig>(baseAddress);
            Console.WriteLine("Web Server started...");
            Console.WriteLine("Open any web browser and copy/paste the following URI http://localhost:8888/pages/index.html");
            Console.ReadLine();

        }




    }
}
