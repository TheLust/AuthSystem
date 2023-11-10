using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSystem
{
    public class ValidationConstraint
    {
        public bool NotBlank { get; set; }
        public bool Email { get; set; }
        public bool Unique { get; set; }
        public bool Length { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public string Pattern { get; set; }
        public string PatternMessage { get; set; }

        public ValidationConstraint(bool notBlank)
        {
            NotBlank = notBlank;
        }

        public ValidationConstraint(bool notBlank,
                                    bool email)
        {
            NotBlank = notBlank;
            Email = email;
        }

        public ValidationConstraint(bool notBlank,
                                    bool email,
                                    bool unique)
        {
            NotBlank = notBlank;
            Email = email;
            Unique = unique;
        }

        public ValidationConstraint(bool notBlank,
                                    bool email,
                                    bool unique,
                                    bool length,
                                    int min,
                                    int max)
        {
            NotBlank = notBlank;
            Email = email;
            Unique = unique;
            Length = length;
            Min = min;
            Max = max;
        }

        public ValidationConstraint(bool length,
                                    int min,
                                    int max)
        {
            Length = length;
            Min = min;
            Max = max;
        }

        public ValidationConstraint(bool notBlank, 
                                    bool email,
                                    bool unique,
                                    bool length, 
                                    int min, 
                                    int max, 
                                    string pattern, 
                                    string patternMessage)
        {
            NotBlank = notBlank;
            Email = email;
            Unique = unique;
            Length = length;
            Min = min;
            Max = max;
            Pattern = pattern;
            PatternMessage = patternMessage;
        }

        public override string ToString()
        {
            return "NotBlank: " + NotBlank + "\n";
        }


    }
}
