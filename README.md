# ZaraRPG

Unity project with a modular architecture. Code is split into core application layers, gameplay features, and reusable modules in `Assets/Modules`.

## Architecture (short)

- Application initialization is driven by an `ILoadingTask` pipeline defined in `Assets/Game/App/Loading/LoadingPipeline.asset` and executed by `Assets/Game/App/Loading/Scripts/ApplicationLoader.cs`.
- Game initialization uses a separate `GameLaunchPipeline` (see `Assets/Game/App/GameManagment/Scripts/LaunchGame/GameLauncher.cs`), which decouples game start from app boot.
- Services are registered via `ServiceInstaller` and accessed through `ServiceLocator`, with attribute-based DI via `ServiceInjector`. This keeps subsystems loosely coupled and composable through service packs.
- Game lifecycle is managed by `GameContext` (construct/init/ready/play/pause/finish), with centralized registration of elements and services.
- Persistent data is stored in SQLite (`SqliteModule`); install/update tasks run during loading, and paths are configured in `DatabaseConfig`.
- Content/configs rely on ScriptableObjects and Unity Addressables (see `Packages/manifest.json` and `AddressableAssetsData`).

## Key folders

- `Assets/Game` — gameplay features and application layers (App/Gameplay/Meta/UI/Scenes).
- `Assets/Modules` — reusable modules (AI, Services, GameSystem, UIFrames, Windows, Localization, Sqlite, etc.).
- `Assets/Resources` / `Assets/StreamingAssets` — resources accessible via `Resources` and platform-specific access.
- `Packages/manifest.json` — project dependencies (Addressables, URP, Purchasing, Cinemachine, etc.).

## Design decisions

- Modular structure with `.asmdef` for code isolation and faster compilation.
- ScriptableObject pipelines for flexible initialization order without code changes.
- Service Locator + attribute-based DI for low coupling between subsystems.
- SQLite as local storage with versioning and startup migration.
- Separate AI modules (BehaviourTree/GOAP/Blackboards/PathFinding) as autonomous subsystems.
