using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ciphernatic.Models
{

    public class Helpers
    {
        /// <summary>
        /// Returns the enum display name
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public static string EnumDisplayName(Enum option)
        {
            return option.GetType().GetMember(option.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;
       
        }
        /// <summary>
        /// Converts the enum array to list of collections
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetEnumCollection<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }

    /// <summary>
    /// Define HashOptions enum collections 
    /// </summary>
    public enum HashOptions
    {
        [Display(Name = "[0] EXIT PROGRAM")]
        Exit,
        [Display(Name = "[1] RIPEMD160")]
        RipedMD160,
        [Display(Name = "[2] SHA1")]
        SHA1,
        [Display(Name = "[3] SHA256")]
        SHA256,
        [Display(Name = "[4] SHA384")]
        SHA384,
        [Display(Name = "[5] SHA512")]
        SHA512,
        [Display(Name = "[6] MD5")]
        MD5,
        [Display(Name = "[7] SHA1 Asymmetric")]
        SHA1Asymmetric,
        [Display(Name = "[8] SHA256 Asymmetric")]
        SHA256Asymmetric,
        [Display(Name = "[9] SHA384 Asymmetric")]
        SHA384Asymmetric,
        [Display(Name = "[10] SHA512 Asymmetric")]
        SHA512Asymmetric,
        [Display(Name = "[11] MD5 Asymmetric")]
        MD5Asymmetric,
        [Display(Name = "[99] Use Web Service")]
        WebService=99

    }

    public class HashCollection
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
