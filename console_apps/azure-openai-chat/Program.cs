using Azure;
using Azure.AI.OpenAI;
using static System.Environment;

/*
setx AZURE_OPENAI_KEY ""
setx AZURE_OPENAI_ENDPOINT ""
*/

string endpoint = GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT_ANNA_FRANCE");
string key = GetEnvironmentVariable("AZURE_OPENAI_KEY_ANNA_FRANCE");

OpenAIClient client = new(new Uri(endpoint), new AzureKeyCredential(key));
//ChatMessage setupMsg = new ChatMessage(ChatRole.System, "You are a helpful assistant. You will talk like an American old western film character");

var chatCompletionsOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatMessage(ChatRole.System, "You are a helpful assistant. You will talk like an American old western film character"),
        new ChatMessage(ChatRole.User, "Does Azure OpenAI support customer managed keys?"),
        new ChatMessage(ChatRole.Assistant, "Yes, customer managed keys are supported by Azure OpenAI."),
        new ChatMessage(ChatRole.User, "Do other Azure AI services support this too?"),
    },
    MaxTokens = 100
};

Response<ChatCompletions> response = client.GetChatCompletions(
    deploymentOrModelName: "text-turbo", 
    chatCompletionsOptions);

Console.WriteLine(response.Value.Choices[0].Message.Content);

Console.WriteLine();