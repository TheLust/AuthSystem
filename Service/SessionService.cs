using AuthSystem.Context;
using AuthSystem.Security;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSystem.Service
{
    public class SessionService
    {
        private AuthSystemEntities context;

        public SessionService()
        {
            context = new AuthSystemEntities();
        }

        public List<Session> FindAll()
        {
            return context.Sessions.Include(e => e.Assignment).ToList();
        }

        public List<Session> FindSessionsByAccount(Account account)
        {
            return FindAll().Where(s => s.Assignment.EmployeeId == account.Id).ToList();
        }

        public Session FindById(int id)
        {
            Session session = context.Sessions.Find(id);

            if (session == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Session", "id", AppConstant.NOT_FOUND));
            }

            return session;
        }

        public void Add(Session session)
        {
            context.Sessions.Add(session);
            context.SaveChanges();
        }

        public void Update(int id, Session session)
        {
            var existingSession = context.Sessions.Find(id);

            if (existingSession == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Session", "id", AppConstant.NOT_FOUND));
            }

            existingSession.Start = session.Start;
            existingSession.End = session.End;
            existingSession.AssignmentId = session.AssignmentId;
            context.SaveChanges();
        }

        public void Remove(Session session)
        {
            session = context.Sessions.Find(session.Id);

            if (session == null)
            {
                throw new Exception(AppConstant.GetExceptionMessage("Session", "id", AppConstant.NOT_FOUND));
            }

            context.Sessions.Remove(session);
            context.SaveChanges();
        }
    }
}
