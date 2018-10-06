using Rehab.Model.Content;
using System.Collections.Generic;
using UnityEngine;

namespace Rehab.Services
{
    public interface IContentService
    {
        List<ActivityContent> GetActivities();
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
    }
}
