using System;
using System.IO;
using static System.Environment;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;

namespace Azure.AI.OpenAI
{
    public partial class GenerateImages
    {
        // add an async Main method:
        public static async Task Main(string[] args)
        {
            string endpoint = GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT_ANNA_EASTUS");
            string key = GetEnvironmentVariable("AZURE_OPENAI_KEY_ANNA_EASTUS");

            OpenAIClient client = new(new Uri(endpoint), new AzureKeyCredential(key));

            Response<ImageGenerations> imageGenerations = await client.GetImageGenerationsAsync(
                new ImageGenerationOptions()
                {
                    Prompt = "an unhappy monkey eating a banana, in watercolor",
                    Size = ImageSize.Size256x256,
                });

            // Image Generations responses provide URLs you can use to retrieve requested images
            Uri imageUri = imageGenerations.Value.Data[0].Url;
            
            // Print the image URI to console:
            Console.WriteLine(imageUri);
        }
    }
}