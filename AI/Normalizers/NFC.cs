using Microsoft.ML.Tokenizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TML.AI.Normalizers
{
    internal class NFC : Normalizer
    {
        public override string Normalize(string original)
        {
            return original.Normalize(NormalizationForm.FormC);
        }

        public override string Normalize(ReadOnlySpan<char> original)
        {
            return original.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
