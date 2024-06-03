using AccpSem3.Models.Entities;
using AccpSem3.Models.ModeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccpSem3.Models.Repository
{
    public class DepartmentRepositories
    {
        private static DepartmentRepositories _instance;

        private DepartmentRepositories() { }

        public static DepartmentRepositories Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DepartmentRepositories();
                }
                return _instance;
            }
        }
        public List<DepartmentView> GetAll()
        {
            try
            {
                dbSem3Entities entities = new dbSem3Entities();
                var q = entities.Departments.Select(d => new DepartmentView { id = d.id, Dname = d.Dname }).ToList();
                return q;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<DepartmentView> GetByIdDep(int? id)
        {
            try
            {
                int? id_test = id;

                dbSem3Entities entities = new dbSem3Entities();
                var q = entities.Departments.Where(y => y.id == id).ToList();

                var depviews = q.Select(dep => new DepartmentView
                {
                    id = dep.id,

                    Dname = dep.Dname,
                }).ToList();
                return depviews;
            }
            catch (Exception e)
            {

            }
            return null;
        }
        public int InsertDep(DepartmentView model)
        {
            try
            {
                if (model!= null)
                {
                    dbSem3Entities entities = new dbSem3Entities();

                    Department modelDep = new Department();
                    modelDep.Dname = model.Dname;
                    entities.Departments.Add(modelDep);
                    entities.SaveChanges();

                    return 1;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
        public int UpdateDep(DepartmentView model)
        {
            try
            {
                if (model != null)
                {
                    dbSem3Entities entities = new dbSem3Entities();
                    var q = entities.Departments.Find(model.id);
                    if (q != null)
                    {
                        q.Dname = model.Dname;
                        entities.SaveChanges();
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
    }
}