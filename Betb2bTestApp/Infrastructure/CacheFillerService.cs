using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Betb2bTestAppModels.Models;

namespace Betb2bTestApp.Infrastructure
{
    public class CacheFillerService : BackgroundService
    {
        private readonly ISimpleCache<int, UserInfoModel> _simpleCache;

        public static readonly int UpdateInterval = (int) TimeSpan.FromMinutes(10).TotalMilliseconds;

        public CacheFillerService(ISimpleCache<int, UserInfoModel> simpleCache)
        {
            _simpleCache = simpleCache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var context = new Betb2bTestAppContext())
                {
                    //it's better to use chunk load when we have huge amount of stored users
                    foreach (var dbUser in context.Users.ToList())
                    {
                        _simpleCache.AddOrUpdate(dbUser.Id, new UserInfoModel
                        {
                            Status = (Status) dbUser.Status,
                            Name = dbUser.Name,
                            Id = dbUser.Id
                        });
                    }
                }

                await Task.Delay(UpdateInterval, stoppingToken);
            }
        }

    }   
}
