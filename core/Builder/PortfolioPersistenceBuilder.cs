using System;
using PortfolioApi.Models.Helpers.Builder;

namespace PortfolioApi.Core.Builder
{
    public class PortfolioPersistenceBuilder<T> : PortfolioBuilder where T : PortfolioPersistenceBuilder<T>
    {
        public T SetDefaultPersistence(Action<PersistenceSettings> settingFunc)
        {
            var ps = new PersistenceSettings();
            settingFunc.Invoke(ps);
            config.DefaultPersistenceSettings = ps; 
            return (T)this;
        }

        public T SetMainPersistence(Func<PersistenceSettings, PersistenceSettings> settingFunc)
        {
            config.MainPersistenceSettings = settingFunc.Invoke(new PersistenceSettings());
            return (T)this;
        }

        public T SetExperiencesRelationshopPersistence(Func<PersistenceSettings, PersistenceSettings> settingFunc)
        {
            config.ExperienceRelationshipPersistenceSettings = settingFunc.Invoke(new PersistenceSettings());
            return (T)this;
        }
    }
}
