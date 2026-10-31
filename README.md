# DiscreteVR

## What it does
A browser-based VR revision app for Discrete Mathematics. A central hub links six modules (Logic Gates, Graph Theory, Set Theory, Propositional Logic, Combinatorics, Proofs). Each module has revision panels around you and an in-scene AI tutor behind you. Type a question on a virtual keyboard and a local Phi-3 Mini model (run through Ollama) answers inside the scene. Everything runs on your own computer, so no data leaves it.

This was my final year project (BSc Computer Science, London South Bank University).

## How to run
1. Install [Node.js](https://nodejs.org/) and [Ollama](https://ollama.com/download).
2. Download the model: `ollama pull phi3`
3. Start Ollama. If the tutor shows a connection error, start it with `OLLAMA_ORIGINS="http://localhost:3000" ollama serve` (on Windows PowerShell, set `$env:OLLAMA_ORIGINS` first).
4. Start the web server:
   ```
   cd aframe
   node server.js
   ```
5. Open `http://localhost:3000` in Microsoft Edge.
6. To try VR mode without a headset, install the Immersive Web Emulator extension and choose the Meta Quest 3 profile.

You need an internet connection on first load, because A-Frame is loaded from a CDN.

## Repo layout
- `aframe/` - the final app (this is the one to run)
- `unity/` - my earlier Unity prototype, archived

## My role
I was the sole developer. I designed, built and tested everything myself. I used AI tools (Claude, ChatGPT) for drafting and debugging help, and reviewed and edited all of it.

### What I built in Unity (archived prototype)
- Set up a Unity 2022.3 LTS project with the XR Interaction Toolkit, OpenXR, an XR Origin rig, teleport locomotion and the XR Device Simulator for testing without a headset
- Built a hub scene with world-space UI panels for the three original modules
- Wrote a `SceneLoader` script to move between scenes from the Enter buttons
- Wrote the `OllamaService` and `SLMPanel` scripts so a question typed in the scene went to Phi-3 Mini and the reply showed in a scrollable panel, including fixing an HTTP 400 error in my JSON request

### What I built in A-Frame (final app)
- Moved the project to A-Frame/WebXR partway through, because it suited my web development background and let me test quickly in the browser
- Wrote the Node.js server and rebuilt the hub, then expanded it from three modules to six, each with its own revision panels and animated background
- Rebuilt the AI tutor as world-space objects with a virtual QWERTY keyboard, because my first HTML overlay disappeared in VR mode
- Carried the Ollama request design over from Unity, rewritten in JavaScript
- Added gaze/click interaction, hover feedback and a "Thinking..." message while the model answers

Platform-specific Unity work (scenes, prefabs, UI, C# scripts) could not be reused and had to be rebuilt. The Ollama approach and the module content carried over.

## Limitations
Tested only in the emulator, not on a physical headset, and with no external user testing. Gaze/click interaction only. Maths symbols use ASCII (`~`, `^`, `v`, `->`) because of font limits.
