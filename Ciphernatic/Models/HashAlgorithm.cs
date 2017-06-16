using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ciphernatic.Models
{
    /// <summary>
    /// This class performs .NET Encryption using System.Security.Cryptography HashAlgorithm
    /// HashAlgoithm class represents the base class for which all implementation of hashing algorithms must derive.
    /// 
    /// The main function is to generate hash value base on the required input.
    /// 
    /// 
    /// The following members are accessible for hash generation :
    /// [1] RIPEMD160 (Available .NET 3.5+)
    /// [2] SHA1
    /// [3] SHA256 (FIPS compliant in .NET 3.5)
    /// [4] SHA384 (FIPS compliant in .NET 3.5)
    /// [5] SHA512
    /// [6] MD5
    /// [7] SHA1 Asymmetric
    /// [8] SHA256 Asymmetric
    /// [9] SHA394 Asymmetric
    /// [10] SHA512 Asymmetric
    /// [11] MD5 Asymmetric
    /// [12] Web Service
    /// </summary>
    /// <remarks>
    /// Hashing Algorithm cannot operate on string; rather, hashing algorithms must operate on a sequence of bytes.
    /// </remarks>
    /// <example>
    /// General Usage: 
    /// var hashValue = new HashAlgorithm {InputValue = "Value"};
    /// var outputValue = hashValue.GenerateHash();
    /// </example>
    public class HashAlgorithm
    {
        /// <summary>
        /// Required input property for hash generation
        /// </summary>
        public string InputValue { get; set; }
        /// <summary>
        /// Required output property to display hash algorithm description
        /// </summary>
        public string Description { get; set; }

        public string OutputValue { get; set; }

        /// <summary>
        /// Returns encoded inputValue to ASCII Bytes
        /// </summary>
        private byte[] InputBytes => Encoding.ASCII.GetBytes(InputValue);

        /// <summary>
        /// Generate and returns hash value using RIPEMD 160 Hash Algorithm base on the requested InputBytes value
        /// </summary>
        /// <returns></returns>
        public string GenerateRIPEMD160Hash
        {
            get
            {
                var algo = new RIPEMD160Managed();
                Description =
                    "RIPEMD (RACE Integrity Primitives Evaluation Message Digest) is a family of cryptographic hash functions developed in Leuven, Belgium, by Hans Dobbertin, Antoon Bosselaers and Bart Preneel at the COSIC research group at the Katholieke Universiteit Leuven, and first published in 1996. RIPEMD was based upon the design principles used in MD4, and is similar in performance to the more popular SHA-1.";

                return BitConverter.ToString(algo.ComputeHash(InputBytes));
            }

        }

        /// <summary>
        /// Generate and returns hash value using SHA1 Hash Algorithm base on the requested InputBytes value
        /// </summary>
        public string GenerateSHA1Hash
        {
            get
            {
             
                var algo = new SHA1Managed();
                Description =
                    "SHA-1 (Secure Hash Algorithm 1) is a cryptographic hash function designed by the United States National Security Agency and is a U.S. Federal Information Processing Standard published by the United States NIST. SHA-1 produces a 160-bit (20-byte) hash value known as a message digest.";
                return BitConverter.ToString(algo.ComputeHash(InputBytes));
            }
        }
        /// <summary>
        /// Generate and returns hash value using SHA256 Hash Algorithm base on the requested InputBytes value
        /// </summary>
        public string GenerateSHA256Hash
        {
            get
            {
                var algo = new SHA256Managed();
                Description =
                    "SHA-256 Cryptographic Hash Algorithm. A cryptographic hash (sometimes called 'digest') is a kind of 'signature' for a text or a data file. SHA-256 generates an almost-unique 256-bit (32-byte) signature for a text.";
                return BitConverter.ToString(algo.ComputeHash(InputBytes));
            }
        }
        /// <summary>
        /// Generate and returns hash value using SHA386 Hash Algorithm base on the requested InputBytes value
        /// </summary>
        public string GenerateSHA384Hash
        {
            get
            {
          
                var algo = new SHA384Managed();
                Description =
                    "SHA-348 (348 bit) is part of SHA-2 set of cryptographic hash functions, designed by the U.S. National Security Agency (NSA) and published in 2001 by the NIST as a U.S. Federal Information Processing Standard (FIPS). A hash function is an algorithm that transforms (hashes) an arbitrary set of data elements, such as a text file, into a single fixed length value (the hash). The computed hash value may then be used to verify the integrity of copies of the original data without providing any means to derive said original data. Irreversible, a hash value may be freely distributed, stored and used for comparative purposes. SHA stands for Secure Hash Algorithm. SHA-2 includes a significant number of changes from its predecessor.";

                return BitConverter.ToString(algo.ComputeHash(InputBytes));
            }
        }
        /// <summary>
        /// Generate and returns hash value using SHA512 Hash Algorithm base on the requested InputBytes value
        /// </summary>

        public string GenerateSHA512Hash
        {
            get
            {
           
                var algo = new SHA512Managed();
                Description =
                    "SHA-2: A family of two similar hash functions, with different block sizes, known as SHA-256 and SHA-512. They differ in the word size; SHA-256 uses 32-bit words where SHA-512 uses 64-bit words. There are also truncated versions of each standard, known as SHA-224, SHA-384, SHA-512/224 and SHA-512/256.";
                return BitConverter.ToString(algo.ComputeHash(InputBytes));
            }

        }
        /// <summary>
        /// Generates and returns hash value using MD5 Hash Algorithm base on the requested InputBytes value
        /// </summary>
        public string GenerateMD5Hash
        {
            get
            {
          
                var algo = new MD5CryptoServiceProvider();
                Description =
                    "The MD5 algorithm is a widely used hash function producing a 128-bit hash value. Although MD5 was initially designed to be used as a cryptographic hash function, it has been found to suffer from extensive vulnerabilities.";
                return BitConverter.ToString(algo.ComputeHash(InputBytes));
            }
        }
        /// <summary>
        /// Generate and returns hash value using RSA Asymmetric SHA1 algorithm base on the requested InputBytes value
        /// </summary>
        public string GenerateSHA1Asymmetric
        {
            get
            {
         
                var algo = new HMACSHA1();
                Description =
                    "RSA is an asymmetric encryption algorithm, encrypting an input into an output that can then be decrypted (contrast a hash algorithm which can't be reversed)";
                return BitConverter.ToString(algo.ComputeHash(InputBytes));
            }

        }
        /// <summary>
        /// Generate and returns hash value using RSA Asymmetric SHA256 algorithm base on the requested InputBytes value
        /// </summary>
        public string GenerateSHA256Asymmetric
        {
            get
            {
          
                var algo = new HMACSHA256();
                Description =
                    "RSA is an asymmetric encryption algorithm, encrypting an input into an output that can then be decrypted (contrast a hash algorithm which can't be reversed)";
                return BitConverter.ToString(algo.ComputeHash(InputBytes));
            }

        }
        /// <summary>
        /// Generate and returns hash value using RSA Asymmetric SHA384 algorithm base on the requested InputBytes value
        /// </summary>
        public string GenerateSHA384Asymmetric
        {
            get
            {
 
                var algo = new HMACSHA384();
                Description =
                    "RSA is an asymmetric encryption algorithm, encrypting an input into an output that can then be decrypted (contrast a hash algorithm which can't be reversed)";
                return BitConverter.ToString(algo.ComputeHash(InputBytes));
            }
        }
        /// <summary>
        /// Generate and returns hash value using RSA Asymmetric SHA512 algorithm base on the requested InputBytes value
        /// </summary>
        public string GenerateSHA512Asymmetric
        {
            get
            {
                var algo = new HMACSHA512();
                Description =
                    "RSA is an asymmetric encryption algorithm, encrypting an input into an output that can then be decrypted (contrast a hash algorithm which can't be reversed)";
                return BitConverter.ToString(algo.ComputeHash(InputBytes));
            }

        }
        /// <summary>
        /// Generate and returns hash value using RSA Asymmetric MD5 algorithm base on the requested InputBytes value
        /// </summary>
        /// <returns></returns>
        public string GenerateMD5Asymmetric
        {
            get
            {
                var algo = new HMACMD5();
                Description =
                    "RSA is an asymmetric encryption algorithm, encrypting an input into an output that can then be decrypted (contrast a hash algorithm which can't be reversed)";
                return BitConverter.ToString(algo.ComputeHash(InputBytes));
            }

        }



        /// <summary>
        /// (UTILITY) 
        /// Displays the list of available hash algorithm options.
        /// </summary>
        public static void HashOptions()
        {
            // Convert enum array to lilst of collection
            var hashOptions = Helpers.GetEnumCollection<HashOptions>().ToList();
            // display each item in collection
            foreach (var option in hashOptions)
            {
                // view entity display name 
                Console.WriteLine(Helpers.EnumDisplayName(option));
            }
        }

        /// <summary>
        /// Parse and initialize program base on the requested input parameter values
        /// </summary>
        /// <param name="options"></param>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static HashAlgorithm HashValue(HashOptions options, string inputValue)
        {

            var hashValue = new HashAlgorithm {InputValue = inputValue};
            switch (options)
            {
                case Models.HashOptions.RipedMD160:
                    return new HashAlgorithm
                    {
                        OutputValue = hashValue.GenerateRIPEMD160Hash,
                        Description = hashValue.Description
                    };
                    
                case Models.HashOptions.SHA1:
                    return new HashAlgorithm
                    {
                        OutputValue = hashValue.GenerateSHA1Hash,
                        Description = hashValue.Description
                    };
                case Models.HashOptions.SHA256:
                    return new HashAlgorithm
                    {
                        OutputValue = hashValue.GenerateSHA256Hash,
                        Description = hashValue.Description
                    };
                case Models.HashOptions.SHA384:
                    return new HashAlgorithm
                    {
                        OutputValue = hashValue.GenerateSHA384Hash,
                        Description = hashValue.Description
                    };
                case Models.HashOptions.SHA512:
             
                    return new HashAlgorithm
                    {
                        OutputValue = hashValue.GenerateSHA512Hash,
                        Description = hashValue.Description
                    }; 
                case Models.HashOptions.MD5:
                    return new HashAlgorithm
                    {
                        OutputValue = hashValue.GenerateMD5Hash,
                        Description = hashValue.Description
                    }; 
                case Models.HashOptions.SHA1Asymmetric:
                
                    return new HashAlgorithm
                    {
                        OutputValue = hashValue.GenerateSHA1Asymmetric,
                        Description = hashValue.Description
                    }; 
                case Models.HashOptions.SHA256Asymmetric:
               
                    return new HashAlgorithm
                    {
                        OutputValue = hashValue.GenerateSHA256Asymmetric,
                        Description = hashValue.Description
                    }; 
                case Models.HashOptions.SHA384Asymmetric:
                
                    return new HashAlgorithm
                    {
                        OutputValue = hashValue.GenerateSHA384Asymmetric,
                        Description = hashValue.Description
                    }; 
                case Models.HashOptions.SHA512Asymmetric:
       
                    return new HashAlgorithm
                    {
                        OutputValue = hashValue.GenerateSHA512Asymmetric,
                        Description = hashValue.Description
                    }; 
                case Models.HashOptions.MD5Asymmetric:
                    return new HashAlgorithm
                    {
                        OutputValue = hashValue.GenerateMD5Asymmetric,
                        Description = hashValue.Description
                    }; 
                default:
                    return new HashAlgorithm { OutputValue = "", Description = "" };
            }
        }




    }
}
