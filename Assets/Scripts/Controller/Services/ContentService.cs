using Rehab.Model.Content;
using System.Collections.Generic;
using UnityEngine;

namespace Rehab.Services
{
    public interface IContentService
    {
        List<ActivityContent> GetActivities();
        List<MiniGameContent> GetMiniGames();
    }

    public class ContentService : IContentService
    {
        private Content content;

        public ContentService()
        {
            content = LoadContent();
        }

        private Content LoadContent()
        {
            return Resources.Load<Content>("Content/Content");
        }

        public List<ActivityContent> GetActivities()
        {
            List<ActivityContent> activities = new List<ActivityContent>();

            for (int i = 0; i < content.activities.Length; i++)
                activities.Add(content.activities[i]);

            return activities;
        }

        public List<MiniGameContent> GetMiniGames()
        {
            List<MiniGameContent> miniGames = new List<MiniGameContent>();

            for (int i = 0; i < content.miniGames.Length; i++)
                miniGames.Add(content.miniGames[i]);

            return miniGames;
        }
    }
}
