using Azure;
using Azure.AI.OpenAI;
using static System.Environment;

string endpoint = GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT_ANNA_EASTUS");
string key = GetEnvironmentVariable("AZURE_OPENAI_KEY_ANNA_EASTUS");

// Enter the deployment name you chose when you deployed the model.
string engine = "davinci";

OpenAIClient client = new(new Uri(endpoint), new AzureKeyCredential(key));

string prompt = "When was Microsoft founded?";
Console.Write($"Input: {prompt}\n");

Response<Completions> completionsResponse = 
    await client.GetCompletionsAsync(engine, prompt);
string completion = completionsResponse.Value.Choices[0].Text;
Console.WriteLine($"Chatbot: {completion}");