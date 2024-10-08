# AI Agent for Executing Terminal Commands via Plain English

## Overview

This project is an experimental AI-powered agent designed to translate user prompts in plain English into terminal commands and execute them. The idea is to create AI Agent [Semantic Kernel](https://github.com/microsoft/semantic-kernel) with plugin for  that enables large language models (LLMs) to interact with a terminal by processing user inputs in a friendly, conversational manner. The AI agent is designed to assist users in navigating and executing terminal commands with ease, even without technical expertise.

> **Note**: This is an experimental project. The author is not responsible for any issues or unintended consequences that may arise from its use. Users should review commands before execution to ensure their accuracy and safety.

## Features

- **Plain English Command Execution**: The AI agent translates user input in plain English into terminal commands.
- **Command Preview**: Users can ask the agent to provide the generated command before execution for review.
- **Friendly, Helpful AI Persona**: The AI agent is designed to be friendly and eager to assist, ensuring a positive and approachable user experience.
- **Experimental**: The project is in an experimental phase and aims to explore the potential of integrating LLMs with terminal command execution.

## How It Works

The AI agent processes natural language input from the user and generates a corresponding terminal command. The user can either have the agent execute the command directly or request a preview to review it first.

1. **User Prompt**: The user provides an instruction in plain English (e.g., "List all files in this directory").
2. **Command Generation**: The agent translates this input into the corresponding terminal command (e.g., `ls`).
3. **Command Review** (Optional): The user can ask the agent to show the generated command before it's executed.
4. **Command Execution**: If the user approves the command (or skips the review), the agent executes it in the terminal.

## Installation

To set up and use this project, follow these steps:

Setup user secrets 

- dotnet user-secrets init
- dotnet user-secrets set "apiKey" "{Value}"
- dotnet user-secrets set "organizationId" "{Value}"

## Usage

Once the project is running, you can interact with the AI agent using simple English prompts, such as:

- "List all files in the current directory"
- "Create a new folder named 'test'"
- "Move file.txt to folder"
- "What command will you use to delete this folder?"
- "Delete folder"

If you want the agent to show you the command before execution, simply ask:

- "What will the command be?"

The agent will then display the generated command and wait for your confirmation to execute.

## Important Notes

- **Review Commands Before Execution**: This project is experimental, and the commands generated by the agent might not always be perfect. You should review the command, especially if you are unfamiliar with terminal commands, to avoid any unintended changes to your system.
- **Author Disclaimer**: The author is not responsible for any potential issues, damage, or data loss resulting from the use of this tool. Use it at your own risk.

## Future Plans

- Switch different models to improve accuracy in command generation.
- Support for LLM hosted localy
- Extend support for more complex commands and error handling.

## Contributions

Contributions are welcome! If you'd like to contribute to the project, feel free to submit a pull request or open an issue for discussion.