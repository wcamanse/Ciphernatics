using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciphernatic.Models;

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
    class Program
    {
        static void Main(string[] args)
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
                if (Enum.IsDefined(typeof(HashOptions), optionValue) && optionValue!=0)
                {
                    // request the value to be hashed
                    Console.Write("Enter a value to hash : ");
                    // retrieve user input
                    var inputValue = Console.ReadLine();
                    // parse input and display results
                    Ciphernatic((HashOptions)optionValue, inputValue, out endprogram);

                }else if (optionValue == 0 && valid)
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
        static void Ciphernatic(HashOptions options, string inputValue, out bool endprogram)
        {
            // define HashAlgorithm with input value
            var hashValue = new HashAlgorithm {InputValue = inputValue};
            // define default values
            var outputValue = "";
            endprogram = false;

            // evaluate requested enum options
            switch (options)
            {
                case HashOptions.Exit:
                    endprogram = true;
                    return;
                case HashOptions.RipedMD160:
                    outputValue = hashValue.GenerateRIPEMD160Hash;
                    break;
                case HashOptions.SHA1:
                    outputValue = hashValue.GenerateSHA1Hash;
                    break;
                case HashOptions.SHA256:
                    outputValue = hashValue.GenerateSHA256Hash;
                    break;
                case HashOptions.SHA384:
                    outputValue = hashValue.GenerateSHA384Hash;
                    break;
                case HashOptions.SHA512:
                    outputValue = hashValue.GenerateSHA512Hash;
                    break;
                case HashOptions.MD5:
                    outputValue = hashValue.GenerateMD5Hash;
                    break;
                case HashOptions.SHA1Asymmetric:
                    outputValue = hashValue.GenerateSHA1Asymmetric;
                    break;
                case HashOptions.SHA256Asymmetric:
                    outputValue = hashValue.GenerateSHA256Asymmetric;
                    break;
                case HashOptions.SHA384Asymmetric:
                    outputValue = hashValue.GenerateSHA384Asymmetric;
                    break;
                case HashOptions.SHA512Asymmetric:
                    outputValue = hashValue.GenerateSHA512Hash;
                    break;
                case HashOptions.MD5Asymmetric:
                    outputValue = hashValue.GenerateMD5Asymmetric;
                    break;
                default:
                    break;
            }


            // evaluate if option is not 0
            if (options != HashOptions.Exit)
            {
                // display results
                Console.WriteLine("----------------------------");
                Console.WriteLine($"DESCRIPTION: {hashValue.Description}");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Hash Output Value : {outputValue}");
                Console.WriteLine("----------------------------");
            }



        }
    }
}
