# Lab 0 — Preflight

> Run this **before** the workshop starts. It is not part of the 120-minute clock.

| | |
|---|---|
| **Timebox** | 10–15 min at home or during doors-open pre-roll, **plus a 2-minute gate** at the start of the session |
| **Copilot surface** | Copilot Chat, agent mode, model picker, Copilot code review entry point |
| **Working directory** | The repository root — the folder named `github_copilot_hands_on_workshop` |
| **Starting point** | A cloned copy of this repository and a terminal |
| **Track** | Everyone. There is no "skip" option — the later labs assume this passed. |

## Goal

Prove that your machine can build C#, run tests, and talk to Copilot **before** the room starts moving.
Every problem you find here costs you 3 minutes now. The same problem found in Lab 5 costs you the capstone.

## Prerequisites

- **VS Code** (primary editor for this workshop). Visual Studio 2022+ and JetBrains Rider work too — notes are called out where menus differ.
- **GitHub Copilot** and **GitHub Copilot Chat** extensions, signed in with an account that has Copilot enabled.
- **.NET SDK 10** (`net10.0` is the target framework for every project here).
- **git** and a terminal you can type in.

VS Code will offer to install the recommended extensions from `.vscode/extensions.json` when you open the folder. Say yes.

## Definition of done

You can tick all six boxes:

- [ ] 1. `dotnet --version` reports a 10.x SDK.
- [ ] 2. The whole solution restores and builds.
- [ ] 3. The preflight app prints its success line.
- [ ] 4. The preflight test passes.
- [ ] 5. Copilot Chat answers a question **in agent mode**.
- [ ] 6. You can find the Copilot code review entry point in your editor.

---

## Steps

### 1. Clone the repository and open it

```powershell
# Working directory: wherever you keep code, e.g. C:\src
git clone https://github.com/evanseric21/github_copilot_hands_on_workshop.git
cd github_copilot_hands_on_workshop
code .
```

> **bash:** identical, except use your own path style — `cd ~/src` instead of `cd C:\src`.

**Every command in every lab runs from this repository root unless the lab says otherwise.**

### 2. Confirm the SDK

```powershell
# Working directory: repository root
dotnet --version
```

Expect a version that starts with `10.`. If you see `8.x` or `9.x`, install the .NET 10 SDK before continuing — the projects target `net10.0` and will not build on an older SDK.

### 3. Warm the build (this is the slow one — do it before the session)

```powershell
# Working directory: repository root
dotnet build GitHubCopilotWorkshop.sln
```

The first run downloads NuGet packages for the test projects. On conference wifi this can take a few minutes; that is exactly why this step is pre-roll and not in-session. Expect `Build succeeded`.

### 4. Run the preflight app

```powershell
# Working directory: repository root
dotnet run --project labs/00-preflight/starter/Preflight
```

Expected output, exactly:

```text
.NET 10 preflight passed
```

### 5. Run the preflight test

```powershell
# Working directory: repository root
dotnet test labs/00-preflight/starter/Preflight.Tests/Preflight.Tests.csproj
```

Expected tail of the output:

```text
Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1
```

### 6. Copilot check A — chat and agent mode

Open the Copilot Chat panel in VS Code (`Ctrl+Alt+I`, or the Copilot icon in the title bar).

- Confirm you can switch the mode selector to **Agent**. The deck's three chat modes are **Ask**, **Plan**, and **Agent**.
- Confirm the model picker opens and shows at least one model (including **Auto**).

Paste this into chat and send it:

```text
In one sentence, what target framework does labs/00-preflight/starter/Preflight/Preflight.csproj use?
```

You should get an answer naming `net10.0`. If Copilot answers, your entitlement and network path both work.

> **Visual Studio:** the Copilot Chat window is under `View > GitHub Copilot Chat`.
> **Rider:** the AI Assistant tool window, with the GitHub Copilot plugin installed.

### 7. Copilot check B — find the code review entry point

You will use this in Lab 6, so find it now while nothing is at stake:

- **VS Code:** open the **Source Control** view and look for **Copilot Code Review – Uncommitted Changes**. Selecting code in the editor and right-clicking also exposes a Copilot review option.
- You do **not** need to run a review now. You only need to know where the button lives.

---

## Midpoint checkpoint

**After step 4** you should have a green build and the line `.NET 10 preflight passed` on screen.
If you do not, stop working through the rest of the list and jump to [Recovery](#beginner-recovery-path) — steps 5–7 will not save you if the SDK is wrong.

---

## Verify (the 2-minute in-session gate)

When the session starts, the facilitator will ask you to run exactly this and show a green result:

```powershell
# Working directory: repository root
dotnet run --project labs/00-preflight/starter/Preflight
dotnet test labs/00-preflight/starter/Preflight.Tests/Preflight.Tests.csproj
```

Green on both lines = you are cleared for all six labs. Raise a hand if either fails.

---

## No-push / no-PR fallback

This lab needs **read-only** network access: a `git clone` and a NuGet restore. It never pushes.

- If your laptop blocks `git clone` over HTTPS, get the repository as a ZIP from a neighbour or a USB stick and extract it — nothing in this workshop requires git history or a remote.
- If NuGet is blocked, ask your facilitator for the pre-warmed `bin`/`obj` folders or pair with someone whose restore succeeded. Labs 1–4 need no restore at all.
- You never need to `git push` or open a pull request in this workshop. Pushing is optional enrichment in Lab 6 only.

## Beginner recovery path

| Symptom | Fix |
|---|---|
| `dotnet` is not recognised | The SDK is not installed or not on `PATH`. Install the .NET 10 SDK, then **open a new terminal** — `PATH` changes do not reach an already-open shell. |
| `dotnet --version` shows 8.x or 9.x | Install the .NET 10 SDK side-by-side. Both can coexist; `net10.0` projects need the 10 SDK. |
| `error NETSDK1045: The current .NET SDK does not support targeting net10.0` | Same fix as above — the 10 SDK is missing. |
| NuGet restore hangs or fails | Retry once on a different network. If it still fails, you can still do Labs 1–4 (chat and authoring only) and pair with a neighbour for Labs 5–6. |
| Copilot Chat says you are not signed in | Command Palette → `GitHub Copilot: Sign In`. If your org has not granted a seat, pair with a neighbour — the whole workshop works fine two-to-a-laptop, and pairing is encouraged anyway. |
| No **Agent** option in the mode selector | Update the GitHub Copilot Chat extension to the latest version and reload the window. |

## Stretch (optional, intermediate)

- Run the whole suite in one shot and confirm both test projects report green:
  ```powershell
  # Working directory: repository root
  dotnet test GitHubCopilotWorkshop.sln
  ```
  Expect `Passed!` for `Preflight.Tests` (1 test) and `WordFrequencyRefactor.Tests` (8 tests).
- Peek at [`samples/README.md`](../../samples/README.md) and the shared input at [`samples/sample.txt`](../../samples/sample.txt). Every counting lab uses that one file so the whole room can compare results.
- Ask Copilot Chat: *"Summarise what `lab-refactor/WordFrequencyRefactor/CommandLineApp.cs` does in five bullets."* It is a preview of Lab 6 and a free warm-up on reading code with Copilot.

## Reflect (30 seconds)

Which of the six checks was the one you were not sure about? That is the check worth repeating on your own machine at work before you try any of this on a real repository.

## Next

➡️ [Lab 1 — Prompt comparison](../01-prompt-comparison/README.md)
