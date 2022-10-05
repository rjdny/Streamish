using Streamish.Models;
using System.Collections.Generic;

namespace Streamish.Repositories
{
    public interface IVideoRepository
    {
        List<Video> GetAllWithComments();
        void Add(Video video);
        void Delete(int id);
        List<Video> GetAll();
        Video GetById(int id);
        Video GetVideoByIdWithComments(int id);
        void Update(Video video);

        public List<Video> Search(string criterion, bool sortDescending);
    }
}