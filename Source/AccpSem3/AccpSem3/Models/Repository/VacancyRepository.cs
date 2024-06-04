using AccpSem3.Models.Entities;
using AccpSem3.Models.ModeView;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace AccpSem3.Models.Repository
{
    public class VacancyRepository
    {
        private static VacancyRepository instance = null;
        private VacancyRepository() { }
        public static VacancyRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VacancyRepository();
                }
                return instance;
            }
        }

        public ICollection<Vacancy> GetAllVacancies()
        {
            try
            {
                dbSem3Entities en = new dbSem3Entities();
                var rs = en.Vacancies.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public VacanciesView GetVacancyById(int id)
        {
            try
            {
                dbSem3Entities en = new dbSem3Entities();
                var item = en.Vacancies.Where(va => va.id == id).FirstOrDefault();
                VacanciesView vacanciesView = new VacanciesView();
                vacanciesView.id = item.id;
                vacanciesView.name = item.name;
                vacanciesView.description = item.description;
                vacanciesView.quantity_emp = item.quantity_emp;
                vacanciesView.id_dep = item.id_dep;
                vacanciesView.status = item.status;
                vacanciesView.created_at = item.created_at;
                vacanciesView.updated_at = item.updated_at;
                vacanciesView.salary = item.salary;
                vacanciesView.featured = item.featured;
                vacanciesView.jobnature = item.jobnature;
                vacanciesView.dateline = item.dateline;
                if (item.dateline.HasValue)
                {
                    var date = item.dateline.Value.ToString("dd MMM, yyyy");
                    vacanciesView.dateline_view = date;
                }
                if (item.created_at.HasValue)
                {
                    var datec = item.created_at.Value.ToString("dd MMM, yyyy");
                    vacanciesView.created_at_view = datec;
                }
                return vacanciesView;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ICollection<VacanciesView> GetVacanciesView(string jobnature, int featured)
        {
            try
            {
                dbSem3Entities en = new dbSem3Entities();
                var rs = en.Vacancies.Where(va => (va.status.Equals("open") && va.featured == featured) || (va.status.Equals("open") && va.jobnature.Equals(jobnature))).ToList();
                List<VacanciesView> vv = new List<VacanciesView>();
                foreach (var item in rs)
                {
                    VacanciesView vacanciesView = new VacanciesView();
                    vacanciesView.id = item.id;
                    vacanciesView.name = item.name;
                    vacanciesView.description = item.description;
                    vacanciesView.quantity_emp = item.quantity_emp;
                    vacanciesView.id_dep = item.id_dep;
                    vacanciesView.status = item.status;
                    vacanciesView.created_at = item.created_at;
                    vacanciesView.updated_at = item.updated_at;
                    vacanciesView.salary = item.salary;
                    vacanciesView.featured = item.featured;
                    vacanciesView.jobnature = item.jobnature;
                    vacanciesView.dateline = item.dateline;
                    if (item.dateline.HasValue)
                    {
                        var date = item.dateline.Value.ToString("dd MMM, yyyy");
                        vacanciesView.dateline_view = date;
                    }
                    if (item.created_at.HasValue)
                    {
                        var datec = item.created_at.Value.ToString("dd MMM, yyyy");
                        vacanciesView.created_at_view = datec;
                    }
                    vv.Add(vacanciesView);
                }
                return vv;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}