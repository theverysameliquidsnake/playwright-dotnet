# Simple Playwright with .NET example
Simple automated test suite built using Playwright for .NET

## Prerequisites
Make sure you have the following installed:
- .NET SDK
- PowerShell

## Install
1. Clone repo
```zsh
git clone https://github.com/theverysameliquidsnake/playwright-dotnet.git
cd playwright-dotnet
```

2. Download dependencies and build
```zsh
dotnet restore
dotnet build
```

3. Download Playwright
```zsh
pwsh bin/Debug/net10.0/playwright.ps1 install
```

4. Run test
```zsh
dotnet test
```
