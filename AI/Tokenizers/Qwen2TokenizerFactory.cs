using Microsoft.ML.Tokenizers;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TML.AI.Normalizers;

namespace TML.AI.Tokenizers
{
    public class Qwen2TokenizerFactory
    {
        private const string QWEN3_PATTERN = @"(?i:'s|'t|'re|'ve|'m|'ll|'d)|[^\r\n\p{L}\p{N}]?\p{L}+|\p{N}|[^\s\p{L}\p{N}]+|[\r\n]+|\s+(?!\S)|\s+";

        public static Tokenizer Create(string vocabsPath, string mergesPath)
        {
            var regex = new Regex(QWEN3_PATTERN);
            var specialTokens = new Dictionary<string, int>
            {
                { "<|endoftext|>", 151643 },
                { "<|im_start|>", 151644 },
                { "<|im_end|>", 151645 },
            };

            var options = new BpeOptions(vocabsPath, mergesPath)
            {
                ByteLevel = true,
                Normalizer = new NFC(),
                PreTokenizer = new RegexPreTokenizer(regex, specialTokens),
                SpecialTokens = specialTokens,
                EndOfSentenceToken = "<|endoftext|>"
            };

            return BpeTokenizer.Create(options);
        }
    }
}
