using Streamish.Models;
using Streamish.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamish.Tests.Mocks
{
    class InMemoryUserProfileRepository : IUserProfileRepository
    {
        private readonly List<UserProfile> _data;

        public InMemoryUserProfileRepository(List<UserProfile> data)
        {
            _data = data;
        }

        public List<UserProfile> InternalData
        {
            get
            {
                return _data;
            }
        }

        public void Add(UserProfile UserProfile)
        {
            var lastUserProfile = _data.Last();
            UserProfile.Id = lastUserProfile.Id + 1;
            _data.Add(UserProfile);
        }

        public void Delete(int id)
        {
            var UserProfileToDelete = _data.FirstOrDefault(p => p.Id == id);
            if (UserProfileToDelete == null)
            {
                return;
            }

            _data.Remove(UserProfileToDelete);
        }

        public List<UserProfile> GetAll()
        {
            return _data;
        }

        public UserProfile GetById(int id)
        {
            return _data.FirstOrDefault(p => p.Id == id);
        }

        public void Update(UserProfile UserProfile)
        {
            var currentUserProfile = _data.FirstOrDefault(p => p.Id == UserProfile.Id);
            if (currentUserProfile == null)
            {
                return;
            }

            currentUserProfile.Name = UserProfile.Name;
            currentUserProfile.Email = UserProfile.Email;
            currentUserProfile.DateCreated = UserProfile.DateCreated;
            currentUserProfile.AuthoredVideos = UserProfile.AuthoredVideos;
            currentUserProfile.ImageUrl = UserProfile.ImageUrl;
        }



        public List<UserProfile> Search(string criterion, bool sortDescending)
        {
            throw new NotImplementedException();
        }

        public List<UserProfile> GetAllWithComments()
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUserProfileByIdWithComments(int id)
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUserProfileByIdWithVideos(int id)
        {
            throw new NotImplementedException();
        }
    }
}
