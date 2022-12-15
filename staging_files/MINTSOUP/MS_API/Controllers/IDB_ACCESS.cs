using System;
using Models;
namespace MS_API.Models
{
    public interface IDB_ACCESS
    {
        /// <summary>
        /// Get a viewer with the viewer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Viewer? GetaViewer(Guid id);
        Viewer? GetmyViewer(Guid mstoken);
        //List<Viewer?> GetViewers(Guid mstoken);
        //Show? GetaShow(Guid id);
        //Show? GetmyShows(Guid mstoken);
        IEnumerable<Show?> GetallShows(Guid mstoken);
    }

    public class DB_Access : IDB_ACCESS
    {
        private Viewer? dbviewer;
        private Show? dbshow;
        private IEnumerable<Show?> all_dbshows ;

        private IEnumerable<Show?> GetAll_dbshows()
        {
            var v = all_dbshows;
            return v;
        }

        private void SetAll_dbshows(IEnumerable<Show?> value)
        {
            all_dbshows = value;
        }

        private Show? GetDbshow()
        {
            //var v = dbshow;
            //dbshow = null;
            return dbshow;
        }

        private void SetDbshow(Show? value)
        {
            dbshow = value;
        }

        public DB_Access()
        {

        }

        private Viewer? GetDbviewer()
        {
            var v = dbviewer;
            dbviewer = null;
            return v;
        }

        private void SetDbviewer(Viewer? value)
        {
            dbviewer = value;
        }

        public Viewer? GetaViewer(Guid id)
        {
            using(var db = new MintsoupdatadbContext())
            {
                //retrieving a viewer by its id
                Viewer? viewer =  db.Viewers.OrderBy(viewer => viewer.Id == id).First();
                SetDbviewer(viewer);
            }
            return GetDbviewer();
        }

        public Viewer? GetmyViewer(Guid mstoken)
        {
            using (var db = new MintsoupdatadbContext())
            {
                //retrieving a viewer by its id
                Viewer? viewer = db.Viewers.OrderBy(viewer => viewer.FkMstoken == mstoken).First();
                SetDbviewer(viewer);
            }
            return GetDbviewer();
        }

        public IEnumerable<Show> GetallShows(Guid mstoken)
        {
            using (var db = new MintsoupdatadbContext())
            {
                //retrieving a viewer by its id
                IEnumerable<Show?> shows = db.Shows.AsEnumerable();
                SetAll_dbshows(shows);
            }
            return GetAll_dbshows();
        }
    }


}

