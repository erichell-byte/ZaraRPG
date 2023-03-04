using System;
using Game.Tutorial.App;
using Services;

namespace Game.App
{
    public sealed class LoadingTask_InstallTutorial : ILoadingTask
    {
        public async void Do(Action<LoadingResult> callback)
        {
            var installer = ServiceLocator.GetService<TutorialInstaller>();
            await installer.InstallTutorialAsync();
            callback?.Invoke(LoadingResult.Success());
        }
    }
}