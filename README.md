# Open Flappy Bird

An open-source, Unity-powered clone of the original Flappy Bird.  
Made with ❤️ using SOLID principles, clean architecture, and community-first development.

## 🚀 Features

-   Modular code structure following SOLID principles
-   Clean architecture for maintainability and extensibility
-   MIT licensed assets
-   GitHub project boards for planning
-   Open to contributors of all skill levels

## 🔧 How to Run

1. Clone this repository
2. Open Unity Hub
3. Add the `OpenFlappyBird/` folder as a project
4. Run the `MainScene` in `Assets/Scenes/`

## 🛠️ Project Structure

```
open-flappy-bird/
├── OpenFlappyBird/             # Unity project root
│   ├── Assets/
│   │   ├── Scripts/
│   │   │   ├── Core/           # Game logic: Bird.cs, Pipe.cs, GameManager.cs
│   │   │   ├── UI/             # UI scripts: ScoreUI.cs, MenuUI.cs
│   │   │   └── Utils/          # Utilities: ObjectPooler.cs
│   │   ├── Scenes/             # Unity scenes: MainScene.unity
│   │   ├── Prefabs/            # Prefab assets: Bird.prefab, Pipe.prefab
│   │   └── Sprites/            # 2D assets and backgrounds
│   ├── Packages/               # Unity package dependencies
│   └── ProjectSettings/        # Unity project settings
├── .github/
│   ├── workflows/              # GitHub Actions CI/CD workflows
│   ├── ISSUE_TEMPLATE/         # Issue templates for contributors
│   └── PULL_REQUEST_TEMPLATE/  # Pull request templates for contributors
├── .gitignore                  # Git ignore rules
├── LICENSE                     # Project license (MIT)
├── README.md                   # Project overview and setup instructions
└── CONTRIBUTING.md             # Guidelines for contributing to the project
```

## 🤝 Contributing

Contributions are welcome! Please check out our [contributing guidelines](CONTRIBUTING.md) to get started.

## 📝 Development Roadmap

-   [x] Initial project setup
-   [ ] Basic game mechanics
-   [ ] UI implementation
-   [ ] Sound effects and music
-   [ ] Score system
-   [ ] Difficulty progression

## 📄 License

[MIT](LICENSE)
