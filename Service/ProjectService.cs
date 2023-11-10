using AuthSystem.Context;
using AuthSystem.Util.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSystem.Service
{
    public class ProjectService
    {
        private AuthSystemEntities context;

        public ProjectService()
        {
            context = new AuthSystemEntities();
        }

        public List<Project> FindAll()
        {
            return context.Projects.ToList();
        }

        public Project FindById(int id)
        {
            Project project = context.Projects.Find(id);
            return project == null ? 
                throw new Exception(AppConstant.GetExceptionMessage(
                    AppConstant.PROJECT.Item1, 
                    AppConstant.Id,
                    AppConstant.NOT_FOUND)) : project;
        }

        public void Add(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
        }

        public void Update(int id, Project project)
        {
            var existingProject = context.Projects.Find(id) ?? 
                throw new Exception(AppConstant.GetExceptionMessage(
                    AppConstant.PROJECT.Item1, 
                    AppConstant.Id, 
                    AppConstant.NOT_FOUND));
            existingProject.Name = project.Name;
            context.SaveChanges();
        }

        public void Remove(Project project)
        {
            project = context.Projects.Find(project.Id) ?? 
                throw new Exception(AppConstant.GetExceptionMessage(AppConstant.PROJECT.Item1, AppConstant.Id, AppConstant.NOT_FOUND));
            context.Projects.Remove(project);
            context.SaveChanges();
        }
    }
}
