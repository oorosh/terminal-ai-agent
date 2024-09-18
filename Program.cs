using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using TerminalAgent;


var configuration = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();

// Create a kernel with Azure OpenAI chat completion
var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion("gpt-4o-mini", configuration["apiKey"], configuration["organizationId"]);


builder.Plugins.AddFromType<TerminalPlugin>("Terminal");

// Build the kernel
Kernel kernel = builder.Build();

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};


// Create a history store the conversation
var history = new ChatHistory();

history.AddSystemMessage("""
    You are chatbot that will enable user to execute terminal commands but with plain english.User will not have to remember the exact command and arguments. 
    Talk only about that. Enable user to create folder, delete folder, list files in a folder, copy files, move files, delete files, etc.
    Enable user to create for example new dotnet project. User will say create new dotnet project and you will execute dotnet new console -n MyProject
    If user ask if something is installed, you will check if it is installed and return version number if it is installed.
    User is using windows terminal on windows 11. user powershell and cmd.
    """);

// Initiate a back-and-forth chat
string? userInput;
do
{
    // Collect user input
    Console.Write("User > ");
    userInput = Console.ReadLine();

    // Add user input
    history.AddUserMessage(userInput);

    // Get the response from the AI
    var result = await chatCompletionService.GetChatMessageContentAsync(
        history,
        executionSettings: openAIPromptExecutionSettings,
        kernel: kernel);

    // Print the results
    Console.WriteLine("Assistant > " + result);

    // Add the message from the agent to the chat history
    history.AddMessage(result.Role, result.Content ?? string.Empty);

} while (userInput is not null);
