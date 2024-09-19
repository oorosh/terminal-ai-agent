# AI Agent for Executing Terminal Commands

This project is an AI agent built using Microsoft's [Semantic Kernel](https://github.com/microsoft/semantic-kernel) that can interpret natural language commands and execute terminal commands. It utilizes OpenAI's API to handle natural language processing.

## Features

- Execute terminal commands through natural language
- Integrates with OpenAI's GPT models
- Powered by Microsoft's Semantic Kernel for AI-driven task handling

## Prerequisites

Before you begin, ensure you have the following installed on your system:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- An [OpenAI API key](https://platform.openai.com/)

## Setup

Setup user secrets 

- dotnet user-secrets init
- dotnet user-secrets set "apiKey" "{Value}"
- dotnet user-secrets set "organizationId" "{Value}"