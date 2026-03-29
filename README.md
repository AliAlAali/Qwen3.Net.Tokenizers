# Qwen3.Net.Tokenizers

`Qwen3.Net.Tokenizers` provides a 1:1 .NET port of the Alibaba Qwen3 tokenizer family. It is built directly on top of the `Microsoft.ML.Tokenizers` framework, allowing for seamless integration into **ML.NET**, **Semantic Kernel**, and **ONNX Runtime** workflows.

## Features
* **HF Parity:** Guaranteed identical encoding/decoding results compared to the Hugging Face `tokenizers` Python library.
* **Extensible:** Implements the `Microsoft.ML.Tokenizers.Tokenizer` base class.

## Getting Started
```C#
using Microsoft.ML.Tokenizers;
using TML.AI.Tokenizers;

var query = "Your query here";
var task = $"Instruct: Given a web search query, retrieve relevant passages that answer the query\nQuery:{query}";

var modelDir = @"TML\AI\Models\Qwen3\";
var vocabsPath = Path.Combine(modelDir, "vocab.json");
var mergesPath = Path.Combine(modelDir, "merges.txt");


var tokenizer = Qwen2TokenizerFactory.Create(vocabsPath, mergesPath);
var encoded = tokenizer.EncodeToIds(task);
