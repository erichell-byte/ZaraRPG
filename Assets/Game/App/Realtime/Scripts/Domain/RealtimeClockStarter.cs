using System.Collections;
using System.Threading.Tasks;
using Asyncoroutine;
using Services;
using SystemTime;

namespace Game.App
{
    public sealed class RealtimeClockStarter
    {
        [ServiceInject]
        private RealtimeClock realtimeClock;

        [ServiceInject]
        private RealtimeRepository repository;
        
        public async Task StartClockAsync()
        {
            if (this.repository.LoadSession(out RealtimeData previousSession))
            {
                await this.StartByPrevious(previousSession.nowSeconds);
            }
            else
            {
                await this.StartAsFirst();
            }
        }

        private IEnumerator StartByPrevious(long previousSeconds)
        {
            yield return OnlineTime.RequestNowSeconds(nowSeconds =>
            {
                var pauseTime = nowSeconds - previousSeconds;
                this.realtimeClock.Play(nowSeconds, pauseTime);
            });
        }

        private IEnumerator StartAsFirst()
        {
            yield return OnlineTime.RequestNowSeconds(nowSeconds =>
            {
                this.realtimeClock.Play(nowSeconds);
            });
        }
    }
}