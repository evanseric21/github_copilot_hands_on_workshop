# Preflight



Run this before the 120-minute session. Facilitators should open the room early and help learners finish this before the timer starts.



## 1. Clone and open



```powershell

git clone <repository-url>

cd github_copilot_hands_on_workshop

code .

```



If you already cloned the repo, pull the latest default branch before class.



## 2. Confirm tools



```powershell

git --version

dotnet --version

```



`dotnet --version` must report a .NET 10 SDK. If multiple SDKs are installed, `dotnet --list-sdks` can help confirm .NET 10 is present.



## 3. Confirm VS Code extensions and Copilot sign-in



In VS Code:



1. Open Extensions.

2. Confirm the recommended extensions from `.vscode/extensions.json` are installed.

3. Confirm Copilot Chat opens and is signed in.

4. Confirm chat modes such as Ask, Plan, and Agent are available in your installed version. UI labels can change; use the closest current Copilot Chat mode names.



## 4. Restore and test



```powershell

dotnet test .\labs\00-preflight\starter\Preflight.Tests\Preflight.Tests.csproj

dotnet test .\GitHubCopilotWorkshop.sln

```



The preflight project should pass with the message `.NET 10 preflight passed`. The full solution validates the provided starter and refactor projects.



## 5. Confirm sample expectations



```powershell

dotnet run --project .\lab-refactor\WordFrequencyRefactor\WordFrequencyRefactor.csproj -- .\samples\sample.txt --top 5

```



Expected output:



```text

tests: 5

build: 3

code: 3

copilot: 3

practice: 3

```



## If something fails



Use [troubleshooting.md](troubleshooting.md), then ask a facilitator. During the live session, do not spend more than two minutes stuck before raising your hand.

